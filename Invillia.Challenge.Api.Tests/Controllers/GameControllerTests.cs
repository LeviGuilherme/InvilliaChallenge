using Invillia.Challenge.Api.Controllers.v1;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Invillia.Challenge.Api.Tests
{
    public class GameControllerTests
    {
        private readonly Mock<IGameService> _mockService;
        private readonly GameController _controller;

        public GameControllerTests()
        {
            _mockService = new Mock<IGameService>();
            _controller = new GameController(_mockService.Object);
        }

        [Fact]
        public async Task GetListAsync_ActionExecutes_ReturnsOkObjectResult()
        {
            var result = await _controller.GetListAsync();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetListAsync_ActionExecutes_ReturnsExactNumberOfGames()
        {
            _mockService.Setup(service => service.GetListAsync())
                .ReturnsAsync(new List<GameDto>() { new GameDto(), new GameDto() });

            var result = await _controller.GetListAsync();

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var Games = Assert.IsType<List<GameDto>>(actionResult.Value);
            Assert.Equal(2, Games.Count);
        }

        [Fact]
        public async Task GetAsync_ActionExecutes_ReturnsOkObjectResult()
        {
            var result = await _controller.GetAsync(new Guid());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAsync_ActionExecutes_ReturnsGameDto()
        {
            _mockService.Setup(service => service.GetAsync(It.IsAny<Guid>()))
               .ReturnsAsync(new GameDto());

            var result = await _controller.GetAsync(new Guid());

            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<GameDto>(actionResult.Value);
        }

        [Fact]
        public async Task PostAsync_ActionExecutes_ReturnsCreateAtRouteResultForCreate()
        {
            _mockService.Setup(service => service.CreateAsync(It.IsAny<CreateGameDto>()))
               .ReturnsAsync(new GameDto());

            var result = await _controller.PostAsync(new CreateGameDto());
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task PostAsync_ActionExecutes_CreateGameCalledOnce()
        {
            GameDto GameDto = null;
            _mockService.Setup(service => service.CreateAsync(It.IsAny<CreateGameDto>()))
               .Callback<CreateGameDto>(c =>
               {
                   GameDto = new GameDto()
                   {
                       Id = new Guid(),
                       Name = c.Name,
                       Description = c.Description,
                       ManufacturingDate = c.ManufacturingDate,
                       PurchaseValue = c.PurchaseValue,
                       Version = c.Version
                   };
               }).ReturnsAsync(() => GameDto);

            var createGameDto = new CreateGameDto()
            {
                Name = "Name",
                Description = "Description",
                ManufacturingDate = DateTime.MinValue,
                PurchaseValue = 100M,
                Version = "Version"
            };

            var result = await _controller.PostAsync(createGameDto);
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
            var createdResultValue = createdAtRouteResult.Value.As<GameDto>();

            _mockService.Verify(s => s.CreateAsync(It.IsAny<CreateGameDto>()), Times.Once);

            Assert.Equal(createdResultValue.Name, GameDto.Name);
            Assert.Equal(createdResultValue.Description, GameDto.Description);
            Assert.Equal(createdResultValue.ManufacturingDate, GameDto.ManufacturingDate);
            Assert.Equal(createdResultValue.PurchaseValue, GameDto.PurchaseValue);
            Assert.Equal(createdResultValue.Version, GameDto.Version);
        }

        [Fact]
        public async Task PutAsync_ActionExecutes_ReturnsNoContentResultForUpdate()
        {
            _mockService.Setup(service => service.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateGameDto>()));

            var result = await _controller.PutAsync(new Guid(), new UpdateGameDto());
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutAsync_ActionExecutes_UpdateGameCalledOnce()
        {
            bool updateExecuted = false;
            _mockService.Setup(service => service.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateGameDto>()))
               .Callback<Guid, UpdateGameDto>((g, u) => updateExecuted = true);

            var result = await _controller.PutAsync(new Guid(), new UpdateGameDto());
            var noContentResult = Assert.IsType<NoContentResult>(result);

            _mockService.Verify(s => s.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateGameDto>()), Times.Once);

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
        public async Task DeleteAsync_ActionExecutes_UpdateGameCalledOnce()
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
