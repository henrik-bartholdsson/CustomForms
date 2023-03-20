using CustomForms.Data;
using CustomForms.ServerApp.Dtos;
using CustomForms.Statics;

namespace CustomForms.ServerApp.Services
{
    public interface IFormService
    {
        BlankForm GetBlankFormByDispatch(Guid id);
        List<BlankForm> GetBlankFormList();
    }
    public class FormService : IFormService
    {
        List<BlankForm> _blankForms { get; set; } = new List<BlankForm>();
        List<Dispatch> _dispatches { get; set; } = new List<Dispatch> ();
        public FormService()
        {
            _blankForms.Add(
                new BlankForm
                {
                    FormFields = new List<CustomForms.Data.FormInputFieldDefinition> {
                        new CustomForms.Data.FormInputFieldDefinition { Id = 1, Order = 1, StringData = "", Name = "", FieldType = FieldTypes.text, Placeholder = "Name" },
                        new CustomForms.Data.FormInputFieldDefinition { Id = 2, Order = 3, StringData = "", Name = "Address 2", FieldType = FieldTypes.text, Placeholder = "plceholder text" },
                        new CustomForms.Data.FormInputFieldDefinition { Id = 3, Order = 2, StringData = "", Name = "Address 1", FieldType = FieldTypes.text },
                        new CustomForms.Data.FormInputFieldDefinition { Id = 4, Order = 4, StringData = "", Name = "Amount", FieldType = FieldTypes.number }
                    },
                    Id = 5,
                    FormDescription = "Customer Registration"
                }); ;

            _blankForms.Add(
                new BlankForm
                {
                    FormFields = new List<CustomForms.Data.FormInputFieldDefinition> {
                        new CustomForms.Data.FormInputFieldDefinition { Id = 1, Order = 1, StringData = "", Name = "", FieldType = FieldTypes.text, Placeholder = "Company Name" },
                        new CustomForms.Data.FormInputFieldDefinition { Id = 2, Order = 3, StringData = "", Name = "Address 2", FieldType = FieldTypes.text, Placeholder = "plceholder text" },
                        new CustomForms.Data.FormInputFieldDefinition { Id = 3, Order = 2, StringData = "", Name = "Address 1", FieldType = FieldTypes.text },
                        new CustomForms.Data.FormInputFieldDefinition { Id = 4, Order = 4, StringData = "", Name = "Amount Employees", FieldType = FieldTypes.number }
                    },
                    Id = 6,
                    FormDescription = "Company Registration"
                }); ;


            _dispatches.Add(new Dispatch { Email = "email1@test.com", FormId = 5, Sent = false, Id = Guid.Parse("0fc0c2f2-7c2f-4a15-951a-5366589745cc") });
            _dispatches.Add(new Dispatch { Email = "email1@test.com", FormId = 6, Sent = false, Id = Guid.Parse("e487e2fb-9bab-4311-a727-659b30110359") });
            _dispatches.Add(new Dispatch { Email = "email2@test.com", FormId = 5, Sent = false, Id = Guid.Parse("4495c5da-bb32-4916-967b-d35573d4ecbd") });

        }

        public BlankForm GetBlankFormByDispatch(Guid id)
        {
            var dispatch = _dispatches.Where(x => x.Id == id).FirstOrDefault();

            if(dispatch == null)
            {
                throw new Exception("Utskick finns ej");
            }

            var blankform = _blankForms.Where(x => x.Id == dispatch.FormId).FirstOrDefault();

            if(blankform == null)
            {
                throw new Exception("Utskick finns ej");
            }

            return blankform;
        }

        public List<BlankForm> GetBlankFormList()
        {
            return _blankForms;
        }
    }
}
