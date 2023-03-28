using System.ComponentModel;

namespace CustomForms.Statics
{
    public enum FieldTypes
    {
        [Description(nameof(text))]
        text,
        number,
        radio,
    }
}
