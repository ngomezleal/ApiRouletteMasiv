using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Repository
{
    public class RepositoryRoulette : RepositoryBase<Roulette>, IRepositoryRoulette
    {
        public RepositoryRoulette(ApplicationDbContext repositoryContext)
          : base(repositoryContext)
        {
        }

        public void DeleteRoulette(Roulette roulette)
        {
            Delete(roulette);
        }

        public async Task<List<Roulette>> GetListRouletteAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Roulette> GetRouletteByIdAsync(int Id)
        {
            return await FindByCondition(r => r.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<Roulette> GetRouletteByIdAsync(int Id, string Status)
        {
            return await FindByCondition(r => r.Id.Equals(Id) && r.Status.Equals(Status)).FirstOrDefaultAsync();
        }

        public async Task<Roulette> GetRouletteByStatusAsync(string Status)
        {
            return await FindByCondition(r => r.Status.Equals(Status)).FirstOrDefaultAsync();
        }

        public void NewRoulette(Roulette roulette)
        {
            Create(roulette);
        }

        public void UpdateRoulette(Roulette roulette)
        {
            Update(roulette);
        }
    }
}