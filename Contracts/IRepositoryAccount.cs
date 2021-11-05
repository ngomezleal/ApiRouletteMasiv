using ApiRouletteMasiv.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Contracts
{
    public interface IRepositoryAccount
    {
        Task<IdentityResult> CreateAsync(ApplicationUser ApplicationUser);
        Task<SignInResult> PasswordSignInAsync(string UserName, string Password, bool isPersistent, bool lockoutOnFailure);
    }
}