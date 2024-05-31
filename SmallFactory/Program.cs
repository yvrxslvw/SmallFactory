using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.Interfaces;
using SmallFactory.Repositories;

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

            builder.Services.AddDbContext<FactoriesContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddDbContext<ProductionChainsContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddDbContext<MachinesContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddDbContext<ShopItemsContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddDbContext<PartsContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddDbContext<ReceiptsContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddDbContext<StoragesContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IFactoriesRepository, FactoriesRepository>();
            builder.Services.AddScoped<IProductionChainsRepository, ProductionChainsRepository>();
            builder.Services.AddScoped<IMachinesRepository, MachinesRepository>();
            builder.Services.AddScoped<IReceiptsRepository, ReceiptsRepository>();
            builder.Services.AddScoped<IPartsRepository, PartsRepository>();

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
