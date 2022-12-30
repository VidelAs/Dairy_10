using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_pro.My_Forms
{
    public partial class users_mang : Form
    {
        public users_mang()
        {
            InitializeComponent();
        }

        private void users_mang_Load(object sender, EventArgs e)
        {
            user_info_loader();
        }

        public void user_info_loader()
        {
            this.textBox1.Text = dairy_pro.Properties.Settings.Default.User_name;
            this.textBox2.Text = dairy_pro.Properties.Settings.Default.User_pass;

            string df;
            df = Application.StartupPath + "\\data\\user_pic\\1.jpg";
            //this.pictureBox1.Load(df);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "")
            {
                MessageBox.Show("User Name is empty!!!");
                return;
            }
            if(this.textBox2.Text!=this.textBox3.Text)
            {
                MessageBox.Show("You must enter same password in both textboxes!");
                return;
            }
            dairy_pro.Properties.Settings.Default.User_name = this.textBox1.Text;
            dairy_pro.Properties.Settings.Default.User_pass = this.textBox2.Text;
            dairy_pro.Properties.Settings.Default.Save();

            if(this.openFileDialog1.FileName != "openFileDialog1")
            {
                string fn;
                fn = this.openFileDialog1.FileName;
                //-------------------------------------------------------
                string df;
                df = Application.StartupPath + "\\data\\user_pic\\1.jpg";
                System.IO.File.Copy(fn, df, true);
            }

            MessageBox.Show("Done!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            string fn;
            fn = this.openFileDialog1.FileName;
           // this.pictureBox1.Load(fn);
        }
    }
}
