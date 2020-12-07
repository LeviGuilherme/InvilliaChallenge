using Invillia.Challenge.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invillia.Challenge.Application.Interfaces
{
    public interface IGameLendService
    {
        Task<IEnumerable<GameLendDto>> GetListAsync();

        Task<GameLendDto> GetAsync(Guid id);

        Task<GameLendDto> CreateAsync(CreateGameLendDto input);

        Task UpdateAsync(Guid id, UpdateGameLendDto input);

        Task DeleteAsync(Guid id);
    }
}
