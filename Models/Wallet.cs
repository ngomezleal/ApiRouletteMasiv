using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRouletteMasiv.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [Column(TypeName = "decimal(36,6)")]
        public decimal Total { get; set; }
        public DateTime Trace { get; set; }
    }
}