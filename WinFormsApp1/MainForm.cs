using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormHosting;

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
