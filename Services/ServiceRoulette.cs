using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Dto;
using ApiRouletteMasiv.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Services
{
    public class ServiceRoulette
    {
        private IRepositoryWrapper _repoWrapper;
        public ServiceRoulette(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<Roulette> NewRouletteAsync(Roulette roulette)
        {
            roulette.CloseAt = DateTime.UtcNow;
            _repoWrapper.Roulette.NewRoulette(roulette);
            await _repoWrapper.SaveAsync();

            return roulette;
        }

        public async Task<Roulette> GetRouletteByIdAsync(int Id)
        {
            return await _repoWrapper.Roulette.GetRouletteByIdAsync(Id);
        }

        public async Task<List<RouletteDto>> GetListRouletteAsync(string UserId)
        {
            List<RouletteDto> rouletteDtos = new List<RouletteDto>();
            var roulette = await _repoWrapper.Roulette.GetListRouletteAsync(UserId);
            foreach (var item in roulette)
            {
                RouletteDto rouletteDto = new RouletteDto();
                rouletteDto.Id = item.Id;
                rouletteDto.Status = item.Status;
                rouletteDto.OpenAt = item.OpenAt;
                rouletteDto.CloseAt = item.CloseAt;
                rouletteDtos.Add(rouletteDto);
            }

            return rouletteDtos;
        }
    }
}