using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Dto
{
    public class RouletteDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? OpenAt { get; set; }
        public DateTime? CloseAt { get; set; }
    }
}