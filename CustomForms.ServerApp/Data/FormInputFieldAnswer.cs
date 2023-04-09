using CustomForms.Data;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Data
{
    public class FormInputFieldAnswer
    {
        [Key]
        public int Id { get; set; }
        public int FieldDefinitionId { get; set; }
        public string StringData { get; set; } = string.Empty;
        public int IntegerData { get; set; }
        public Guid DispatchId { get; set; }
    }
}
