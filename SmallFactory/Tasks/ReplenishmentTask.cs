using Quartz;
using SmallFactory.Interfaces;

namespace SmallFactory.Tasks
{
    public class ReplenishmentTask(IServiceScopeFactory serviceScopeFactory) : IJob
    {
        private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            IShopService shopService = scope.ServiceProvider.GetRequiredService<IShopService>();
            await shopService.ReplenishmentAsync();
        }
    }
}
