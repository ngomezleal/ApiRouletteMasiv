using ApiRouletteMasiv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Contracts
{
    public interface IRepositoryRoulette
    {
        Task<Roulette> GetRouletteByIdAsync(int Id);
        Task<Roulette> GetRouletteByIdAsync(int Id, string Status);
        Task<List<Roulette>> GetListRouletteAsync();
        Task<Roulette> GetRouletteByStatusAsync(string Status);
        void NewRoulette(Roulette roulette);
        void UpdateRoulette(Roulette roulette);
        void DeleteRoulette(Roulette roulette);
    }
}