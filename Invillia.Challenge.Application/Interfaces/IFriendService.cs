using Invillia.Challenge.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invillia.Challenge.Application.Interfaces
{
    public interface IFriendService
    {
        Task<IEnumerable<FriendDto>> GetListAsync();

        Task<FriendDto> GetAsync(Guid id);

        Task<FriendDto> CreateAsync(CreateFriendDto input);

        Task UpdateAsync(Guid id, UpdateFriendDto input);

        Task DeleteAsync(Guid id);
    }
}
