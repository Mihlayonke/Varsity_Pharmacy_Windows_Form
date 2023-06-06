using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Varsity_Phamarcy
{
    public partial class Products1 : Form
    {
        //private string categoryID;
        Suppliers suppliers1 = new Suppliers();
  
        string status;
        public int Quant;

        public Products1()
        {
            InitializeComponent();
            
        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    status = "Available";
                }
                else
                {
                    status = "Unavailable";
                }
                productsTableAdapter.UpdateQuery(productName.Text, Convert.ToInt32(productQuantity.Text), Convert.ToDecimal(productSale.Text), Convert.ToDecimal(productCost.Text), status, productCategory.Text, Int32.Parse(productID.Text), Int32.Parse(productID.Text));
                productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
                productID.Text = "";
                productName.Text = "";
                productQuantity.Text = "";
                productCost.Text = "";
                productSale.Text = "";
                productCategory.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                MessageBox.Show("Updated");
            }
            catch
            {
                MessageBox.Show("Error While Updating");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                productsTableAdapter.InsertQuery(productName.Text, Convert.ToInt32(productQuantity.Text) + Quant, Convert.ToDecimal(productSale.Text), Convert.ToDecimal(productCost.Text), status, productCategory.Text);
                productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
                productID.Text = "";
                productName.Text = "";
                productQuantity.Text = "";
                productCost.Text = "";
                productSale.Text = "";
                productCategory.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                MessageBox.Show("ADDED!");
            }
            catch
            {
                MessageBox.Show("Error While Adding");
            }

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            productName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            productCost.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            productQuantity.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            productSale.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            productCategory.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            status = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            
            if (status.Equals("Available")){
                radioButton1.Checked = true;
                radioButton2.Checked = false;

            }else if (status.Equals("Unavailable"))
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            searchBox.ReadOnly = false;
           
            searchBox.Visible = true;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            searchBox.ReadOnly = false;
            searchBox.Visible = true;
            
            
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
          
            String name = "%" + searchBox.Text + "%";
            this.productsTableAdapter.FillBy(this.varsityPharmacyDataSet.Products, name);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton1.Text = "Available";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton2.Text = "Unavailable";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            this.Hide();
            suppliers.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
