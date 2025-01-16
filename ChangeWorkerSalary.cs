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
        public ChangeWorkerSalary()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifSalaryNumeric = float.TryParse(newSalaryTextBox.Text, out float newSalary);

            if (string.IsNullOrEmpty(newSalaryTextBox.Text) && ifSalaryNumeric) Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.ChangeWorkerSalary(workerDataComboBox.Text, newSalary);
                MessageBox.Show("Salary successfully changed. ");
            }
        }

        private void workerDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            currentSalaryTextBox.Text = Program.communicationHandler.GetWorkerSalary(workerDataComboBox.Text).ToString();
        }
    }
}
