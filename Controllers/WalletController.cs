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
    public class WalletController : ControllerBase
    {
        private readonly ServiceWallet _serviceWallet;

        public WalletController(ServiceWallet serviceWallet)
        {
            _serviceWallet = serviceWallet;
        }

        [HttpGet("{Id}", Name = "GetWallet")]
        public async Task<ActionResult<Wallet>> Get(int Id)
        {
            return await _serviceWallet.GetWalletByIdAsync(Id);
        }


        [HttpPost]
        [Route("CreateWallet")]
        public async Task<ActionResult> CreateWallet(Wallet wallet)
        {
            var _claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            wallet.UserId = _claimsIdentity.FindFirst("UserId").Value;
            var result = await _serviceWallet.CreateWalletAsync(wallet);

            return new CreatedAtRouteResult("GetWallet", new { Id = result.Id }, result);
        }
    }
}