using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class MainLogInForm : Forms
    {
        public MainLogInForm()
        {
            InitializeComponent();
        }

        private void LogInAsClientButton_Click(object sender, EventArgs e)
        {
            ClientLogInForm clientLogInForm = new ClientLogInForm();
            clientLogInForm.Show();
        }

        private void LogInAsWorkerButton_Click(object sender, EventArgs e)
        {
            WorkerLogInForm workerLogInForm = new WorkerLogInForm();
            workerLogInForm.Show();
        }

        private void RegisterClientButton_Click(object sender, EventArgs e)
        {
            ClientRegistration clientRegistration = new ClientRegistration();
            clientRegistration.Show();
        }

    }
}

// TODO: Mozliwe, ze bedzie mozna usunac wyszarzone usingi, ale to na koniec zostawiam, bo sie boje narazie xD
