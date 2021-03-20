using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class SingletonService
    {
        public void DoSomething()
        {
            MessageBox.Show(this.GetType().Name);
        }
    }
}
