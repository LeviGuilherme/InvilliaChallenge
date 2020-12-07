using System;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class GameDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string Version { get; set; }
        public decimal? PurchaseValue { get; set; }
    }
}
