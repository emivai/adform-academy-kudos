using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Core.Entities;
using Adform.Academy.Kudos.Api.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Adform.Academy.Kudos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KudosController : ControllerBase
    {
        private readonly IKudosService _kudosService;
        private readonly IMapper _mapper;

        public KudosController(IKudosService kudosService, IMapper mapper)
        {
            _kudosService = kudosService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateKudosDto kudosDto)
        {
            var kudos = _mapper.Map<KudosEntity>(kudosDto);

            var id = await _kudosService.AddAsync(kudos, kudosDto.SenderId, kudosDto.ReceiverId);

            return Created($"/api/kudos/{id}", kudosDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var kudos = await _kudosService.GetAsync();

            return Ok(_mapper.Map<List<KudosDto>>(kudos));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            await _kudosService.UpdateAsync(id);
            return Ok();
        }
    }
}
