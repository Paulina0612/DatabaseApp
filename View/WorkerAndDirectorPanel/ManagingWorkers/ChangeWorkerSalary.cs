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
    public partial class ChangeWorkerSalary : Form
    {
        private List<ComboBoxItem> workers;

        public ChangeWorkerSalary()
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
            bool ifSalaryNumeric = float.TryParse(newSalaryTextBox.Text, out float newSalary);

            if (string.IsNullOrEmpty(newSalaryTextBox.Text) && ifSalaryNumeric) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = 
                    Program.communicationHandler.workersHandler.ChangeWorkerSalary(ComboBoxItem.GetIDByText(workerDataComboBox.Text), newSalary);
                if(ifSuccess)
                    MessageBox.Show("Salary successfully changed. ");
                else
                    MessageBox.Show("Salary could not be changed.");
            }
        }

        private void workerDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            currentSalaryTextBox.Text = 
                Program.communicationHandler.workersHandler.GetWorkerSalary(ComboBoxItem.GetIDByText(workerDataComboBox.Text)).ToString();
        }
    }
}
