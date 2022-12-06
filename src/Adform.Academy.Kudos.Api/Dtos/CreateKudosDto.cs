using Adform.Academy.Core.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Adform.Academy.Kudos.Api.Dtos
{
    /// <summary>
    /// Data transfer object for creating new kudos
    /// </summary>
    public class CreateKudosDto
    {
        /// <summary>
        /// Reason for kudos, available: Team Player = 1 , Ownership Mindset = 2 , Technical Guidance = 3
        /// </summary>
        public KudosReason? Reason { get; set; }

        /// <summary>
        /// Free text
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Id of employee who sent this kudos
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// Id of employee who received this kudos
        /// </summary>
        public int ReceiverId { get; set; }
    }
}
