using System.ComponentModel.DataAnnotations;

namespace CustomForms.Data
{
    public class BlankForm
    {
        [Key]
        public int Id { get; set; }
        [ValidateComplexType]
        public List<FormInputFieldDefinition> FormFields { get; set; } = new List<FormInputFieldDefinition>();
        public string FormDescription { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
