using ApiRouletteMasiv.Dto;
using ApiRouletteMasiv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Contracts
{
    public interface IRepositoryRoulette
    {
        Task<Roulette> GetRouletteByIdAsync(int Id);
        Task<List<Roulette>> GetListRouletteAsync(string UserId);
        void NewRoulette(Roulette roulette);
    }
}