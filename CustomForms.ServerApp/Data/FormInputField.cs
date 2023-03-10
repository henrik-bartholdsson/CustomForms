using CustomForms.Statics;

namespace CustomForms.Data
{
    public class FormInputField
    {
        public int Id { get; set; }
        public string Data { get; set; } = string.Empty;
        public FieldTypes FieldType { get; set; }
        public string MaxLength { get; set; } = string.Empty;
        public string MinLength { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
    }
}
