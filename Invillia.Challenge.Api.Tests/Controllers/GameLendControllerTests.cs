using Invillia.Challenge.Api.Controllers.v1;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Invillia.Challenge.Api.Tests
{
    public class GameLendControllerTests
    {
        private readonly Mock<IGameLendService> _mockService;
        private readonly GameLendController _controller;

        public GameLendControllerTests()
        {
            _mockService = new Mock<IGameLendService>();
            _controller = new GameLendController(_mockService.Object);
        }

        [Fact]
        public async Task GetListAsync_ActionExecutes_ReturnsOkObjectResult()
        {
            var result = await _controller.GetListAsync();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetListAsync_ActionExecutes_ReturnsExactNumberOfGameLends()
        {
            _mockService.Setup(service => service.GetListAsync())
                .ReturnsAsync(new List<GameLendDto>() { new GameLendDto(), new GameLendDto() });

            var result = await _controller.GetListAsync();

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var GameLends = Assert.IsType<List<GameLendDto>>(actionResult.Value);
            Assert.Equal(2, GameLends.Count);
        }

        [Fact]
        public async Task GetAsync_ActionExecutes_ReturnsOkObjectResult()
        {
            var result = await _controller.GetAsync(new Guid());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAsync_ActionExecutes_ReturnsGameLendDto()
        {
            _mockService.Setup(service => service.GetAsync(It.IsAny<Guid>()))
               .ReturnsAsync(new GameLendDto());

            var result = await _controller.GetAsync(new Guid());

            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<GameLendDto>(actionResult.Value);
        }

        [Fact]
        public async Task PostAsync_ActionExecutes_ReturnsCreateAtRouteResultForCreate()
        {
            _mockService.Setup(service => service.CreateAsync(It.IsAny<CreateGameLendDto>()))
               .ReturnsAsync(new GameLendDto());

            var result = await _controller.PostAsync(new CreateGameLendDto());
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task PostAsync_ActionExecutes_CreateGameLendCalledOnce()
        {
            GameLendDto gameLendDto = null;
            _mockService.Setup(service => service.CreateAsync(It.IsAny<CreateGameLendDto>()))
               .Callback<CreateGameLendDto>(c =>
               {
                   gameLendDto = new GameLendDto()
                   {
                       Id = new Guid(),
                       FriendId = new Guid(),
                       GameId = new Guid(),
                       LenddingDate = DateTime.MinValue
                   };
               }).ReturnsAsync(() => gameLendDto);

            var createGameLendDto = new CreateGameLendDto()
            {
                FriendId = new Guid(),
                GameId = new Guid(),
                LenddingDate = DateTime.MinValue
            };

            var result = await _controller.PostAsync(createGameLendDto);
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
            var createdResultValue = createdAtRouteResult.Value.As<GameLendDto>();

            _mockService.Verify(s => s.CreateAsync(It.IsAny<CreateGameLendDto>()), Times.Once);

            Assert.Equal(createdResultValue.FriendId, gameLendDto.FriendId);
            Assert.Equal(createdResultValue.GameId, gameLendDto.GameId);
            Assert.Equal(createdResultValue.LenddingDate, gameLendDto.LenddingDate);
        }

        [Fact]
        public async Task PutAsync_ActionExecutes_ReturnsNoContentResultForUpdate()
        {
            _mockService.Setup(service => service.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateGameLendDto>()));

            var result = await _controller.PutAsync(new Guid(), new UpdateGameLendDto());
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutAsync_ActionExecutes_UpdateGameLendCalledOnce()
        {
            bool updateExecuted = false;
            _mockService.Setup(service => service.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateGameLendDto>()))
               .Callback<Guid, UpdateGameLendDto>((g, u) => updateExecuted = true);

            var result = await _controller.PutAsync(new Guid(), new UpdateGameLendDto());
            var noContentResult = Assert.IsType<NoContentResult>(result);

            _mockService.Verify(s => s.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateGameLendDto>()), Times.Once);

            Assert.True(updateExecuted);
        }

        [Fact]
        public async Task DeleteAsync_ActionExecutes_ReturnsNoContentResultForDelete()
        {
            _mockService.Setup(service => service.DeleteAsync(It.IsAny<Guid>()));

            var result = await _controller.DeleteAsync(new Guid());
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ActionExecutes_UpdateGameLendCalledOnce()
        {
            bool deleteExecuted = false;
            _mockService.Setup(service => service.DeleteAsync(It.IsAny<Guid>()))
               .Callback<Guid>(g => deleteExecuted = true);

            var result = await _controller.DeleteAsync(new Guid());
            var noContentResult = Assert.IsType<NoContentResult>(result);

            _mockService.Verify(s => s.DeleteAsync(It.IsAny<Guid>()), Times.Once);

            Assert.True(deleteExecuted);
        }
    }
}
