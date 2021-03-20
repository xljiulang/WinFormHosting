using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormHosting;

namespace WinFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 创建默认host的buider
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
