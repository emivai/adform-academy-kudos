using System.ComponentModel.DataAnnotations;

namespace Adform.Academy.Kudos.Api.Dtos
{
    public class EmployeeDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
    }
}
