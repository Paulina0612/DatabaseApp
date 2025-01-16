﻿using System;

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

