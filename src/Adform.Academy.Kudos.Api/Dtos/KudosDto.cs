using Adform.Academy.Core.Entities;
using Adform.Academy.Core.Enumerators;

namespace Adform.Academy.Kudos.Api.Dtos
{
    public class KudosDto
    {
        public DateTime Sent { get; set; }
        public string? Reason { get; set; }
        public string? Content { get; set; }
        public bool Exchanged { get; set; }

        public Employee? Sender { get; set; }

        public Employee? Receiver { get; set; }
    }
}
