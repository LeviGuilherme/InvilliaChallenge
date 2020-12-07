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
    public class GameLendController : ControllerBase
    {
        private readonly IGameLendService _service;

        public GameLendController(IGameLendService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var gameLendList = await _service.GetListAsync();
            return Ok(gameLendList);
        }

        [HttpGet("{id}", Name = "GameLendById")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var game = await _service.GetAsync(id);
            return Ok(game);
        }

        [ModelValidationFilter]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateGameLendDto input)
        {
            var createdGame = await _service.CreateAsync(input);
            return CreatedAtRoute("GameLendById", new { id = createdGame.Id }, createdGame);
        }

        [ModelValidationFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateGameLendDto input)
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
