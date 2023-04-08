using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Dtos
{
    public class BlankFormDtoCreate
    {
        public List<FormInputFieldDefinitionDtoCreate> FormFields { get; set; }
        public string FormDescription { get; set; } = string.Empty;
    }
}
