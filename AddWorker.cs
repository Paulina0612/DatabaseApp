using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class AddWorker : Forms
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifPhoneNumberNumeric = int.TryParse(phoneNumberTextBox.Text, out int n);
            bool ifPESELNumeric = int.TryParse(PESELTextBox.Text, out n);
            bool ifSalaryNumeric = float.TryParse(salaryTextBox.Text, out float m);

            if (string.IsNullOrEmpty(firstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(lastNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(phoneNumberTextBox.Text) && ifPhoneNumberNumeric && phoneNumberTextBox.Text.Length != 9)
                Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(emailTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(PESELTextBox.Text) && ifPESELNumeric && PESELTextBox.Text.Length != 11)
                Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(salaryTextBox.Text) && ifSalaryNumeric) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(positionComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                communicationHandler.AddWorker(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text, 
                    emailTextBox.Text, PESELTextBox.Text, float.Parse(salaryTextBox.Text), managerComboBox.Text, 
                    positionComboBox.Text);
                MessageBox.Show("Worker successfully added. ");
            }
        }
    }
}
