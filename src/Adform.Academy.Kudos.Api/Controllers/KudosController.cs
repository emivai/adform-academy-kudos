using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Core.Entities;
using Adform.Academy.Kudos.Api.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Adform.Academy.Kudos.Api.Controllers
{
    /// <summary>
    /// Controller for kudos operations (creation, retrieval, update).
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class KudosController : ControllerBase
    {
        private readonly IKudosService _kudosService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Kudos controller constructor
        /// </summary>
        /// <param name="kudosService"></param>
        /// <param name="mapper"></param>
        public KudosController(IKudosService kudosService, IMapper mapper)
        {
            _kudosService = kudosService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates new kudos entry.
        /// </summary>
        /// <param name="kudosDto"></param>
        /// <returns>Kudos created.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateKudosDto kudosDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var kudos = _mapper.Map<KudosEntity>(kudosDto);

            var id = await _kudosService.AddAsync(kudos, kudosDto.SenderId, kudosDto.ReceiverId);

            return Created($"/api/kudos/{id}", kudosDto);
        }

        /// <summary>
        /// Gets all kudos.
        /// </summary>
        /// <returns>Kudos list.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var kudos = await _kudosService.GetAsync();

            return Ok(_mapper.Map<List<KudosDto>>(kudos));
        }

        /// <summary>
        /// Updates kudos with selected id as exchanged.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204 if successful.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id)
        {
            await _kudosService.UpdateAsync(id);
            return NoContent();
        }
    }
}
