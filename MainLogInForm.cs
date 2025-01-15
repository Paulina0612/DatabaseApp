using System;

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

        private void button1_Click(object sender, EventArgs e)
        {
            communicationHandler.AddWorker("Paulina", "Bartczak", "123456789", "poijhgffgyu", "12345678901", 4000, "Paulina", "asd", "wsedrtgyh");
        }
    }
}

