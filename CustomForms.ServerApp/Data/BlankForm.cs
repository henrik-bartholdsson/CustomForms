namespace CustomForms.Data
{
    public class BlankForm
    {
        public int Id { get; set; } = 0;
        public List<FormInputField> FormFields { get; set; } = new List<FormInputField>();
    }
}
