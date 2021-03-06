using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRouletteMasiv.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public int IdRoulette { get; set; }
        public string UserId { get; set; }
        [Column(TypeName = "decimal(36,6)")]
        public decimal BetAmount { get; set; }

        [Column(TypeName = "decimal(36,6)")]
        public decimal Balance { get; set; }
        public string BetValue { get; set; }
        public string Status { get; set; }
        public DateTime Trace { get; set; }
    }
}