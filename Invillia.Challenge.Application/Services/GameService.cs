using AutoMapper;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Application.Exceptions;
using Invillia.Challenge.Application.Interfaces;
using Invillia.Challenge.Domain.Entities.GamesAggregate;
using Invillia.Challenge.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace Invillia.Challenge.Application.Services
{
    public class GameService : BaseService, IGameService
    {
        private readonly ILogger<GameService> _logger;
        private readonly IGameRepository _gameRepository;

        public GameService(
            IGuidGenerator guidGenerator, 
            IMapper mapper,
            ILogger<GameService> logger,
            IGameRepository gameRepository) : base(guidGenerator, mapper)
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        public async Task<GameDto> CreateAsync(CreateGameDto input)
        {
            _logger.LogInformation("Trying to create a new game.");

            var gameEntity = Mapper.Map<Game>(input);
            gameEntity.Id = GuidGenerator.Create();
            await _gameRepository.AddAsync(gameEntity);
            var result = Mapper.Map<GameDto>(gameEntity);

            _logger.LogInformation("New game with id {0} created successfully.", gameEntity.Id);

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Trying to delete a game with id {0}.", id);

            var item = await _gameRepository.GetAsync(id);
            if (item == null) throw new ItemNotFoundException(id.ToString());
            _gameRepository.Remove(item);

            _logger.LogInformation("A game with id {0} was deleted successfully.", id);
        }

        public async Task<GameDto> GetAsync(Guid id)
        {
            _logger.LogInformation("Trying to retrieve a game with id {0}.", id);

            var item = await _gameRepository.GetAsync(id);
            if (item == null) throw new ItemNotFoundException(id.ToString());
            var result = Mapper.Map<GameDto>(item);

            _logger.LogInformation("A game with id {0} was retrieved successfully.", id);

            return result;
        }

        public async Task<IEnumerable<GameDto>> GetListAsync()
        {
            _logger.LogInformation("Trying to retrieve a list of all games.");

            var itemList = await _gameRepository.GetAllAsync();
            if (itemList == null) throw new ItemListNotFoundException();
            var result = Mapper.Map<IEnumerable<GameDto>>(itemList);

            _logger.LogInformation("A list of all games was retrieved successfully.");

            return result;
        }

        public async Task UpdateAsync(Guid id, UpdateGameDto input)
        {
            _logger.LogInformation("Trying to update a game with id {0}.", id);

            var entity = await _gameRepository.GetAsync(id);
            if (entity == null) throw new ItemNotFoundException(id.ToString());
            Mapper.Map(input, entity);
            _gameRepository.Update(entity);

            _logger.LogInformation("A game with id {0} was updated successfully.", id);
        }
    }
}
