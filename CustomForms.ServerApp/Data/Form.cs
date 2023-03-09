namespace CustomForms.Data
{
    public class Form
    {
        public int Id { get; set; }
        public List<FormInputField> FormFields { get; set; } = new List<FormInputField>();
    }
}
