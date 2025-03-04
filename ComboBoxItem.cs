using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    public struct ComboBoxItem
    {
        public int ID;
        public string Text;

        public static int GetIDByText(string text)
        {
            char[] charArray = text.ToCharArray();
            string id = "";

            foreach (char c in charArray)
            {
                if (Char.IsDigit(c))
                {
                    id += c;
                }
                else
                {
                    break;
                }
            }

            return int.Parse(id);
        }
    }
}
