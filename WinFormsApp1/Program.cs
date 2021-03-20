using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormHosting;

namespace WinFormsApp1
{
    static class Program
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// ����Ĭ��host��buider
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWinForm<MainForm>()
                .UseWinFormHostLifetime()
                .ConfigureServices(services =>
                {
                    services.AddHostedService<DispatcherHostedService>();
                    services.AddScoped<ScopeService>();
                    services.AddSingleton<SingletonService>();
                });
    }
}
