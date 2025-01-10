using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp
{
    // Class connecting GUI with SQLConnectionHandler
    internal class Program
    {
        private User user = User.NOONE;
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainLogInForm());
        }
    }
}
