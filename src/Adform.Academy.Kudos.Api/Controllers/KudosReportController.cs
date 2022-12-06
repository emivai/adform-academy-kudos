using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Kudos.Api.Dtos;
using AutoMapper;
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

        [HttpGet]
        public async Task<IActionResult> Get(DateTime date)
        {
            var kudosReport = await _kudosReportService.GetAsync(date);

            return Ok(kudosReport);
        }
    }
}
