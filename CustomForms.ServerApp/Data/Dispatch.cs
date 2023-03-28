using CustomForms.Data;
using CustomForms.ServerApp.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
