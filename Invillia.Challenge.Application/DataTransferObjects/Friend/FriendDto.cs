using System;
using System.Collections.Generic;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class FriendDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<PhoneNumberDto> PhoneNumbers { get; set; }
        public virtual IEnumerable<AddressDto> Addresses { get; set; }
    }
}
