using CustomForms.Data;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Data
{
    public class Dispatch
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        [ValidateComplexType]
        public BlankForm BlankForm { get; set; }
        public int BlankFormId { get; set; }
        public int Status { get; set; }
    }
}
