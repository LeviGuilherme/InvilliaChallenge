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
    public class FriendControllerTests
    {
        private readonly Mock<IFriendService> _mockService;
        private readonly FriendController _controller;

        public FriendControllerTests()
        {
            _mockService = new Mock<IFriendService>();
            _controller = new FriendController(_mockService.Object);
        }

        [Fact]
        public async Task GetListAsync_ActionExecutes_ReturnsOkObjectResult()
        {
            var result = await _controller.GetListAsync();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetListAsync_ActionExecutes_ReturnsExactNumberOfFriends()
        {
            _mockService.Setup(service => service.GetListAsync())
                .ReturnsAsync(new List<FriendDto>() { new FriendDto(), new FriendDto() });

            var result = await _controller.GetListAsync();

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var friends = Assert.IsType<List<FriendDto>>(actionResult.Value);
            Assert.Equal(2, friends.Count);
        }

        [Fact]
        public async Task GetAsync_ActionExecutes_ReturnsOkObjectResult()
        {
            var result = await _controller.GetAsync(new Guid());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAsync_ActionExecutes_ReturnsFriendDto()
        {
            _mockService.Setup(service => service.GetAsync(It.IsAny<Guid>()))
               .ReturnsAsync(new FriendDto());

            var result = await _controller.GetAsync(new Guid());

            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<FriendDto>(actionResult.Value);
        }

        [Fact]
        public async Task PostAsync_ActionExecutes_ReturnsCreateAtRouteResultForCreate()
        {
            _mockService.Setup(service => service.CreateAsync(It.IsAny<CreateFriendDto>()))
               .ReturnsAsync(new FriendDto());

            var result = await _controller.PostAsync(new CreateFriendDto());
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task PostAsync_ActionExecutes_CreateFriendCalledOnce()
        {
            FriendDto friendDto = null;
            _mockService.Setup(service => service.CreateAsync(It.IsAny<CreateFriendDto>()))
               .Callback<CreateFriendDto>(f =>
               {
                   friendDto = new FriendDto()
                   {
                       Id = new Guid(),
                       Email = f.Email,
                       Name = f.Name,
                       Addresses = f.Addresses.Select(a => new AddressDto()
                       {
                           Id = new Guid(),
                           City = a.City,
                           Country = a.Country,
                           Neighbohood = a.Neighbohood,
                           Number = a.Number,
                           PostalCode = a.PostalCode,
                           State = a.State,
                           Street = a.Street
                       }),
                       PhoneNumbers = f.PhoneNumbers.Select(p => new PhoneNumberDto()
                       {
                           Id = new Guid(),
                           LandLine = p.LandLine,
                           Mobile = p.Mobile,
                           WhatsApp = p.WhatsApp
                       })
                   };
               }).ReturnsAsync(() => friendDto);

            var createFriendDto = new CreateFriendDto()
            {
                Addresses = new List<CreateAddressDto>()
                {
                    new CreateAddressDto()
                    {
                        City = "City",
                        Country = "Country",
                        Neighbohood = "Neighbohood",
                        Number = "Number",
                        PostalCode = "PostalCode",
                        State = "State",
                        Street = "Street"
                    }
                },
                Email = "Email",
                Name = "Name",
                PhoneNumbers = new List<CreatePhoneNumberDto>()
                {
                    new CreatePhoneNumberDto()
                    {
                        LandLine = "LandLine",
                        Mobile = "Mobile",
                        WhatsApp = "WhatsApp"
                    }
                }
            };

            var result = await _controller.PostAsync(createFriendDto);
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
            var createdResultValue = createdAtRouteResult.Value.As<FriendDto>();

            _mockService.Verify(s => s.CreateAsync(It.IsAny<CreateFriendDto>()), Times.Once);

            Assert.Equal(createdResultValue.Email, friendDto.Email);
            Assert.Equal(createdResultValue.Name, friendDto.Name);
            Assert.True(createdResultValue.Addresses.Equals(friendDto.Addresses));
            Assert.True(createdResultValue.PhoneNumbers.Equals(friendDto.PhoneNumbers));
        }

        [Fact]
        public async Task PutAsync_ActionExecutes_ReturnsNoContentResultForUpdate()
        {
            _mockService.Setup(service => service.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateFriendDto>()));

            var result = await _controller.PutAsync(new Guid(), new UpdateFriendDto());
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutAsync_ActionExecutes_UpdateFriendCalledOnce()
        {
            bool updateExecuted = false;
            _mockService.Setup(service => service.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateFriendDto>()))
               .Callback<Guid, UpdateFriendDto>((g, u) => updateExecuted = true);

            var result = await _controller.PutAsync(new Guid(), new UpdateFriendDto());
            var noContentResult = Assert.IsType<NoContentResult>(result);

            _mockService.Verify(s => s.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateFriendDto>()), Times.Once);

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
        public async Task DeleteAsync_ActionExecutes_UpdateFriendCalledOnce()
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
