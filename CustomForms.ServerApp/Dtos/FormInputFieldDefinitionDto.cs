using CustomForms.Statics;

namespace CustomForms.ServerApp.Dtos
{
    public class FormInputFieldDefinitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        public string StringData { get; set; }
        public int IntegerData { get; set; }
        public int Order { get; set; } = 0;
        public FieldTypes FieldType { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
    }
}

// Maybe use a ctor to force initialization of FieldType...? cuz it's used in custom validatior.