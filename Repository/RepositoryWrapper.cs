using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private ApplicationDbContext _repoContext;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private IRepositoryAccount _account;
        private IRepositoryRoulette _roulette;
        private IRepositoryWallet _wallet;
        private IRepositoryBet _bet;

        public RepositoryWrapper(ApplicationDbContext repositoryContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _repoContext = repositoryContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IRepositoryAccount Account
        {
            get
            {
                if (_account == null)
                    _account = new ReporitoryAccount(_repoContext, _userManager, _signInManager);
                return _account;
            }
        }

        public IRepositoryRoulette Roulette
        {
            get 
            {
                if (_roulette == null)
                    _roulette = new RepositoryRoulette(_repoContext);
                return _roulette;
            }
        }

        public IRepositoryWallet Wallet
        {
            get
            {
                if (_wallet== null)
                    _wallet = new RepositoryWallet(_repoContext);
                return _wallet;
            }
        }

        public IRepositoryBet Bet
        {
            get
            {
                if (_bet == null)
                    _bet = new RepositoryBet(_repoContext);
                return _bet;
            }
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
