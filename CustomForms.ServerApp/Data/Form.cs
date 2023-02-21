namespace CustomForms.Data
{
    public class Form
    {
        public int Id { get; set; }
        public Guid UrlParameter { get; set; }
        public List<FormInputField> Fields { get; set; } = new List<FormInputField>();
    }
}
