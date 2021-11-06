using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Services
{
    public class ServiceAccount
    {
        private IRepositoryWrapper _repoWrapper;
        private readonly IConfiguration _configuration;
        public ServiceAccount(IRepositoryWrapper repoWrapper, IConfiguration configuration)
        {
            _repoWrapper = repoWrapper;
            _configuration = configuration;
        }

        public async Task<UserToken> CreateUserAsync(UserInfo userInfo)
        {
            var user = new ApplicationUser { UserName = userInfo.Email, Email = userInfo.Email };
            var result = await _repoWrapper.Account.CreateAsync(user, userInfo.Password);
            if (result.Succeeded)
            {
                var appUser = await _repoWrapper.Account.FindByEmailAsync(userInfo.Email);
                return await BuildToken(userInfo, appUser);
            }
            else
                return new UserToken();
        }
        public async Task<UserToken> LoginUserAsync(UserInfo userInfo)
        {
            var result = await _repoWrapper.Account.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var appUser = await _repoWrapper.Account.FindByEmailAsync(userInfo.Email);
                return await BuildToken(userInfo, appUser);
            }
            else
                return new UserToken();
        }
        private async Task<UserToken> BuildToken(UserInfo userInfo, ApplicationUser user)
        {
            try
            {
                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                    new Claim(ClaimTypes.Name, userInfo.Email),
                    new Claim("UserId", $"{user.Id}"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Token expiration time. In our case we do it for an hour.
                var expiration = DateTime.UtcNow.AddHours(1);
                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: "domain.com",
                   audience: "domain.com",
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds);

                return new UserToken()
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration,
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new UserToken();
            }
        }
    }
}