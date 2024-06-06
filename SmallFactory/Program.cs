using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.Interfaces;
using SmallFactory.Repositories;
using SmallFactory.Services;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using SmallFactory.Utils;
using SmallFactory.Tasks;
using SmallFactory.Models;

namespace SmallFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string? connectionString = builder.Configuration.GetConnectionString("SmallFactory");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Не все поля в конфигурации приложения заполнены.");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IFactoriesRepository, FactoriesRepository>();
            builder.Services.AddScoped<IProductionChainsRepository, ProductionChainsRepository>();
            builder.Services.AddScoped<IMachinesRepository, MachinesRepository>();
            builder.Services.AddScoped<IReceiptsRepository, ReceiptsRepository>();
            builder.Services.AddScoped<IPartsRepository, PartsRepository>();
            builder.Services.AddScoped<IStoragesRepository, StoragesRepository>();
            builder.Services.AddScoped<IShopItemsRepository, ShopItemsRepository>();

            builder.Services.AddTransient<IShopService, ShopService>();

            builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
            builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            builder.Services.AddSingleton<ReplenishmentTask>();
            builder.Services.AddSingleton(new JobSchedule(
                jobType: typeof(ReplenishmentTask),
                cronExpression: "0/30 * * * * ?"));

            builder.Services.AddHostedService<QuartzHostedService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
