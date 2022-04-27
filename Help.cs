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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void HLP_btn_Click(object sender, EventArgs e)
        {
            //panel1.Visible= true;
        }

        private void EXT_btn_Click(object sender, EventArgs e)
        {
           // panel1.Visible = false;
        }

        private void HM_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu Menu = new MainMenu();
            this.Hide();
            Menu.Show();
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
