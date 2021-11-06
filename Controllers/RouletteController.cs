using ApiRouletteMasiv.Models;
using ApiRouletteMasiv.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RouletteController : ControllerBase
    {
        private readonly ServiceRoulette _serviceRoulette;
        public RouletteController(ServiceRoulette serviceRoulette)
        {
            _serviceRoulette = serviceRoulette;
        }

        [HttpGet]
        [Route("GetAllRoulette")]
        public async Task<ActionResult<List<Roulette>>> GetAllRoulette()
        {
            var roulletes = await _serviceRoulette.GetListRouletteAsync();
            return Ok(new { Roulettes = roulletes });
        }

        [HttpPost]
        [Route("NewRoulette")]
        public async Task<ActionResult> NewRoulette()
        {
            Roulette roulette = new Roulette();
            var result = await _serviceRoulette.NewRouletteAsync(roulette);

            return Ok(new { IdRoulette = result.Id });
        }

        [HttpPut("OpenRoulette/{Id}")]
        public async Task<ActionResult> OpenRoulette(int Id)
        {
            var result = await _serviceRoulette.OpenRouletteAsync(Id);
            return Ok(new { Status = result });
        }
    }
}