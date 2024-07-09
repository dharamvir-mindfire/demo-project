using Microsoft.Extensions.Hosting;

namespace DemoProject.Services.CronJobs
{
    public class CronJobService : IHostedService, IDisposable
    {
        private Timer? _timer;
        private void DoWork(Object state)
        {
            Console.WriteLine("Cron job running at: " + DateTime.Now);
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new System.Threading.Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
