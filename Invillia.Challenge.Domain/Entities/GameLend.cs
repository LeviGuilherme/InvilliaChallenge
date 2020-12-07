using Invillia.Challenge.Domain.Base;
using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.Entities.GamesAggregate;
using System;

namespace Invillia.Challenge.Domain.Entities
{
    public class GameLend : Entity<Guid>
    {
        protected GameLend() { }

        public GameLend(Guid id) : base(id) { }

        public DateTime LenddingDate { get; set; }
        public bool Active { get; set; }

        public Guid FriendId { get; set; }
        public virtual Friend Friend { get; set; }

        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
