using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zhao.Admin.Infrastructure.Datas;

namespace Zhao.Admin.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(a =>
            a.UseSqlServer(configuration.GetConnectionString("AppConnection")));
        }
    }
}