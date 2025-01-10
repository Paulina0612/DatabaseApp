using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp
{
    // Class connecting GUI with SQLConnectionHandler
    public class Forms : Form
    {
        protected SQLCommunicationHandler communicationHandler = new SQLCommunicationHandler();
    }
}
