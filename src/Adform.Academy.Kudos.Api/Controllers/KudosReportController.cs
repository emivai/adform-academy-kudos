using Adform.Academy.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adform.Academy.Kudos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KudosReportController : ControllerBase
    {
        private readonly IKudosReportService _kudosReportService;

        public KudosReportController(IKudosReportService kudosReportService)
        {
            _kudosReportService = kudosReportService;
        }

        /// <summary>
        /// Generates report for inputted date containing employee that sent most kudos, employee that received most kudos and total kudos.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(DateTime date)
        {
            var kudosReport = await _kudosReportService.GetAsync(date);

            return Ok(kudosReport);
        }
    }
}
