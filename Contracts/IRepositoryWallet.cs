using ApiRouletteMasiv.Models;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Contracts
{
    public interface IRepositoryWallet
    {
        Task<Wallet> GetWalletByIdAsync(int Id);
        Task<Wallet> GetWalletByUserIdAsync(string UserId);
        void CreateWallet(Wallet wallet);
        void UpdateWallet(Wallet wallet);
        void DeleteWallet(Wallet wallet);
    }
}
