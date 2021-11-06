using ApiRouletteMasiv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Contracts
{
    public interface IRepositoryBet
    {
        Task<Bet> GetBetByIdAsync(int Id);
        Task<List<Bet>> GetListBetRouletteIdAsync(int IdRoulette);
        void CreateBet(Bet bet);
        void UpdateBet(Bet bet);
        void DeleteBet(Bet bet);
    }
}
