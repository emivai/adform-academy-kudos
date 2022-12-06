namespace Adform.Academy.Core.Entities
{
    public class KudosReport
    {
        public Employee? SentMostKudos { get; set; }
        public Employee? ReceivedMostKudos { get; set; }

        public int? KudosCount { get; set; }
    }
}
