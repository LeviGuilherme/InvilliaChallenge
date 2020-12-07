using Invillia.Challenge.Domain.Base;
using System;

namespace Invillia.Challenge.Domain.Entities.GamesAggregate
{
    public class Game : Entity<Guid>
    {
        protected Game() { }

        public Game(Guid id) : base(id) { }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string Version { get; set; }
        public decimal? PurchaseValue { get; set; }
        public bool Active { get; set; }

        public virtual GameLend GameLend { get; set; }
    }
}
