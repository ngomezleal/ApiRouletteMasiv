using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Dto;
using ApiRouletteMasiv.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
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

        public async Task<List<Roulette>> GetListRouletteAsync(string UserId)
        {
            return await FindByCondition(r => r.UserId.Equals(UserId)).ToListAsync();
        }

        public async Task<Roulette> GetRouletteByIdAsync(int Id)
        {
            return await FindByCondition(r => r.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public void NewRoulette(Roulette roulette)
        {
            Create(roulette);
        }
    }
}