using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_pro
{
    public partial class lock_cm : Form
    {
        public lock_cm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dairy_pro.My_Forms.memo_form mf;
            mf = new My_Forms.memo_form();
            mf.MdiParent= this;
            mf.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dairy_pro.My_Forms.search_memo sf = new My_Forms.search_memo();
            sf.MdiParent = this;
            sf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            get_time();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //--------------
                dairy_pro.My_Forms.login_form lg_form = new My_Forms.login_form();
                lg_form.ShowDialog();
                //--------------
                get_time();
                //--------------
                get_cal();
                //--------------
                back_image_loader(4);
                //--------------
                background_combo_loader();
                //--------------
                Int32 sm;
                sm = dairy_pro.Properties.Settings.Default.select_music_index;
                //this.comboBox2.SelectedIndex = sm;
                //--------------
                music_combo_loader();
                //--------------
                this.label7.Text = Application.ProductVersion.ToString();
            }
            catch (Exception ex)
            {
                comm_class.my_err_msg(ex.ToString());
            }

            user_info_loader();
        }

        public void user_info_loader()
        {
            this.label11.Text = dairy_pro.Properties.Settings.Default.User_name;

            string df;
            df = Application.StartupPath + "\\data\\user_pic\\1.jpg";
            //this.pictureBox1.Load(df);
        }

        public void get_cal()
        {
            System.Globalization.GregorianCalendar g;
            g = new System.Globalization.GregorianCalendar();
            this.label2.Text = g.GetYear(DateTime.Now).ToString();
            this.label3.Text = g.GetMonth(DateTime.Now).ToString();
            this.label4.Text = g.GetDayOfMonth(DateTime.Now).ToString();
            this.label5.Text = g.GetDayOfWeek(DateTime.Now).ToString();

            Int32 m;
            Int32.TryParse(this.label3.Text, out m);
            this.label3.Text = month_num_to_name(m);
        }

        public string month_num_to_name(Int32 month_num)
        {
            string mn;

            switch (month_num)
            {
                case 1:
                    mn = "January";
                    break;
                case 2:
                    mn = "February";
                    break;
                case 3:
                    mn = "March";
                    break;
                case 4:
                    mn = "April";
                    break;
                case 5:
                    mn = "May";
                    break;
                case 6:
                    mn = "June";
                    break;
                case 7:
                    mn = "July";
                    break;
                case 8:
                    mn = "August";
                    break;
                case 9:
                    mn = "September";
                    break;
                case 10:
                    mn = "October";
                    break;
                case 11:
                    mn = "November";
                    break;
                case 12:
                    mn = "December";
                    break;
                default:
                    mn = "Unknown";
                    break;
            }
            return mn;
        }

        public void get_time()
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public void background_combo_loader()
        {
            Int32 i;

            for ( i = 1; i <= 5; i++)
            {
                this.comboBox1.Items.Add("Image " + i.ToString());
            }
        }

        public void music_combo_loader()
        {
            Int32 i;

            for (i = 1; i <= 2; i++)
            {
                this.comboBox2.Items.Add("Music " + i.ToString());
            }
        }

        public void back_image_loader(Int32 combo_index)
        {
            string fn;
            combo_index = combo_index + 1;
            fn = Application.StartupPath + "\\data\\pics\\" + combo_index.ToString()+".jpg";
            this.BackgroundImage = Image.FromFile(fn);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 si;
            si = this.comboBox1.SelectedIndex;
            back_image_loader(si);
        }

        public void music_loader(Int32 combo_index)
        {
            string fn;
            combo_index = combo_index + 1;
            fn = Application.StartupPath + "\\data\\music\\" + combo_index.ToString() + ".mp3";
            this.axWindowsMediaPlayer1.URL= fn;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            music_loader(this.comboBox2.SelectedIndex);
            dairy_pro.Properties.Settings.Default.select_music_index = this.comboBox2.SelectedIndex;
            dairy_pro.Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //music_loader(this.comboBox2.SelectedIndex);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dairy_pro.My_Forms.about_us ab_form = new dairy_pro.My_Forms.about_us();
            ab_form.MdiParent = this;
            ab_form.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dairy_pro.My_Forms.users_mang us_form = new My_Forms.users_mang();
            us_form.MdiParent = this;
            us_form.Show();
        }

        private void lockScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dairy_pro.My_Forms.login_form lg_form = new My_Forms.login_form();
            lg_form.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void lock_cm_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.F2)
           {
                toolStripButton1_Click(sender, e);
           }
           if (e.KeyCode == Keys.F3)
           {
                toolStripButton2_Click(sender, e);
           }
           if (e.KeyCode == Keys.F4)
           {
                this.toolStripButton3.ShowDropDown();
           }
           if (e.KeyCode == Keys.F5)
           {
                this.toolStripButton4.ShowDropDown();
            }
           if (e.KeyCode == Keys.F6)
           {
                this.toolStripButton5.ShowDropDown();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
