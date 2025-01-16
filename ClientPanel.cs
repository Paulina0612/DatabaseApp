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
    public partial class ClientPanel : Form
    {
        private int clientId;
        public ClientPanel()
        {
            InitializeComponent();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            History historyForm = new History();

            List<BookData> history = Program.communicationHandler.GetHistory();
            //TODO:Uzupelnic tabele w formatce
            historyForm.Show();
        }

        private void borrowedBooksButton_Click(object sender, EventArgs e)
        {
            BorrowedBooks borrowedBooksForm = new BorrowedBooks();

            //TODO:Uzupelnic tabele w formatce
            List<BookData> history = Program.communicationHandler.GetHistory();
            borrowedBooksForm.Show();
        }

        private void catalogButton_Click(object sender, EventArgs e)
        {
            BooksCatalog booksCatalogForm = new BooksCatalog();

            //TODO:Uzupelnic tabele w formatce
            List<BookData> history = Program.communicationHandler.GetHistory();
            booksCatalogForm.Show();
        }
    }
}
