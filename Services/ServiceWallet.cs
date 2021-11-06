using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Models;
using System;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Services
{
    public class ServiceWallet
    {
        private IRepositoryWrapper _repoWrapper;
        public ServiceWallet(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<Wallet> CreateWalletAsync(Wallet wallet)
        {
            wallet.Trace = DateTime.UtcNow;
            _repoWrapper.Wallet.CreateWallet(wallet);
            await _repoWrapper.SaveAsync();

            return wallet;
        }
        public async Task<Wallet> GetWalletByIdAsync(int Id)
        {
            return await _repoWrapper.Wallet.GetWalletByIdAsync(Id);
        }
        public async Task<Wallet> GetWalletByUserIdAsync(string UserId)
        {
            return await _repoWrapper.Wallet.GetWalletByUserIdAsync(UserId);
        }
        public async Task<bool> UpdateWalletAsync(Wallet wallet)
        {
            try
            {
                var vWallet = await _repoWrapper.Wallet.GetWalletByIdAsync(wallet.Id);
                if (wallet != null)
                {
                    _repoWrapper.Wallet.UpdateWallet(wallet);
                    await _repoWrapper.SaveAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> DeleteWalletByIdAsync(int Id)
        {
            try
            {
                var wallet = new Wallet { Id = Id };
                _repoWrapper.Wallet.DeleteWallet(wallet);
                await _repoWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
