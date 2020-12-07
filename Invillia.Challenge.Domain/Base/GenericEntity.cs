using Invillia.Challenge.Domain.EntityContracts;

namespace Invillia.Challenge.Domain.Base
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        protected Entity()
        {

        }

        public Entity(TKey id)
        {
            Id = id;
        }
    }
}
