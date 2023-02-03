using Zhao.Admin.ApplicationCore.Interfaces;
using Zhao.Admin.ApplicationCore.Services;
using Zhao.Admin.Infrastructure.Datas;

namespace Zhao.Admin.WebApi.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
      IConfiguration configuration)
        {
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<ISampleService, SampleService>();


            return services;
        }
    }
}
