using Adform.Academy.Core.Enumerators;

namespace Adform.Academy.Kudos.Api.Dtos
{
    public class CreateKudosDto
    {
        public KudosReason Reason { get; set; }
        public string? Content { get; set; }
        public bool Exchanged { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }
    }
}
