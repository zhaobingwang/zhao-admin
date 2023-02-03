
using Zhao.Admin.ApplicationCore.Interfaces;
using Zhao.Admin.Infrastructure.Datas;
using Zhao.Admin.WebApi.Configuration;

namespace Zhao.Admin.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Infrastructure²ãµÄÒÀÀµ×¢Èë
            Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            // Core Service ×¢Èë
            builder.Services.AddCoreServices(builder.Configuration);

            // AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}