using System.Collections.Generic;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class UpdateFriendDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<PhoneNumberDto> PhoneNumbers { get; set; }
        public virtual IEnumerable<AddressDto> Addresses { get; set; }
    }
}
