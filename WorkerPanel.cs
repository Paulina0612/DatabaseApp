using System;

namespace DatabaseApp
{
    public partial class WorkerPanel : Forms
    {
        public WorkerPanel()
        {
            InitializeComponent();
        }

        private void searchClientButton_Click(object sender, EventArgs e)
        {
            SearchingClient searchingClient = new SearchingClient();
            searchingClient.Show();
        }

        private void payPenaltyButton_Click(object sender, EventArgs e)
        {
            PenaltyPayment payment = new PenaltyPayment();
            payment.Show();
        }

        private void searchForBooksButton_Click(object sender, EventArgs e)
        {
            BooksCatalog catalog = new BooksCatalog();
            catalog.Show();
        }

        private void lendBookButton_Click(object sender, EventArgs e)
        {
            LendBook book = new LendBook();
            book.Show();
        }

        private void returnBookButton_Click(object sender, EventArgs e)
        {
            ReturnBook book = new ReturnBook();
            book.Show();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            AddBook book = new AddBook();   
            book.Show();
        }

        private void removeBookButton_Click(object sender, EventArgs e)
        {
            RemoveBook book = new RemoveBook();
            book.Show();
        }

        private void addGenreButton_Click(object sender, EventArgs e)
        {
            AddGenre book = new AddGenre();
            book.Show();
        }

        private void removeGenreButton_Click(object sender, EventArgs e)
        {
            RemoveGenre book = new RemoveGenre();
            book.Show();
        }

        private void addAuthorButton_Click(object sender, EventArgs e)
        {
            AddAuthor book = new AddAuthor();
            book.Show();
        }

        private void removeAuthorButton_Click(object sender, EventArgs e)
        {
            RemoveAuthor removeAuthor = new RemoveAuthor();
            removeAuthor.Show();
        }

    }
}
