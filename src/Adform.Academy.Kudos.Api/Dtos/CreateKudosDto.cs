using Adform.Academy.Core.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Adform.Academy.Kudos.Api.Dtos
{
    public class CreateKudosDto
    {
        [Required]
        public KudosReason Reason { get; set; }
        [Required]
        public string? Content { get; set; }

        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
    }
}
