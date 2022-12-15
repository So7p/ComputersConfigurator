using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ComputerStore.Application.IoC
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IComputerService, ComputerService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IModelService, ModelService>();
        }
    }
}
