using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Dtos
{
    public class BlankFormDtoCreate
    {
        public List<FormInputFieldDefinitionDtoCreate> FormFieldDtos { get; set; } = new List<FormInputFieldDefinitionDtoCreate>();
        public string FormDescription { get; set; } = string.Empty;
    }
}
