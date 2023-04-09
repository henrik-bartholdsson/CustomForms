using AutoMapper;
using CustomForms.Data;
using CustomForms.ServerApp.Data;
using CustomForms.ServerApp.Dtos;
using CustomForms.ServerApp.Statics;
using CustomForms.Statics;
using Microsoft.EntityFrameworkCore;

namespace CustomForms.ServerApp.Services
{
    public interface IFormService
    {
        Task<Dispatch> GetDispatch(string id);
        Task<List<BlankForm>> GetBlankFormList();
        void SubmitForm(Dispatch Dispatch);
    }

    public class FormService : IFormService
    {
        private static CustomFormsContext _context;
        private static IMapper _mapper;
        public FormService(CustomFormsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Dispatch> GetDispatch(string id)
        {
            Guid dispatchId;

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

            return dispatch;
        }

        public async Task<List<BlankForm>> GetBlankFormList()
        {
            return await _context.BlankForms.ToListAsync();
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