using CustomForms.ServerApp.Validators;
using CustomForms.Statics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomForms.Data
{
    public class FormInputFieldDefinition
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BlankForm")]
        public int BlankFormId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        [FormFieldValidator]
        public string StringData { get; set; } = string.Empty;
        public int IntegerData { get; set; }
        public int Order { get; set; } = 0;
        public FieldTypes FieldType { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
    }
}
