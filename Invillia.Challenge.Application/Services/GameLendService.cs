using AutoMapper;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Application.Exceptions;
using Invillia.Challenge.Application.Interfaces;
using Invillia.Challenge.Domain.Entities;
using Invillia.Challenge.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace Invillia.Challenge.Application.Services
{
    public class GameLendService : BaseService, IGameLendService
    {
        private readonly ILogger<GameLendService> _logger;
        private readonly IGameLendRepository _gameLendRepository;

        public GameLendService(
            IGuidGenerator guidGenerator, 
            IMapper mapper,
            ILogger<GameLendService> logger,
            IGameLendRepository gameLendRepository) : base(guidGenerator, mapper)
        {
            _logger = logger;
            _gameLendRepository = gameLendRepository;
        }

        public async Task<GameLendDto> CreateAsync(CreateGameLendDto input)
        {
            _logger.LogInformation("Trying to associate a friend with a game.");

            var gameLendEntity = Mapper.Map<GameLend>(input);
            gameLendEntity.Id = GuidGenerator.Create();
            await _gameLendRepository.AddAsync(gameLendEntity);
            var result = Mapper.Map<GameLendDto>(gameLendEntity);

            _logger.LogInformation("New association between friend and game with id {0} was created successfully.", gameLendEntity.Id);

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Trying to delete an association between friend and game with id {0}.", id);

            var item = await _gameLendRepository.GetAsync(id);
            if (item == null) throw new ItemNotFoundException(id.ToString());
            _gameLendRepository.Remove(item);

            _logger.LogInformation("An association between friend and game with id {0} was deleted successfully.", id);
        }

        public async Task<GameLendDto> GetAsync(Guid id)
        {
            _logger.LogInformation("Trying to retrieve an association between friend and game with id {0}.", id);

            var item = await _gameLendRepository.GetAsync(id);
            if (item == null) throw new ItemNotFoundException(id.ToString());
            var result = Mapper.Map<GameLendDto>(item);

            _logger.LogInformation("An association between friend and game with id {0} was retrieved successfully.", id);

            return result;
        }

        public async Task<IEnumerable<GameLendDto>> GetListAsync()
        {
            _logger.LogInformation("Trying to retrieve a list of all associtations between friends and games.");

            var itemList = await _gameLendRepository.GetAllAsync();
            if (itemList == null) throw new ItemListNotFoundException();
            var result = Mapper.Map<IEnumerable<GameLendDto>>(itemList);

            _logger.LogInformation("A list of all associtations between friends and games was retrieved successfully.");

            return result;
        }

        public async Task UpdateAsync(Guid id, UpdateGameLendDto input)
        {
            _logger.LogInformation("Trying to update an association between friend and game with id {0}.", id);

            var entity = await _gameLendRepository.GetAsync(id);
            if (entity == null) throw new ItemNotFoundException(id.ToString());
            Mapper.Map(input, entity);
            _gameLendRepository.Update(entity);

            _logger.LogInformation("An association between friend and game with id {0} was updated successfully.", id);
        }
    }
}
