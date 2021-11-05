using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiRouletteMasiv.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration config)
        {
            //SqlServer
            var connectionStringSqlServer = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionStringSqlServer));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ServiceAccount, ServiceAccount>();
            services.AddScoped<ServiceRoulette, ServiceRoulette>();
        }
    }
}
