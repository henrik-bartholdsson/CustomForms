using CustomForms.Data;
using CustomForms.ServerApp.Dtos;
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

            var formFieldObject = (FormInputFieldDefinitionDtoCreate)formFieldInstance;

            switch (formFieldObject.FieldType)
            {
                case FieldTypes.text:
                    if (formFieldObject.MaxLength > 0
                        && formFieldObject.MaxLength < formFieldObject.StringData.Length)
                    {
                        return new ValidationResult(Notices.FormFieldStringToLong);
                    }

                    if (formFieldObject.MinLength > 0
                        && formFieldObject.MinLength > formFieldObject.StringData.Length)
                    {
                        return new ValidationResult(Notices.FormFieldStringToShort);
                    }

                    break;
                case FieldTypes.number:
                    if(formFieldObject.MaxLength != formFieldObject.MinLength)
                    {
                        if (formFieldObject.MaxLength < formFieldObject.IntegerData)
                        {
                            return new ValidationResult(Notices.FormFieldIntergerDataToBig);
                        }

                        if (formFieldObject.MinLength > formFieldObject.IntegerData)
                        {
                            return new ValidationResult(Notices.FormFieldIntergerDataToSmall);
                        }
                    }

                    var theIntValue = value.ToString();
                    break;
            }

            return ValidationResult.Success;
        }
    }
}
