using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Application.Interfaces;
using Invillia.Challenge.CrossCutting.IoC.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invillia.Challenge.Api.Controllers.v1
{
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var gameList = await _service.GetListAsync();
            return Ok(gameList);
        }

        [HttpGet("{id}", Name = "GameById")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var game = await _service.GetAsync(id);
            return Ok(game);
        }

        [ModelValidationFilter]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateGameDto input)
        {
            var createdGame = await _service.CreateAsync(input);
            return CreatedAtRoute("GameById", new { id = createdGame.Id }, createdGame);
        }

        [ModelValidationFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateGameDto input)
        {
            await _service.UpdateAsync(id, input);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
