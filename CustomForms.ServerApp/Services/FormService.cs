using CustomForms.Data;
using CustomForms.Statics;

namespace CustomForms.ServerApp.Services
{
    public interface IFormService
    {
        BlankForm GetBlankForm(int id);
        List<BlankForm> GetBlankFormList();
    }
    public class FormService : IFormService
    {
        List<BlankForm> _blankForms { get; set; } = new List<BlankForm>();
        public FormService()
        {
            _blankForms.Add(
                new BlankForm {
                    FormFields = new List<CustomForms.Data.FormInputField> {
                        new CustomForms.Data.FormInputField { Id = 1, Order = 1, Data = "", Name = "", FieldType = FieldTypes.text, Placeholder = "Name" },
                        new CustomForms.Data.FormInputField { Id = 2, Order = 3, Data = "", Name = "Address 2", FieldType = FieldTypes.text, Placeholder = "plceholder text" },
                        new CustomForms.Data.FormInputField { Id = 3, Order = 2, Data = "", Name = "Address 1", FieldType = FieldTypes.text },
                        new CustomForms.Data.FormInputField { Id = 4, Order = 4, Data = "", Name = "Amount", FieldType = FieldTypes.number }
                    },
                    Id = 5,
                });

            _blankForms.Add(
                new BlankForm {
                FormFields = new List<CustomForms.Data.FormInputField> {
                        new CustomForms.Data.FormInputField { Id = 1, Order = 1, Data = "", Name = "", FieldType = FieldTypes.text, Placeholder = "Company Name" },
                        new CustomForms.Data.FormInputField { Id = 2, Order = 3, Data = "", Name = "Address 2", FieldType = FieldTypes.text, Placeholder = "plceholder text" },
                        new CustomForms.Data.FormInputField { Id = 3, Order = 2, Data = "", Name = "Address 1", FieldType = FieldTypes.text },
                        new CustomForms.Data.FormInputField { Id = 4, Order = 4, Data = "", Name = "Amount Employees", FieldType = FieldTypes.number }
                    },
                    Id = 6,
                });
        }
        public BlankForm GetBlankForm(int id)
        {
            var blankform = _blankForms.Where(x => x.Id == id).FirstOrDefault();

            if(blankform == null)
            {
                throw new Exception("No form avalible");
            }

            return blankform;
        }

        public List<BlankForm> GetBlankFormList()
        {
            return _blankForms;
        }
    }
}
