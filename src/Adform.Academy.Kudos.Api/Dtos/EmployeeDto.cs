using System.ComponentModel.DataAnnotations;

namespace Adform.Academy.Kudos.Api.Dtos
{
    /// <summary>
    /// Data transfer object for employee
    /// </summary>
    public class EmployeeDto
    {
        /// <summary>
        /// Name of employee
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Surname of employee
        /// </summary>
        public string? Surname { get; set; }
    }
}
