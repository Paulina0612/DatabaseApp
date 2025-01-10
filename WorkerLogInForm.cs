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

    public partial class WorkerLogInForm : Forms
    {
        private bool ifDirector = false;

        public WorkerLogInForm()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            communicationHandler.WorkerLogIn(ifDirector);
        }

        private void directorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(ifDirector) ifDirector = false;
            else ifDirector = true;
        }

    }
}
