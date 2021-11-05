using System.Threading.Tasks;

namespace ApiRouletteMasiv.Contracts
{
    public interface IRepositoryWrapper
    {
        IRepositoryAccount Account { get; }
        IRepositoryRoulette Roulette { get; }

        Task SaveAsync();
    }
}
