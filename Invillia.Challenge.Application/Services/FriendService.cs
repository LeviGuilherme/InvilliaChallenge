using AutoMapper;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Application.Exceptions;
using Invillia.Challenge.Application.Interfaces;
using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace Invillia.Challenge.Application.Services
{
    public class FriendService : BaseService, IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly IFriendRepository _friendRepository;

        public FriendService(
            IGuidGenerator guidGenerator, 
            IMapper mapper,
            ILogger<FriendService> logger,
            IFriendRepository friendRepository) : base(guidGenerator, mapper)
        {
            _logger = logger;
            _friendRepository = friendRepository;
        }

        public async Task<FriendDto> CreateAsync(CreateFriendDto input)
        {
            _logger.LogInformation("Trying to create a new friend.");

            var friendEntity = Mapper.Map<Friend>(input);
            friendEntity.Id = GuidGenerator.Create();
            await _friendRepository.AddAsync(friendEntity);
            var result = Mapper.Map<FriendDto>(friendEntity);

            _logger.LogInformation("New friend with id {0} created successfully.", friendEntity.Id);

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Trying to delete a friend with id {0}.", id);

            var item = await _friendRepository.GetAsync(id);
            if (item == null) throw new ItemNotFoundException(id.ToString());
            _friendRepository.Remove(item);

            _logger.LogInformation("A friend with id {0} was deleted successfully.", id);
        }

        public async Task<FriendDto> GetAsync(Guid id)
        {
            _logger.LogInformation("Trying to retrieve a friend with id {0}.", id);

            var item = await _friendRepository.GetAsync(id);
            if (item == null) throw new ItemNotFoundException(id.ToString());
            var result = Mapper.Map<FriendDto>(item);

            _logger.LogInformation("A friend with id {0} was retrieved successfully.", id);

            return result;
        }

        public async Task<IEnumerable<FriendDto>> GetListAsync()
        {
            _logger.LogInformation("Trying to retrieve a list of all friends.");

            var itemList = await _friendRepository.GetAllAsync();
            if (itemList == null) throw new ItemListNotFoundException();
            var result = Mapper.Map<IEnumerable<FriendDto>>(itemList);

            _logger.LogInformation("A list of all friends was retrieved successfully.");

            return result;
        }

        public async Task UpdateAsync(Guid id, UpdateFriendDto input)
        {
            _logger.LogInformation("Trying to update a friend with id {0}.", id);

            var entity = await _friendRepository.GetAsync(id);
            if (entity == null) throw new ItemNotFoundException(id.ToString());
            Mapper.Map(input, entity);
            _friendRepository.Update(entity);

            _logger.LogInformation("A friend with id {0} was updated successfully.", id);
        }
    }
}
