using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_pro.My_Forms
{
    public partial class search_memo : Form
    {
        public search_memo()
        {
            InitializeComponent();
        }

        private void search_memo_Load(object sender, EventArgs e)
        {
            Int32 ic;
            ic = dairy_pro.Properties.Settings.Default.last_memo_id;

            Int32 i;
            for ( i = 1; i <= ic; i++ )
            {
                this.listBox1.Items.Add(i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dairy_pro.My_Forms.memo_form mf;
            mf = new My_Forms.memo_form();

            mf.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fn;
            string fn_title; 
            string fn_date;
            Int32 last_id;
            Int32.TryParse(this.listBox1.Text,out last_id);

            fn = Application.StartupPath + "\\data\\docs\\" + last_id.ToString() + ".rtf";
            fn_title = Application.StartupPath + "\\data\\docs\\title_" + last_id.ToString() + ".txt";
            fn_date = Application.StartupPath + "\\data\\docs\\date_" + last_id.ToString() + ".txt";

            this.richTextBox1.LoadFile(fn);
            this.textBox1.Text = System.IO.File.ReadAllText(fn_title, Encoding.UTF8);
            this.textBox2.Text = System.IO.File.ReadAllText(fn_date, Encoding.UTF8);
            this.textBox3.Text = last_id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 i;
                i = this.listBox1.FindStringExact(this.textBox4.Text);
                this.listBox1.SelectedIndex = i;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.ToString()); 
            }
        }
    }
}
