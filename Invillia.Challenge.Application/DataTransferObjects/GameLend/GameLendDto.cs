using System;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class GameLendDto
    {
        public Guid Id { get; set; }
        public DateTime LenddingDate { get; set; }
        public Guid FriendId { get; set; }
        public Guid GameId { get; set; }
    }
}
