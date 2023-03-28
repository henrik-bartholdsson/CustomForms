using CustomForms.Data;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Dtos
{
    public class BlankFormDto
    {
        public int Id { get; set; }
        [ValidateComplexType]
        public List<FormInputFieldDefinitionDto> FormFields { get; set; }
        public string FormDescription { get; set; } = string.Empty;
    }
}
