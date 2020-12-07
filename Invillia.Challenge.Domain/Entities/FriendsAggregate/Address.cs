
using Invillia.Challenge.Domain.Base;
using System;

namespace Invillia.Challenge.Domain.Entities.FriendsAggregate
{
    public class Address : Entity<Guid>
    {
        protected Address() { }

        public Address(Guid id) : base(id) { }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighbohood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool Active { get; set; }

        public virtual Guid FriendId { get; set; }
        public virtual Friend Friend { get; set; }
    }
}
