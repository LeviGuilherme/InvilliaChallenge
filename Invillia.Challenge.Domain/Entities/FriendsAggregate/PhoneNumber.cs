
using Invillia.Challenge.Domain.Base;
using System;

namespace Invillia.Challenge.Domain.Entities.FriendsAggregate
{
    public class PhoneNumber : Entity<Guid>
    {
        protected PhoneNumber() { }

        public PhoneNumber(Guid id) : base(id) { }

        public string WhatsApp { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }
        public bool Active { get; set; }

        public virtual Guid FriendId { get; set; }
        public virtual Friend Friend { get; set; }
    }
}
