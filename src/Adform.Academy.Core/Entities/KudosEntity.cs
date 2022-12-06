using Adform.Academy.Core.Enumerators;

namespace Adform.Academy.Core.Entities
{
    public class KudosEntity
    {
        public int Id { get; set; }
        public DateTime Sent { get; set; }
        public KudosReason Reason { get; set; }
        public string? Content { get; set; }
        public bool Exchanged { get; set; }

        public Employee? Sender { get; set; }

        public Employee? Receiver { get; set; }
    }
}
