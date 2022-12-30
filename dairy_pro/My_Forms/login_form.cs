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
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Have a Nice Day Dude!!!");
            Application.Exit();
        }

        private void login_form_Load(object sender, EventArgs e)
        {
            try
            {
                user_info_loader();
            }
            catch (Exception ex)
            {
                comm_class.my_err_msg(ex.ToString());
            }
        }

        public void user_info_loader()
        {
            this.textBox1.Text = dairy_pro.Properties.Settings.Default.User_name;

            string df;
            df = Application.StartupPath + "\\data\\pics\\1.jpg";
            this.pictureBox1.Load(df);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox2.Text == "")
                {
                    MessageBox.Show("User Name is empty!!!");
                    return;
                }

                if (this.textBox2.Text == dairy_pro.Properties.Settings.Default.User_pass)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your password is not correct. Please try again!");
                }
            }
            catch (Exception ex)
            {
                comm_class.my_err_msg(ex.ToString());
            }
            
        }
    }
}
