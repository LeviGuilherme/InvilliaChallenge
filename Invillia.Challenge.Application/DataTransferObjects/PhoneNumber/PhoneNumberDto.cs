using System;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class PhoneNumberDto
    {
        public Guid Id { get; set; }

        public string WhatsApp { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }
    }
}
