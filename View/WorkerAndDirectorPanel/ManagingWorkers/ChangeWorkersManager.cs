using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp.View.WorkerAndDirectorPanel.ManagingWorkers
{
    public partial class ChangeWorkersManager : Form
    {
        private List<ComboBoxItem> workers;

        public ChangeWorkersManager()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            workerComboBox.Items.Clear();
            managerComboBox.Items.Clear();
            workers = Program.communicationHandler.workersHandler.GetAllWorkersData();
            foreach (ComboBoxItem worker in workers)
            {
                workerComboBox.Items.Add(worker.ID + " " + worker.Text);
                managerComboBox.Items.Add(worker.ID + " " + worker.Text);
            }
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (workerComboBox.SelectedItem == null ||
                managerComboBox.SelectedItem == null) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.workersHandler.ChangeWorkersManager(
                    ComboBoxItem.GetIDByText(workerComboBox.SelectedItem.ToString()),
                    ComboBoxItem.GetIDByText(managerComboBox.SelectedItem.ToString()));

                if (ifSuccess)
                    MessageBox.Show("Worker's manager successfully changed.");
                else
                    MessageBox.Show("Worker's manager could not be changed.");
            }
        }
    }
}
