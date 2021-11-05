using ApiRouletteMasiv.Dto;
using ApiRouletteMasiv.Models;
using ApiRouletteMasiv.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
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

        [HttpGet("{Id}", Name = "GetRoulette")]
        public async Task<ActionResult<Roulette>> Get(int Id)
        {
            return await _serviceRoulette.GetRouletteByIdAsync(Id);
        }

        [HttpPost]
        public async Task<ActionResult> NewRoulette()
        {
            Roulette roulette = new Roulette();
            roulette.UserId = "5b343259-78b8-4174-b5d4-10bf479bcefd";
            var result = await _serviceRoulette.NewRouletteAsync(roulette);
            return new CreatedAtRouteResult("GetRoulette", new { Id = result.Id }, result);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<RouletteDto>>> GetAll([FromQuery] string UserId)
        {
            return await _serviceRoulette.GetListRouletteAsync(UserId);
        }
    }
}