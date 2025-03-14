
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DatabaseApp
{
    
    public class Program
    {
        public static int MAX = 10000000;

        public static SQLCommunicationHandler communicationHandler = new SQLCommunicationHandler();
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainLogInForm());
        }

        public static void IncorrectDataInformation()
        {
            MessageBox.Show("Incorrect data. Please try again.");
        }
    }
}
