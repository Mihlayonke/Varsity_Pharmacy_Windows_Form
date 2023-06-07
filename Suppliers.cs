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
    public partial class Suppliers : Form
    {
        private decimal Total;
        //private int count;
        public int Quantity;
        public int Quant;
        public string Status;
        public int Id;
        

        public Suppliers()
        {
            InitializeComponent();

        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet1.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.varsityPharmacyDataSet1.Supplier);

            this.supplier_Order_ItemTableAdapter.Fill(this.varsityPharmacyDataSet.Supplier_Order_Item);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Supplier' table. You can move, or remove it, as needed.
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Do you want to confirm Add Supplier ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                int count5 = 0;

                string Phone = this.Phone.Text;

                if ( Phone.Length == 12)
                {
                    
                    for (int i = 0; i < Email.Text.Length; i++)
                    {
                        if (Email.Text[i] == '@' && (Email.Text.EndsWith(".com") || Email.Text.EndsWith(".co.za")))
                        {
                            count5++;
                            break;
                        }
                    }

                    if ( count5 == 1)
                    {

                        if (radioButton1.Text == "Activated")
                        {
                            Status = "Active";
                            radioButton1.Text = "Activated";
                            radioButton4.Text = "Deactivate";
                        }
                        else if (radioButton4.Text == "Deactivated")
                        {
                            Status = "Deactive";
                            radioButton1.Text = "Activate";
                            radioButton4.Text = "Deactivated";
                        }

                        try
                        {
                            this.supplierTableAdapter.InsertQuery(NameS.Text, Email.Text, this.Phone.Text, Status);
                            this.supplierTableAdapter.Fill(this.varsityPharmacyDataSet1.Supplier);
                        }
                        catch
                        {
                            MessageBox.Show("Error While Adding Supplier");
                        }
                    }
                    else if (count5 == 0)
                    {
                        MessageBox.Show("Invalid Email Address");
                    }
                }
                
                else if (Phone.Length < 12)
                {
                    MessageBox.Show("Invalid Legnth of Phone Number !");

                }
            }

            else if (result == DialogResult.No)
            {
                MessageBox.Show("Supplier Was Not Added");
            }
            else
            {
                MessageBox.Show("Cancelled");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to confirm Update Supplier ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {

                int count5 = 0;
                string Phone = this.Phone.Text;


                if ( Phone.Length == 12)
                {
                    

                    for (int i = 0; i < Email.Text.Length; i++)
                    {
                        if (Email.Text[i] == '@' && (Email.Text.EndsWith(".com") || Email.Text.EndsWith(".co.za")))
                        {
                            count5++;
                            break;
                        }
                    }

                    if ( count5 == 1)
                    {

                        if (radioButton1.Text == "Activated")
                        {
                            Status = "Active";
                            radioButton1.Text = "Activated";
                            radioButton4.Text = "Deactivate";
                        }
                        else if (radioButton4.Text == "Deactivated")
                        {
                            Status = "Deactive";
                            radioButton1.Text = "Activate";
                            radioButton4.Text = "Deactivated";
                        }

                        try
                        {
                            this.supplierTableAdapter.UpdateQuery(NameS.Text, Email.Text, this.Phone.Text, Status, int.Parse(suppID.Text), int.Parse(suppID.Text));
                            this.supplierTableAdapter.Fill(this.varsityPharmacyDataSet1.Supplier);
                            MessageBox.Show("Supplier Is Updated");
                        }
                        catch
                        {
                            MessageBox.Show("Error While Updating Supplier");
                        }
                    }

                    else if (count5 == 0)
                    {
                        MessageBox.Show("Invalid Email Address");
                    }
                }
                
                else if (Phone.Length < 12)
                {
                    MessageBox.Show("Invalid Legnth of Phone Number !");

                }
            }

            else if (result == DialogResult.No)
            {
                MessageBox.Show("Supplier Was Not Updated");
            }
            else
            {
                MessageBox.Show("Cancelled");
            }


        }


        private void button7_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            this.supplierTableAdapter.Fill(this.varsityPharmacyDataSet1.Supplier);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            quantBox.Clear();
            totalBox.Clear();
            list.Clear();
            prodName.Clear();
            Quantity = 0;

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                suppID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                NameS.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                suppName.Text = NameS.Text;
                Email.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Phone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Status = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                if (Status.Equals("Active"))
                {
                    radioButton1.Checked = true;
                    radioButton4.Checked = false;
                    radioButton1_CheckedChanged_1(sender, e);

                }
                else if (Status.Equals("Deactive"))
                {
                    radioButton4.Checked = true;
                    radioButton1.Checked = false;
                    radioButton4_CheckedChanged(sender, e);

                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Quantity++;
            quantBox.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            Quant = Int32.Parse(quantBox.Text);
            quantBox.Text = Quantity.ToString();
            Total += decimal.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
            totalBox.Text = Total.ToString();
            prodName.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            string name = prodName.Text;
            decimal price = decimal.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
            Id = int.Parse(dataGridView3.CurrentRow.Cells[3].Value.ToString());
            list.Text += " ==== " + name + " ---> R" + price + " ====";
        }

        private void textBox12_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                string Name = "%" + textBox12.Text + "%";
                this.productsTableAdapter.FillBy(this.varsityPharmacyDataSet.Products, Name);
            }
            catch
            {
                MessageBox.Show(textBox12.Text, "PRODUCT NOT FOUND");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Name = "%" + textBox1.Text + "%";
                this.supplier_Order_ItemTableAdapter.FillBy(this.varsityPharmacyDataSet.Supplier_Order_Item, Name);
                
            }
            catch
            {
                MessageBox.Show(textBox1.Text, "SUPPLIER NOT FOUND");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Quantity > 0)
            {
                this.productsTableAdapter.UpdateQuery1(Quant + Quantity, Id, Id);
                this.productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
            }

            Products1 products = new Products1();
            this.Hide();
            products.Show();

            if (Quantity > 0)
            {
                MessageBox.Show("Products Added From Supplier");
            }

            Quantity = 0;
            quantBox.Text = "";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Manage_Supplier.SelectedTab = tabPage1;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                suppName.Text = NameS.Text;
                suppID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Some Error has Occured");
            }

            Manage_Supplier.SelectedTab = tabPage2;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton1.Text = "Activated";
            Status = "Active";
            radioButton4.Text = "Deactivate";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton4.Text = "Deactivated";
            Status = "Deactive";
            radioButton1.Text = "Activate";
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Name = "%" + searchBox.Text + "%";
                this.supplierTableAdapter.FillBy(this.varsityPharmacyDataSet1.Supplier, Name);
            }
            catch
            {
                MessageBox.Show(searchBox.Text, "SUPPLIER NOT FOUND");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {


            try
            {

                
                this.supplier_Order_ItemTableAdapter.InsertQuery(Id, Quantity, Total, NameS.Text);
                this.supplier_Order_ItemTableAdapter.Fill(this.varsityPharmacyDataSet.Supplier_Order_Item);
                MessageBox.Show("Products Order Has Been Sent");
                suppID.Text = "";
                Total = 0;
                NameS.Text = "";
                totalBox.Text = "";
                list.Text = "";
                prodName.Text = "";
                suppName.Text = "";
                Email.Text = "";
                Phone.Text = "";
                

            }
            catch
            {
                MessageBox.Show("Error While Sending Order");
            }

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void list_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
