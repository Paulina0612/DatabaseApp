using System;
using System.Web;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DatabaseApp
{
    public partial class AddWorker : Form
    {
        private List<ComboBoxItem> positions;
        private List<ComboBoxItem> managers;

        public AddWorker()
        {
            InitializeComponent();
            LoadPositions();
            LoadManagers();
        }

        private void LoadPositions()
        {
            positionComboBox.Items.Clear();
            positions = Program.communicationHandler.workersHandler.GetPositions();
            foreach (ComboBoxItem position in positions)
            {
                positionComboBox.Items.Add(position.ID + position.Text);
            }
        }

        private void LoadManagers()
        {
            managerComboBox.Items.Clear();
            managers = Program.communicationHandler.workersHandler.GetManagers();
            foreach (ComboBoxItem manager in managers)
            {
                managerComboBox.Items.Add(manager.ID + manager.Text);
            }
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifPhoneNumberNumeric = int.TryParse(phoneNumberTextBox.Text, out int n);
            bool ifPESELNumeric = long.TryParse(PESELTextBox.Text, out _); // Zmiana z int na long by naprawić problem z długością
            bool ifSalaryNumeric = float.TryParse(salaryTextBox.Text, out float m);

            // Generating password
            //string password = System.Web.Security.
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 8; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            string password = sb.ToString();

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
                try
                {
                    bool ifSuccess = Program.communicationHandler.workersHandler.AddWorker(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text,
                        emailTextBox.Text, PESELTextBox.Text, float.Parse(salaryTextBox.Text), ComboBoxItem.GetIDByText(managerComboBox.Text),
                        ComboBoxItem.GetIDByText(positionComboBox.Text), password);
                    if (ifSuccess)
                        MessageBox.Show("Worker successfully added.\nGenerated password is: " + password);
                    else
                        MessageBox.Show("Adding worker failed.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error adding worker: {ex.Message}");
                }

            }
        }
    }
}
