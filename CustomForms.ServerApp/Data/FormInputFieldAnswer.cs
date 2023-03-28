using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomForms.ServerApp.Data
{
    public class FormInputFieldAnswer
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }
        [ForeignKey("Dispatch")]
        public Guid DispatchId { get; set; }
    }
}
