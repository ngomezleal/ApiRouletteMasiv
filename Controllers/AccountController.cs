using ApiRouletteMasiv.Models;
using ApiRouletteMasiv.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ServiceAccount _serviceAccount;
        public AccountController(ServiceAccount serviceAccount)
        {
            _serviceAccount = serviceAccount;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var result = await _serviceAccount.CreateUserAsync(model);
            if (result.Status)
                return result;
            else
                return BadRequest("Username or password invalid");
        }
    }
}