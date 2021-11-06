using System;

namespace ApiRouletteMasiv.Dto
{
    public class BetDto
    {
        public int Id { get; set; }
        public int IdRoulette { get; set; }
        public decimal BetAmount { get; set; }
        public string BetValue { get; set; }
        public string Status { get; set; }
        public DateTime Trace { get; set; }
    }
}
