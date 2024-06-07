using Quartz;
using SmallFactory.Interfaces;

namespace SmallFactory.Tasks
{
    public class ManufacturingTask(IServiceScopeFactory serviceScopeFactory) : IJob
    {
        private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            IMachinesService machinesService = scope.ServiceProvider.GetRequiredService<IMachinesService>();
            await machinesService.Manufacturing();
        }
    }
}
