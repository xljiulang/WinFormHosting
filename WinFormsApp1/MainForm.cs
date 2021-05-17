using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly SingletonService singletonService;

        public MainForm(IServiceScopeFactory scopeFactory, SingletonService singletonService)
        {
            this.scopeFactory = scopeFactory;
            this.singletonService = singletonService;

            this.InitializeComponent();
        }


        private void DoInScope()
        {
            using var scope = this.scopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ScopeService>();
            service.DoSomething();
        }

    }
}
