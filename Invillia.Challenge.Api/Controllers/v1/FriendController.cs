using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Application.Interfaces;
using Invillia.Challenge.CrossCutting.IoC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invillia.Challenge.Api.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _service;

        public FriendController(IFriendService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetListAsync()
        {
            var friendList = await _service.GetListAsync();
            return Ok(friendList);
        }

        [HttpGet("{id}", Name = "FriendById")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var friend = await _service.GetAsync(id);
            return Ok(friend);
        }

        [ModelValidationFilter]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateFriendDto input)
        {
            var createdFriend = await _service.CreateAsync(input);
            return CreatedAtRoute("FriendById", new { id = createdFriend.Id }, createdFriend);
        }

        [ModelValidationFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateFriendDto input)
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
