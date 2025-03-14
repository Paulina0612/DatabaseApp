using DatabaseApp.View.WorkerAndDirectorPanel.ManagingBooks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class WorkerPanel : Form
    {
        private List<ComboBoxItem> authors;
        private List<ComboBoxItem> genres;
        private List<ComboBoxItem> positions;
        private List<ComboBoxItem> managers;
        private List<ComboBoxItem> workers;

        private bool ifDirector = Program.communicationHandler.workersHandler.IfDirector();

        public WorkerPanel()
        {
            InitializeComponent();
            DisplayWorkerControls();
        }

        private void DisplayWorkerControls()
        {
            if (!ifDirector)
            {
                manageWorkersButton.Visible = false;
            }
            manageLabel.Visible = false;
            addWorkerButton.Visible = false;
            removeWorkerButton.Visible = false;
            changeSalaryButton.Visible = false;
            changeWorkersManagerButton.Visible = false;
            searchClientButton.Visible = false;
            payPenaltyButton.Visible = false;
            searchForBooksButton.Visible = false;
            lendBookButton.Visible = false;
            returnBookButton.Visible = false;
            addBookButton.Visible = false;
            removeBookButton.Visible = false;
            addGenreButton.Visible = false;
            addAuthorButton.Visible = false;
            ModeReset();
        }

        private void ModeReset()
        {
            modeLabel.Visible = false;
            clientCheckButton.Visible = false;
            clientEmailLabel.Visible = false;
            clientEmailTextBox.Visible = false;

            penaltyCommitButton.Visible = false;
            penaltyEmailTextBox.Visible = false;
            penaltyEmailLabel.Visible = false;

            authorCommitButton.Visible = false;
            authorLastNameTextBox.Visible = false;
            authorLastNameLabel.Visible = false;
            authorFirstNameTextBox.Visible = false;
            authorFirstNameLabel.Visible = false;

            bookAuthorDataComboBox.Visible = false;
            bookGenreComboBox.Visible = false;
            bookTitleTextBox.Visible = false;
            bookTitleLabel.Visible = false;
            bookAuthorLabel.Visible = false;
            bookGenreLabel.Visible = false;
            ISBNLabel.Visible = false;
            ISBNTextBox.Visible = false;
            titlesCatalogButton.Visible = false;
            addNewCopyButton.Visible = false;
            addNewTitleButton.Visible = false;
            addBookIDLabel.Visible = false;
            addBookIDTextBox.Visible = false;
            catalogButton.Visible = false;

            enterGenreNameLabel.Visible = false;
            genreNameTextBox.Visible = false;
            addGenreCommitButton.Visible = false;

            lendBookEmailLabel.Visible = false;
            lendBookEmailTextBox.Visible = false;
            lendBookIDLabel.Visible = false;
            lendBookIDTextBox.Visible = false;
            lendBookCommitButton.Visible = false;
            lendCatalogButton.Visible = false;

            removebookIDLabel.Visible = false;
            removeBookIDTextBox.Visible = false;
            removeCommitButton.Visible = false;

            returnBookIDLabel.Visible = false;
            returnBookIDTextBox.Visible = false;
            returnCommitButton.Visible = false;

            workerFirstNameLabel.Visible = false;
            workerFirstNameTextBox.Visible = false;
            workerLastNameLabel.Visible = false;
            workerLastNameTextBox.Visible = false;
            workerEmailLabel.Visible = false;
            workerEmailTextBox.Visible = false;
            phoneNumberLabel.Visible = false;
            workerPhoneNumberTextBox.Visible = false;
            salaryLabel.Visible = false;
            salaryTextBox.Visible = false;
            PESELLabel.Visible = false;
            PESELTextBox.Visible = false;
            workerCommitButton.Visible = false;
            positionLabel.Visible = false;
            positionComboBox.Visible = false;
            managerLabel.Visible = false;
            managerComboBox.Visible = false;

            workerDataLabel.Visible = false;
            workerDataComboBox.Visible = false;
            currentSalaryLabel.Visible = false;
            currentSalaryTextBox.Visible = false;
            newSalaryLabel.Visible = false;
            newSalaryTextBox.Visible = false;
            changeSalaryCommitButton.Visible = false;

            changeManagerCommitButton.Visible = false;
            changeManagerNewManagerComboBox.Visible = false;
            changeManagerNewManagerLabel.Visible = false;
            changeManagerWorkerComboBox.Visible = false;
            changeManagerWorkerLabel.Visible = false;

            removeWorkerCommitButton.Visible = false;
            removeWorkerComboBox.Visible = false;
            removeWorkerLabel.Visible = false;
        }

        private void searchClientButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Search client";
            clientCheckButton.Visible = true;
            clientEmailLabel.Visible = true;
            clientEmailTextBox.Visible = true;
        }

        private void payPenaltyButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Penalty payment";
            penaltyCommitButton.Visible = true;
            penaltyEmailTextBox.Visible = true;
            penaltyEmailLabel.Visible = true;
        }

        private void searchForBooksButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            BooksCatalog catalog = new BooksCatalog();
            catalog.Show();
        }

        private void lendBookButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Lend book";
            lendBookEmailLabel.Visible = true;
            lendBookEmailTextBox.Visible = true;
            lendBookIDLabel.Visible = true;
            lendBookIDTextBox.Visible = true;
            lendBookCommitButton.Visible = true;
            lendCatalogButton.Visible = true;
        }

        private void returnBookButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Return book";
            returnBookIDLabel.Visible = true;
            returnBookIDTextBox.Visible = true;
            returnCommitButton.Visible = true;
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Add book";
            bookAuthorDataComboBox.Visible = true;
            bookGenreComboBox.Visible = true;
            bookTitleTextBox.Visible = true;
            bookTitleLabel.Visible = true;
            bookAuthorLabel.Visible = true;
            bookGenreLabel.Visible = true;
            ISBNLabel.Visible = true;
            ISBNTextBox.Visible = true;
            titlesCatalogButton.Visible = true;
            addNewCopyButton.Visible = true;
            addNewTitleButton.Visible = true;
            addBookIDLabel.Visible = true;
            addBookIDTextBox.Visible = true;
            catalogButton.Visible = true;
            LoadAuthors();
            LoadGenres();
        }

        private void removeBookButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Remove book";
            removebookIDLabel.Visible = true;
            removeBookIDTextBox.Visible = true;
            removeCommitButton.Visible = true;
        }

        private void addGenreButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Add genre";
            enterGenreNameLabel.Visible = true;
            genreNameTextBox.Visible = true;
            addGenreCommitButton.Visible = true;
        }

        private void addAuthorButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Add author";
            authorCommitButton.Visible = true;
            authorLastNameTextBox.Visible = true;
            authorLastNameLabel.Visible = true;
            authorFirstNameTextBox.Visible = true;
            authorFirstNameLabel.Visible = true;
        }

        private void manageClientsButton_Click(object sender, EventArgs e)
        {
            DisplayWorkerControls();
            manageLabel.Visible = true;
            manageLabel.Text = "Manage clients";
            searchClientButton.Visible = true;
            payPenaltyButton.Visible = true;
        }

        private void manageBooksButton_Click(object sender, EventArgs e)
        {
            DisplayWorkerControls();
            manageLabel.Visible = true;
            manageLabel.Text = "Manage books";
            searchForBooksButton.Visible = true;
            lendBookButton.Visible = true;
            returnBookButton.Visible = true;
            addBookButton.Visible = true;
            removeBookButton.Visible = true;
            addGenreButton.Visible = true;
            addAuthorButton.Visible = true;
        }

        private void manageWorkersButton_Click(object sender, EventArgs e)
        {
            DisplayWorkerControls();
            manageLabel.Visible = true;
            manageLabel.Text = "Manage workers";
            addWorkerButton.Visible = true;
            removeWorkerButton.Visible = true;
            changeSalaryButton.Visible = true;
            changeWorkersManagerButton.Visible = true;
        }

        private void addWorkerButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Add worker";
            workerFirstNameLabel.Visible = true;
            workerFirstNameTextBox.Visible = true;
            workerLastNameLabel.Visible = true;
            workerLastNameTextBox.Visible = true;
            workerEmailLabel.Visible = true;
            workerEmailTextBox.Visible = true;
            phoneNumberLabel.Visible = true;
            workerPhoneNumberTextBox.Visible = true;
            salaryLabel.Visible = true;
            salaryTextBox.Visible = true;
            PESELLabel.Visible = true;
            PESELTextBox.Visible = true;
            workerCommitButton.Visible = true;
            positionLabel.Visible = true;
            positionComboBox.Visible = true;
            managerLabel.Visible = true;
            managerComboBox.Visible = true;
            LoadPositions();
            LoadManagers();
        }

        private void LoadPositions()
        {
            positionComboBox.Items.Clear();
            positions = Program.communicationHandler.workersHandler.GetPositions();
            foreach (ComboBoxItem position in positions)
            {
                positionComboBox.Items.Add(position.ID + " " + position.Text);
            }
        }

        private void LoadManagers()
        {
            managerComboBox.Items.Clear();
            managers = Program.communicationHandler.workersHandler.GetAllWorkersData();
            foreach (ComboBoxItem manager in managers)
            {
                managerComboBox.Items.Add(manager.ID + " " + manager.Text);
            }
        }

        private void removeWorkerButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Remove worker";
            removeWorkerCommitButton.Visible = true;
            removeWorkerComboBox.Visible = true;
            removeWorkerLabel.Visible = true;
            LoadWorkersData();
        }

        private void LoadWorkersData()
        {
            removeWorkerComboBox.Items.Clear();
            workers = Program.communicationHandler.workersHandler.GetAllWorkersData();
            foreach (ComboBoxItem worker in workers)
            {
                removeWorkerComboBox.Items.Add(worker.ID + " " + worker.Text);
            }
        }

        private void changeSalaryButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Change salary";
            workerDataLabel.Visible = true;
            workerDataComboBox.Visible = true;
            currentSalaryLabel.Visible = true;
            currentSalaryTextBox.Visible = true;
            newSalaryLabel.Visible = true;
            newSalaryTextBox.Visible = true;
            changeSalaryCommitButton.Visible = true;
            LoadWorkersData1();
        }

        private void LoadWorkersData1()
        {
            workerDataComboBox.Items.Clear();
            workers = Program.communicationHandler.workersHandler.GetAllWorkersData();
            foreach (ComboBoxItem worker in workers)
            {
                workerDataComboBox.Items.Add(worker.ID + " " + worker.Text);
            }
        }
        private void workerDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSalaryTextBox.Text =
                Program.communicationHandler.workersHandler.GetWorkerSalary(ComboBoxItem.GetIDByText(workerDataComboBox.Text)).ToString();
        }

        private void changeWorkersManagerButton_Click(object sender, EventArgs e)
        {
            ModeReset();
            modeLabel.Visible = true;
            modeLabel.Text = "Change worker's manager";
            changeManagerCommitButton.Visible = true;
            changeManagerNewManagerComboBox.Visible = true;
            changeManagerNewManagerLabel.Visible = true;
            changeManagerWorkerComboBox.Visible = true;
            changeManagerWorkerLabel.Visible = true;
            LoadData();
        }

        private void LoadData()
        {
            changeManagerWorkerComboBox.Items.Clear();
            changeManagerNewManagerComboBox.Items.Clear();
            workers = Program.communicationHandler.workersHandler.GetAllWorkersData();
            foreach (ComboBoxItem worker in workers)
            {
                changeManagerWorkerComboBox.Items.Add(worker.ID + " " + worker.Text);
                changeManagerNewManagerComboBox.Items.Add(worker.ID + " " + worker.Text);
            }
        }

        private void clientCheckButton_Click(object sender, EventArgs e)
        {
            ClientData clientData = Program.communicationHandler.clientsHandler.GetClientData(
                Program.communicationHandler.clientsHandler.GetClientID(clientEmailTextBox.Text));
            bool ifClientRegistered = clientData.getEmail() != null ? true : false;

            if (string.IsNullOrEmpty(clientEmailTextBox.Text)) Program.IncorrectDataInformation();
            else if (ifClientRegistered)
            {
                MessageBox.Show(
                    "Client data: \nID: " + clientData.getID() + "\n"
                    + "Name: " + clientData.getFirstName() + " " + clientData.getLastName() + "\n"
                    + "E-mail: " + clientData.getEmail() + "\n"
                    + "Penalty: " + clientData.getPenalty() + " zl\n"
                    );

            }
            else MessageBox.Show("Client is not registered in database.");
        }

        private void penaltyCommitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(penaltyEmailTextBox.Text) &&
                Program.communicationHandler.clientsHandler.GetClientData(
                    Program.communicationHandler.clientsHandler.GetClientID(
                        penaltyEmailTextBox.Text)).getEmail() != null)
                Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.clientsHandler.PenaltyPayment(
                    penaltyEmailTextBox.Text);
                if (ifSuccess) MessageBox.Show("Operation successful.");
                else MessageBox.Show("Operation failed.");
            }
        }

        private void authorCommitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(authorFirstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(authorLastNameTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccessful = Program.communicationHandler.authorsHandler.AddAuthor(
                    authorFirstNameTextBox.Text, authorLastNameTextBox.Text);

                if (ifSuccessful)
                    MessageBox.Show("Author successfully added. ");
                else
                    MessageBox.Show("Error adding the author.");
            }
        }

        private void LoadAuthors()
        {
            bookAuthorDataComboBox.Items.Clear();
            authors = Program.communicationHandler.authorsHandler.GetAuthors();
            foreach (ComboBoxItem author in authors)
            {
                bookAuthorDataComboBox.Items.Add(author.ID + " " + author.Text);
            }
        }

        private void LoadGenres()
        {
            bookGenreComboBox.Items.Clear();
            genres = Program.communicationHandler.genresHandler.GetGenres();
            foreach (ComboBoxItem genre in genres)
            {
                bookGenreComboBox.Items.Add(genre.ID + " " + genre.Text);
            }
        }

        private void addNewTitleButton_Click(object sender, EventArgs e)
        {
            bool ifISBNNumeric = int.TryParse(ISBNTextBox.Text, out int n);

            if (string.IsNullOrEmpty(bookTitleTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(bookAuthorDataComboBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(ISBNTextBox.Text) && ifISBNNumeric && ISBNTextBox.Text.Length != 13)
                Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(bookGenreComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.booksHandler.AddNewTitle(bookTitleTextBox.Text,
                    ComboBoxItem.GetIDByText(bookAuthorDataComboBox.Text), ISBNTextBox.Text,
                    ComboBoxItem.GetIDByText(bookGenreComboBox.Text));

                if (ifSuccess)
                    MessageBox.Show("Title added successfully.");
                else
                    MessageBox.Show("Title not added.");
            }
        }

        private void addNewCopyButton_Click(object sender, EventArgs e)
        {
            bool ifIDNumeric = int.TryParse(addBookIDTextBox.Text, out int n);

            if (string.IsNullOrEmpty(addBookIDTextBox.Text) && !ifIDNumeric) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.booksHandler.AddNewCopy(ComboBoxItem.GetIDByText(addBookIDTextBox.Text));

                if (ifSuccess)
                    MessageBox.Show("Copy added successfully.");
                else
                    MessageBox.Show("Copy not added.");
            }
        }

        private void titlesCatalogButton_Click(object sender, EventArgs e)
        {
            TitlesCatalog titlesCatalog = new TitlesCatalog();
            titlesCatalog.Show();
        }

        private void catalogButton_Click(object sender, EventArgs e)
        {
            BooksCatalog catalog = new BooksCatalog();
            catalog.Show();
        }

        private void addGenreCommitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(genreNameTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.genresHandler.AddGenre(genreNameTextBox.Text);
                MessageBox.Show("Genre successfully added.");
            }
        }

        private void lendBookCommitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lendBookEmailTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(lendBookIDTextBox.Text)) Program.IncorrectDataInformation();
            else if (!Program.communicationHandler.booksHandler.IsBookAvailable(int.Parse(lendBookIDTextBox.Text)))
                MessageBox.Show("Book is not available");
            else
            {
                bool ifSuccess =
                    Program.communicationHandler.booksHandler.LendBook(lendBookEmailTextBox.Text, int.Parse(lendBookIDTextBox.Text));

                if (ifSuccess) MessageBox.Show("Book lent successfully");
                else MessageBox.Show("Error lending the book");
            }
        }

        private void removeCommitButton_Click(object sender, EventArgs e)
        {
            bool ifIDNumeric = int.TryParse(removeBookIDTextBox.Text, out int id);

            if (ifIDNumeric && string.IsNullOrEmpty(removeBookIDTextBox.Text) && 
                !Program.communicationHandler.booksHandler.IsBookInDatabase(id))
                Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.booksHandler.RemoveBook(id);
                MessageBox.Show("Book succcessfully removed.");
            }
        }

        private void returnCommitButton_Click(object sender, EventArgs e)
        {
            bool ifBookIDNumeric = int.TryParse(returnBookIDTextBox.Text, out int bookID);

            if (!ifBookIDNumeric) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.booksHandler.ReturnBook(bookID);

                if (ifSuccess) MessageBox.Show("Book returned successfully");
                else MessageBox.Show("Error returning the book");
            }
        }

        private void workerCommitButton_Click(object sender, EventArgs e)
        {
            bool ifPhoneNumberNumeric = int.TryParse(workerPhoneNumberTextBox.Text, out int n);
            bool ifPESELNumeric = long.TryParse(PESELTextBox.Text, out _); // Zmiana z int na long by naprawić problem z długością
            bool ifSalaryNumeric = float.TryParse(salaryTextBox.Text, out float m);

            // Generating password
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 8; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            string password = sb.ToString();

            if (string.IsNullOrEmpty(workerFirstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(workerLastNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(workerPhoneNumberTextBox.Text) 
                && ifPhoneNumberNumeric && workerPhoneNumberTextBox.Text.Length != 9)
                Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(workerEmailTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(PESELTextBox.Text) && ifPESELNumeric && PESELTextBox.Text.Length != 11)
                Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(salaryTextBox.Text) && ifSalaryNumeric) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(positionComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                try
                {
                    bool ifSuccess = Program.communicationHandler.workersHandler.AddWorker(workerFirstNameTextBox.Text, workerLastNameTextBox.Text, workerPhoneNumberTextBox.Text,
                        workerEmailTextBox.Text, PESELTextBox.Text, float.Parse(salaryTextBox.Text), ComboBoxItem.GetIDByText(managerComboBox.Text),
                        ComboBoxItem.GetIDByText(positionComboBox.Text), password);
                    if (ifSuccess)
                        MessageBox.Show("Worker successfully added.\nGenerated password is: " + password);
                    else
                        MessageBox.Show("Adding worker failed.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding worker: {ex.Message}");
                }

            }
        }

        private void changeSalaryCommitButton_Click(object sender, EventArgs e)
        {
            bool ifSalaryNumeric = float.TryParse(newSalaryTextBox.Text, out float newSalary);

            if (string.IsNullOrEmpty(newSalaryTextBox.Text) && ifSalaryNumeric) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess =
                    Program.communicationHandler.workersHandler.ChangeWorkerSalary(ComboBoxItem.GetIDByText(workerDataComboBox.Text), newSalary);
                if (ifSuccess)
                    MessageBox.Show("Salary successfully changed. ");
                else
                    MessageBox.Show("Salary could not be changed.");
            }
        }

        private void changeManagerCommitButton_Click(object sender, EventArgs e)
        {
            if (changeManagerWorkerComboBox.SelectedItem == null ||
                changeManagerNewManagerComboBox.SelectedItem == null) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.workersHandler.ChangeWorkersManager(
                    ComboBoxItem.GetIDByText(changeManagerWorkerComboBox.SelectedItem.ToString()),
                    ComboBoxItem.GetIDByText(changeManagerNewManagerComboBox.SelectedItem.ToString()));

                if (ifSuccess)
                    MessageBox.Show("Worker's manager successfully changed.");
                else
                    MessageBox.Show("Worker's manager could not be changed.");
            }
        }

        private void removeWorkerCommitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(removeWorkerComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.workersHandler.RemoveWorker(ComboBoxItem.GetIDByText(removeWorkerComboBox.Text));
                if (ifSuccess)
                    MessageBox.Show("Worker successfully removed.");
                else
                    MessageBox.Show("Worker could not be removed.");
            }
            LoadWorkersData();
        }
    }
}
