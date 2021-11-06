using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Repository
{
    public class RepositoryWallet : RepositoryBase<Wallet>, IRepositoryWallet
    {
        public RepositoryWallet(ApplicationDbContext repositoryContext)
          : base(repositoryContext)
        {
        }

        public void DeleteWallet(Wallet wallet)
        {
            Delete(wallet);
        }

        public async Task<Wallet> GetWalletByIdAsync(int Id)
        {
            return await FindByCondition(w => w.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<Wallet> GetWalletByUserIdAsync(string UserId)
        {
            return await FindByCondition(w => w.UserId.Equals(UserId)).FirstOrDefaultAsync();
        }

        public void CreateWallet(Wallet wallet)
        {
            Create(wallet);
        }

        public void UpdateWallet(Wallet wallet)
        {
            Update(wallet);
        }
    }
}
