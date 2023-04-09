using CustomForms.Data;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Data
{
    public class Dispatch
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        [ValidateComplexType]
        public BlankForm BlankForm { get; set; } = new BlankForm();
        public List<FormInputFieldAnswer> Answers { get; set; } = new List<FormInputFieldAnswer>();
        public int BlankFormId { get; set; }
        public int Status { get; set; }
    }
}
