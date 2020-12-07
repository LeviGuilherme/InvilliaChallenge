using Invillia.Challenge.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invillia.Challenge.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetListAsync();

        Task<GameDto> GetAsync(Guid id);

        Task<GameDto> CreateAsync(CreateGameDto input);

        Task UpdateAsync(Guid id, UpdateGameDto input);

        Task DeleteAsync(Guid id);
    }
}
