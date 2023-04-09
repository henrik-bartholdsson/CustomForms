using CustomForms.Data;
using System.ComponentModel.DataAnnotations;

namespace CustomForms.ServerApp.Dtos
{
    public class DispatchDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        [ValidateComplexType]
        public BlankFormDtoCreate BlankFormDto { get; set; } = new BlankFormDtoCreate();
        public int BlankFormId { get; set; }
        public int Status { get; set; }
    }
}
