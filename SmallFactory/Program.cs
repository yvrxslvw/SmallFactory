using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using SmallFactory.Data;
using SmallFactory.Interfaces;
using SmallFactory.Models;
using SmallFactory.Repositories;
using SmallFactory.Services;
using SmallFactory.Tasks;
using SmallFactory.Utils;

namespace SmallFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string? connectionString = builder.Configuration.GetConnectionString("SmallFactory");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("�� ��� ���� � ������������ ���������� ���������.");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IFactoriesRepository, FactoriesRepository>();
            builder.Services.AddScoped<IProductionChainsRepository, ProductionChainsRepository>();
            builder.Services.AddScoped<IMachinesRepository, MachinesRepository>();
            builder.Services.AddScoped<IReceiptsRepository, ReceiptsRepository>();
            builder.Services.AddScoped<IPartsRepository, PartsRepository>();
            builder.Services.AddScoped<IStoragesRepository, StoragesRepository>();
            builder.Services.AddScoped<IShopItemsRepository, ShopItemsRepository>();

            builder.Services.AddTransient<IShopService, ShopService>();
            builder.Services.AddTransient<IMachinesService, MachinesService>();

            builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
            builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            builder.Services.AddSingleton<ReplenishmentTask>();
            builder.Services.AddSingleton(new JobSchedule(
                jobType: typeof(ReplenishmentTask),
                cronExpression: "0/30 * * * * ?"));
            builder.Services.AddSingleton<ManufacturingTask>();
            builder.Services.AddSingleton(new JobSchedule(
                jobType: typeof(ManufacturingTask),
                cronExpression: "0/1 * * * * ?"));

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
