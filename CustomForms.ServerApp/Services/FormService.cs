using CustomForms.Data;
using CustomForms.ServerApp.Data;
using CustomForms.ServerApp.Dtos;
using CustomForms.ServerApp.Statics;
using CustomForms.Statics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Services
{
    public interface IFormService
    {
        Task<Dispatch> GetDispatch(string id);
        List<BlankForm> GetBlankFormList();
        void SubmitForm(Dispatch Dispatch);
    }

    public class FormService : IFormService
    {
        List<BlankForm> _blankForms { get; set; } = new List<BlankForm>();
        List<Dispatch> _dispatches { get; set; } = new List<Dispatch>();
        private static CustomFormsContext _context;
        public FormService(CustomFormsContext context)
        {
            _context = context;

        }

        public async Task<Dispatch> GetDispatch(string id)
        {
            Guid dispatchId;
            BlankFormDto blankFormDto = new BlankFormDto();

            try
            {
                dispatchId = Guid.Parse(id);
            }
            catch (Exception)
            {
                throw new Exception("Utskick finns ej");
            }

            var dispatch = await _context.Dispatches
                .Include(b => b.BlankForm)
                .ThenInclude(f => f.FormFields)
                .Where(x => x.Id == dispatchId
                    && x.Status == FormStatuses.Dispatched)
                .FirstOrDefaultAsync();


            if (dispatch == null)
            {
                throw new Exception(Notices.BlankFormAllreadtSubmitted);
            }

            //var blankForm = await _context.BlankForms
            //    .Include(x => x.FormFields)
            //    .Where(x => x.Id == dispatch.BlankFormId)
            //    .FirstOrDefaultAsync();

            //dispatch.BlankFormDto = new BlankFormDto
            //{
            //    Id = blankForm.Id,
            //    FormDescription = blankForm.FormDescription,
            //    FormFields = new List<FormInputFieldDefinitionDto>()
            //};

            //foreach (var field in blankForm.FormFields)
            //{
            //    dispatch.BlankFormDto.FormFields.Add(
            //        new FormInputFieldDefinitionDto
            //        {
            //            FieldType = field.FieldType,
            //            Id = field.Id,
            //            IntegerData = field.IntegerData,
            //            MaxLength = 15,
            //            MinLength = 4,
            //            Name = field.Name,
            //            Order = field.Order,
            //            Placeholder = field.Placeholder,
            //            StringData = field.StringData,
            //        });
            //}

            return dispatch;
        }

        public List<BlankForm> GetBlankFormList()
        {
            return _blankForms;
        }

        public void SubmitForm(Dispatch Dispatch)
        {
            var FormInputFieldAnswers = new List<FormInputFieldAnswer>();


            foreach (var f in Dispatch.BlankForm.FormFields)
            {
                if (f.FieldType == 0)
                {
                    FormInputFieldAnswers.Add(
                        new FormInputFieldAnswer { Data = f.StringData, DispatchId = Dispatch.Id });
                }
                else if (f.FieldType == FieldTypes.number)
                {
                    FormInputFieldAnswers.Add(
                        new FormInputFieldAnswer { Data = f.IntegerData.ToString(), DispatchId = Dispatch.Id });
                }
            }

            foreach (var f in FormInputFieldAnswers)
            {
                _context.FormInputFieldAnswers.Add(f);
            }
            Dispatch.Status = FormStatuses.Submitted;
            _context.SaveChanges();
        }
    }
}

// Data sparas i definitionerna, så ska det inte vara. Kanske implementera en Vymodell eller dto?