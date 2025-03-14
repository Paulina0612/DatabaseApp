using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class RemoveWorker : Form
    {
        private List<ComboBoxItem> workers;

        public RemoveWorker()
        {
            InitializeComponent();
            LoadWorkersData();
        }

        private void LoadWorkersData()
        {
            workerDataComboBox.Items.Clear();
            workers = Program.communicationHandler.workersHandler.GetAllWorkersData();
            foreach (ComboBoxItem worker in workers)
            {
                workerDataComboBox.Items.Add(worker.ID + " " + worker.Text);
            }
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workerDataComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.workersHandler.RemoveWorker(ComboBoxItem.GetIDByText(workerDataComboBox.Text));
                if(ifSuccess)
                    MessageBox.Show("Worker successfully removed.");
                else
                    MessageBox.Show("Worker could not be removed.");
            }
            LoadWorkersData();
        }

        private void workerDataLabel_Click(object sender, EventArgs e)
        {

        }

        private void workerDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
