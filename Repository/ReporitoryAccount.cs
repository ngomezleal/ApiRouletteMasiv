using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Repository
{
    public class ReporitoryAccount : RepositoryBase<ApplicationUser>, IRepositoryAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ReporitoryAccount(ApplicationDbContext repositoryContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
            : base(repositoryContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser ApplicationUser)
        {
            return await _userManager.CreateAsync(ApplicationUser);
        }

        public async Task<SignInResult> PasswordSignInAsync(string UserName, string Password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(UserName, Password, isPersistent, lockoutOnFailure);
        }
    }
}