using System;

namespace ApiRouletteMasiv.Models
{
    public class Roulette
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public DateTime? OpenAt { get; set; }
        public DateTime? CloseAt { get; set; }
        public DateTime Trace { get; set; }
    }
}