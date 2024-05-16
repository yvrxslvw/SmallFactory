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

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
