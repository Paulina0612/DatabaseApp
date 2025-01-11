using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class RemoveWorker : Forms
    {
        public RemoveWorker()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workerDataComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                communicationHandler.RemoveWorker(workerDataComboBox.Text);
                MessageBox.Show("Worker successfully removed.");
            }
        }
    }
}
