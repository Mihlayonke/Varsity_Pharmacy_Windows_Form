using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Varsity_Phamarcy
{
    public partial class LOGIN : Form
    {
        public static string Username;
        public static string password;

        public LOGIN()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            //SqlConnection sqlcon = new SqlConnection(@"Data Source=146.230.177.46\ist3;Initial Catalog=group18;Persist Security Info=True;User ID=group18; Password=w7byh");
            SqlConnection sqlcon = new SqlConnection(@"Data Source=AFRI-SOUL;Initial Catalog=VarsityPharmacy;Integrated Security=True");
            string query = " Select * FROM Staff WHERE staffName = '" + txtUsername.Text.Trim() + "'AND staffPassword= '" + txtPassword.Text.Trim() + "'";
            
            Username = txtUsername.Text;
            
            password = txtPassword.Text;

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1)
            {
                MainMenu object1 = new Varsity_Phamarcy.MainMenu();
                this.Hide();
                object1.Show();

            }
            else
                MessageBox.Show("Incorrect username or password entered");
        }

        public string getUserName()
        {
            int ind = 0;

            for (int i=0; i< Username.Length; i++)
            {
                if (Username[i] == '@')
                {
                    ind = i;
                    break;
                }
            }
            Username = Username.Substring(0, ind);
            
            return Username;
        }

        public string getPassword()
        {
            return password;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("By clicking this button you will be able to see help menu", button1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            HelpLog log = new HelpLog();
            this.Hide();
            log.Show();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}
