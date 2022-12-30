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
    public partial class about_us : Form
    {
        public about_us()
        {
            InitializeComponent();
        }

        private void about_us_Load(object sender, EventArgs e)
        {
            this.label1.Text = Application.CompanyName;
            this.label2.Text = "Product Name: " + Application.ProductName;
            this.label3.Text = "Version: " + Application.ProductVersion;
            this.label7.Text = dairy_pro.Properties.Settings.Default.company_site_url;
            this.label5.Text = dairy_pro.Properties.Settings.Default.production_year;
            this.label6.Text = "Programmer: " + dairy_pro.Properties.Settings.Default.programmer_name;

        }
    }
}
