using CustomForms.Statics;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Data
{
    public class FormInputFieldAnswer
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }
        public int Order { get; set; } = 0;
        public FieldTypes FieldType { get; set; }
    }
}
