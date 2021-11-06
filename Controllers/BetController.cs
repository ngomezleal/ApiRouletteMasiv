using ApiRouletteMasiv.Models;
using ApiRouletteMasiv.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BetController : ControllerBase
    {
        private readonly ServiceBet _serviceBet;
        public BetController(ServiceBet serviceBet)
        {
            _serviceBet = serviceBet;
        }

        [HttpPost]
        [Route("StartBet")]
        public async Task<ActionResult> StartBet(BetParams bet)
        {
            var _claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var UserId = _claimsIdentity.FindFirst("UserId").Value;
            var result = await _serviceBet.StartBet(bet, UserId);
            return Ok(new { Status = result });
        }

        [HttpPost("CloseBet/{Id}")]
        public async Task<ActionResult> CloseBet(int Id)
        {
            var result = await _serviceBet.CloseBet(Id);
            return Ok(new { Results = result });
        }
    }
}
