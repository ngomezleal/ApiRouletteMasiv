using ApiRouletteMasiv.Dto;
using System.Collections.Generic;

namespace ApiRouletteMasiv.Models
{
    public class BetResult
    {
        public string Status { get; set; }
        public List<BetDto> Bets { get; set; }
    }
}