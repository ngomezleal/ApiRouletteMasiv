using System.Threading.Tasks;

namespace ApiRouletteMasiv.Contracts
{
    public interface IRepositoryWrapper
    {
        IRepositoryAccount Account { get; }
        IRepositoryRoulette Roulette { get; }
        IRepositoryWallet Wallet { get; }
        IRepositoryBet Bet { get; }

        Task SaveAsync();
    }
}
