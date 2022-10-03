using ComputerStore.Infastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerStore.Infastructure.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

            return services;
        }
    }
}
