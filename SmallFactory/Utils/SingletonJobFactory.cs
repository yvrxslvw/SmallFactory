using Quartz;
using Quartz.Spi;

namespace SmallFactory.Utils
{
    public class SingletonJobFactory(IServiceProvider serviceProvider) : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (_serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob)!;
        }

        public void ReturnJob(IJob job) {}
    }
}
