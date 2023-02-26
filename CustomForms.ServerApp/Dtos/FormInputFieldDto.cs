using CustomForms.Statics;

namespace CustomForms.ServerApp.Dtos
{
    public class FormInputFieldDto
    {
        public int Id { get; set; }
        public string StringData { get; set; } = string.Empty;
        public int IntegerData { get; set; } = 0;
        public FieldTypes FieldType { get; set; }
        public string MaxLength { get; set; } = string.Empty;
        public string MinLength { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
    }
}
