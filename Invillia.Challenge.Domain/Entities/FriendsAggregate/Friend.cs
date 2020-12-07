using Invillia.Challenge.Domain.Base;
using System;
using System.Collections.Generic;

namespace Invillia.Challenge.Domain.Entities.FriendsAggregate
{
    public class Friend : Entity<Guid>
    {
        protected Friend() { }

        public Friend(Guid id) : base(id) { }

        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual GameLend GameLend { get; set; }
    }
}
