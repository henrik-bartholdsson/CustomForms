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
        Task<DispatchDto> GetDispatch(string id);
        Task<List<BlankForm>> GetBlankFormList();
        void SubmitForm(DispatchDto Dispatch);
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

        public async Task<DispatchDto> GetDispatch(string id)
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

            var dispatchDto = _mapper.Map<DispatchDto>(dispatch);

            return dispatchDto;
        }

        public async Task<List<BlankForm>> GetBlankFormList()
        {
            return await _context.BlankForms.ToListAsync();
        }

        public void SubmitForm(DispatchDto dispatchDto)
        {
            var dispatch = _context.Dispatches.Where(d => d.Id == dispatchDto.Id).FirstOrDefault();

            if (dispatch == null)
            {
                throw new Exception("Error: 404");
            }

            dispatch.Status = FormStatuses.Submitted;

            foreach (var fa in dispatchDto.BlankFormDto.FormFieldDtos)
            {
                dispatch.Answers.Add(
                    new FormInputFieldAnswer
                    {
                        DispatchId = dispatch.Id,
                        IntegerData = fa.IntegerData,
                        StringData = fa.StringData,
                        FieldDefinitionId = fa.Id
                    });
            }

            _context.SaveChanges();
        }
    }
}