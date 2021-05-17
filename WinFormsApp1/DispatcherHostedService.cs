using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    /// <summary>
    /// 后台任务调用MainForm
    /// </summary>
    class DispatcherHostedService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IWinFormDispatcher dispatcher;

        public DispatcherHostedService(IServiceProvider serviceProvider, IWinFormDispatcher dispatcher)
        {
            this.serviceProvider = serviceProvider;
            this.dispatcher = dispatcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mainform = this.serviceProvider.GetRequiredService<MainForm>();
            while (stoppingToken.IsCancellationRequested == false)
            {
                // dispatcher.SynchronizationContext.Post(callback);
                dispatcher.TryInvoke(() => mainform.Text = DateTime.Now.ToString());

                await Task.Delay(TimeSpan.FromSeconds(1d), stoppingToken);
            }
        }
    }
}
