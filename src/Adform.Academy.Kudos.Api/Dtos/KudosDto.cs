using Adform.Academy.Core.Entities;
using Adform.Academy.Core.Enumerators;

namespace Adform.Academy.Kudos.Api.Dtos
{
    /// <summary>
    /// Data tranfer object for kudos
    /// </summary>
    public class KudosDto
    {
        /// <summary>
        /// Time when kudos was created
        /// </summary>
        public DateTime Sent { get; set; }

        /// <summary>
        /// Reason for kudos, available: Team Player = 1 , Ownership Mindset = 2 , Technical Guidance = 3
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Free text
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Specified whether kudos is exchanged (True or False)
        /// </summary>
        public bool Exchanged { get; set; }

        /// <summary>
        /// Employee who sent this kudos
        /// </summary>
        public Employee? Sender { get; set; }

        /// <summary>
        /// Employee who received this kudos
        /// </summary>
        public Employee? Receiver { get; set; }
    }
}
