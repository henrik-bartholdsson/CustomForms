namespace CustomForms.ServerApp.Dtos
{
    public class Dispatch
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public int FormId { get; set; }
        public bool Sent { get; set; }
    }
}
