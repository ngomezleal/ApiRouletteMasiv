using System;

namespace ApiRouletteMasiv.Models
{
    public class UserToken
    {
        public string token { get; set; }
        public DateTime Expiration { get; set; }
        public bool Status { get; set; }
    }
}
