using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Repository
{
    public class RepositoryBet : RepositoryBase<Bet>, IRepositoryBet
    {
        public RepositoryBet(ApplicationDbContext repositoryContext)
         : base(repositoryContext)
        {
        }
        public void DeleteBet(Bet bet)
        {
            Delete(bet);
        }

        public async Task<Bet> GetBetByIdAsync(int Id)
        {
            return await FindByCondition(b => b.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Bet>> GetListBetRouletteIdAsync(int IdRoulette)
        {
            return await FindByCondition(b => b.IdRoulette.Equals(IdRoulette)).ToListAsync();
        }

        public void CreateBet(Bet bet)
        {
            Create(bet);
        }

        public void UpdateBet(Bet bet)
        {
            Update(bet);
        }
    }
}