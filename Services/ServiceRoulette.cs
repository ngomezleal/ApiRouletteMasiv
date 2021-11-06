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

        public async Task<List<Roulette>> GetListRouletteAsync()
        {
            return await _repoWrapper.Roulette.GetListRouletteAsync();
        }
        public async Task<Roulette> NewRouletteAsync(Roulette roulette)
        {
            roulette.Trace = DateTime.UtcNow;
            _repoWrapper.Roulette.NewRoulette(roulette);
            await _repoWrapper.SaveAsync();

            return roulette;
        }
        public async Task<string> OpenRouletteAsync(int Id)
        {
            var roulette = await _repoWrapper.Roulette.GetRouletteByIdAsync(Id);
            if (roulette != null)
            {
                roulette.Status = Miscellaneous.RouletteStatus.Open.ToString();
                roulette.OpenAt = DateTime.UtcNow;
                _repoWrapper.Roulette.UpdateRoulette(roulette);
                await _repoWrapper.SaveAsync();
                return Miscellaneous.RouletteStatus.Success.ToString();
            }
            else
                return Miscellaneous.RouletteStatus.Denied.ToString();
        }
    }
}