using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dairy_pro
{
    public static class comm_class
    {
        public static void my_err_msg(string error_text)
        {
            System.Windows.Forms.MessageBox.Show("Error: " + error_text);
        }
    }
}
