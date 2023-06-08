using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Varsity_Phamarcy
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void lbProducts_Click(object sender, EventArgs e)
        {
            Products1 products = new Products1();
            this.Hide();
            products.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customer customers = new Customer();
            this.Hide();
            customers.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            this.Hide();
            sale.Show();
        }

        private void lbUsers_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            this.Hide();
            staff.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            this.Hide();
            suppliers.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help HLP = new Help();
            this.Hide();
            HLP.Show();
        }
    }
}
