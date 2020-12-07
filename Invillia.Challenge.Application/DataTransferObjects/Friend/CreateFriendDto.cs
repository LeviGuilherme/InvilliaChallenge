using System.Collections.Generic;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class CreateFriendDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<CreatePhoneNumberDto> PhoneNumbers { get; set; }
        public virtual IEnumerable<CreateAddressDto> Addresses { get; set; }
    }
}
