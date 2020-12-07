using System;

namespace Invillia.Challenge.Application.DataTransferObjects
{
    public class UpdateGameDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string Version { get; set; }
        public decimal? PurchaseValue { get; set; }
    }
}
