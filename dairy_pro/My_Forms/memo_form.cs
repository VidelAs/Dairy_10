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
    public partial class memo_form : Form
    {
        public memo_form()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowDialog();
            this.richTextBox1.SelectionFont = this.fontDialog1.Font;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.richTextBox1.SelectionColor = this.colorDialog1.Color;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.richTextBox1.SelectionBackColor = this.colorDialog1.Color;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Int32 i;
            i = this.richTextBox1.SelectionIndent;
            i = i - 10;
            this.richTextBox1.SelectionIndent = i;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Int32 i;
            i = this.richTextBox1.SelectionIndent;
            i = i + 10;
            this.richTextBox1.SelectionIndent = i;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Undo();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Redo();
        }

        private void memo_form_Load(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            this.button1.Enabled = true;
            this.button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            this.button2.Enabled = true;
            this.button1.Enabled = false;

            Int32 i;
            i = dairy_pro.Properties.Settings.Default.last_memo_id + 1;
            this.textBox3.Text = i.ToString();

            this.textBox1.Text = "";
            this.textBox2.ResetText();
            this.richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox1.Enabled = false;
                this.button2.Enabled = false;
                this.button1.Enabled = true;

                Int32 last_id;
                last_id = dairy_pro.Properties.Settings.Default.last_memo_id;
                last_id = last_id + 1;

                dairy_pro.Properties.Settings.Default.last_memo_id = last_id;
                dairy_pro.Properties.Settings.Default.Save();

                string fn;
                string fn_title;
                string fn_date;
                fn = Application.StartupPath + "\\data\\docs\\" + last_id.ToString() + ".rtf";
                fn_title = Application.StartupPath + "\\data\\docs\\title_" + last_id.ToString() + ".txt";
                fn_date = Application.StartupPath + "\\data\\docs\\date_" + last_id.ToString() + ".txt";
            
                System.IO.File.WriteAllText(fn_title, this.textBox1.Text, Encoding.UTF8);
                System.IO.File.WriteAllText(fn_date, this.textBox2.Text, Encoding.UTF8);

                this.richTextBox1.SaveFile(fn);
                MessageBox.Show("Your Memo Saved!");
            }
            catch (Exception ex)
            {
                comm_class.my_err_msg(ex.ToString());
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dairy_pro.Properties.Settings.Default.last_memo_id = 0;
            dairy_pro.Properties.Settings.Default.Save();
        }
    }
}
