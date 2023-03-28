using CustomForms.Data;
using CustomForms.ServerApp.Statics;
using CustomForms.Statics;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Validators
{
    public class FormFieldValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || value.ToString().Length == 0)
            {
                return new ValidationResult(Notices.FormFieldEmpty);
            }

            object formFieldInstance = validationContext.ObjectInstance;
            Type type = formFieldInstance.GetType();
            //PropertyInfo FormFieldType = type.GetProperty(Notices.FormFieldType);
            //object propertyValue = FormFieldType.GetValue(formFieldInstance);

            var formFieldObject = (FormInputFieldDefinition)formFieldInstance;

            //FieldTypes currentFieldType = new FieldTypes();  
            //Enum.TryParse(FormFieldType.ToString(), out currentFieldType);

            switch (formFieldObject.FieldType)
            {
                case FieldTypes.text:
                    if (!String.IsNullOrEmpty(formFieldObject.MaxLength)
                        && int.Parse(formFieldObject.MaxLength) < formFieldObject.StringData.Length)
                    {
                        return new ValidationResult(Notices.FormFieldStringToLong);
                    }

                    if (!String.IsNullOrEmpty(formFieldObject.MinLength)
                        && int.Parse(formFieldObject.MinLength) > formFieldObject.StringData.Length)
                    {
                        return new ValidationResult(Notices.FormFieldStringToShort);
                    }

                    break;
                case FieldTypes.number:

                    var theIntValue = value.ToString();
                    break;
            }

            return ValidationResult.Success;
        }
    }
}
