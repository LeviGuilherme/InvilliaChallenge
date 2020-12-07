using System;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class UpdateAddressDto
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighbohood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
