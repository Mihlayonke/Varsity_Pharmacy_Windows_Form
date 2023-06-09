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
    public partial class Sale : Form
    {
        private const decimal V = (decimal) 0.15;
        private int Qty = 0;
        private int count = 0;
        private decimal Total;
        private string products; //prices;
        List<int> product1 = new List<int>();
        List<int> quantityy = new List<int>();
        List<decimal> pricee = new List<decimal>();
        Login log = new Login();
        

        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet2.Sale_item' table. You can move, or remove it, as needed.
            this.sale_itemTableAdapter1.Fill(this.varsityPharmacyDataSet2.Sale_item);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Sale_Item2' table. You can move, or remove it, as needed.
            this.sale_Item2TableAdapter.Fill(this.varsityPharmacyDataSet.Sale_Item2);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Sale_item' table. You can move, or remove it, as needed.
            this.sale_itemTableAdapter1.Fill(this.varsityPharmacyDataSet2.Sale_item);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.varsityPharmacyDataSet.Customers);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Sale_Item2' table. You can move, or remove it, as needed.
            this.sale_Item2TableAdapter.Fill(this.varsityPharmacyDataSet.Sale_Item2);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Sale_item' table. You can move, or remove it, as needed.
            this.sale_itemTableAdapter1.Fill(this.varsityPharmacyDataSet2.Sale_item);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.varsityPharmacyDataSet.Customers);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Sale_Item2' table. You can move, or remove it, as needed.
            this.sale_Item2TableAdapter.Fill(this.varsityPharmacyDataSet.Sale_Item2);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet2.Sale_item' table. You can move, or remove it, as needed.
            

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //custName.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //staffName.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int loc = 0 ;
            int Q, ID;
            pricee.Add(0);
            product1.Add(0);
            quantityy.Add(0);
            Price.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            productName.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            quant.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            Q = int.Parse(quant.Text);
            ID = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
            Q -= 1;
            textBox1.Text =(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            textBox2.Text =(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            int temp = int.Parse(textBox1.Text);
            decimal temp2 = decimal.Parse(textBox2.Text);

            for (int i = 0; i < product1.Count; i++)
            {
                if (temp == product1[i])
                   loc = i;
                   //break;
               
            }
            if(loc != 0)
            {
                product1[loc] = int.Parse(textBox1.Text);
                quantityy[loc]++;
                pricee[loc] = pricee[loc] + temp2;

            }
            else
            {
                product1.Add(int.Parse(textBox1.Text));
                quantityy.Add(1);
                pricee.Add(temp2);
            }
            
            if (Q <= 0){
                Q = 0;
                MessageBox.Show("No Products Available");

            }else{
                products += count+1 + "." + productName.Text + " ---> R" + Price.Text + "| \r\n";
                count += 1;
                Total += decimal.Parse(Price.Text);
                total.Text = Total.ToString();
                Qty += 1;
                QtyBox.Text = Qty.ToString();
                list.Text += " \r\n " + count + ") === " + productName.Text + "  --->   R" + Price.Text + " \r\n ";

                productsTableAdapter.UpdateQuery2(productName.Text, Q, decimal.Parse(Price.Text), ID, ID);
                productsTableAdapter.Fill(this.varsityPharmacyDataSet.Products);

                if (Q < 6)
                {
                    MessageBox.Show("Less Than 6 products available !!!");

                }
            }   
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                list2.Text = list.Text;
                totalQty.Text = Qty.ToString();
                totalPrice.Text = Total.ToString();
                tabControl1.SelectedTab = tabPage2;
            }
            catch
            {
                MessageBox.Show("Some Error has Occurred");
            }
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string Customer = custName.Text;
            string Staff = log.getUserName();
            string product = products;
            decimal price = decimal.Parse(this.Price.Text);
            int quantity = int.Parse(quant.Text);
            decimal amount = decimal.Parse(Tendered.Text);
            DateTime date = DateTime.Now;
            DayOfWeek wk = DateTime.Now.DayOfWeek;
            string Day = wk.ToString("d");

            switch(Int32.Parse(Day)){
                case 1 :
                    Day = "Monday";
                    break;
                case 2 :
                    Day = "Tuesday";
                    break;
                case 3 :
                    Day = "Wednesday";
                    break;
                case 4:
                    Day = "Thursday";
                    break;
                case 5:
                    Day = "Friday";
                    break;
                case 6:
                    Day = "Saturday";
                    break;
                case 0:
                    Day = "Sunday";
                    break;
            }


            if (amount < (decimal)Total )
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {
                decimal change = (amount - Total);
                changeBox.Text = "R " + change.ToString();
                decimal VAT = ((decimal)Total * V);

                sale_itemTableAdapter1.InsertQuery(Customer, Staff, products, (decimal)price, Qty, (decimal)amount, (decimal)Total, (decimal)change,(decimal) VAT, date, Day);

                this.sale_itemTableAdapter1.Fill(this.varsityPharmacyDataSet2.Sale_item);
                products = "";
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            tabControl1.SelectedTab = tabPage1;
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string prodName = "%" + search.Text + "%";
                this.productsTableAdapter.FillBy(this.varsityPharmacyDataSet.Products, prodName);
            }
            catch
            {
                MessageBox.Show(productName, "NOT FOUND");
            }

           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            product1.Clear();
            pricee.Clear();
            quantityy.Clear();
            custName.Text = "";
            textBox1.Text = "";
            productName.Text = "";
            Price.Text = "";
            Total = 0;
            quant.Text = "";
            Tendered.Text = "";
            changeBox.Text = "";
            totalPrice.Text = "";
            totalQty.Text = "";
            total.Text = "";
            QtyBox.Text = "";
            list.Text = "";
            list2.Text = "";
            products = "";
            Qty = 0;
            count = 0;
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            button10_Click(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            Customer cust = new Customer();
            
            this.Hide();
            cust.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                string custName = "%" + textBox4.Text + "%";
                this.customersTableAdapter.FillBy(this.varsityPharmacyDataSet.Customers, custName);
                
            }
            catch
            {
                MessageBox.Show(custName, "NOT FOUND");
            }
        }

        

        private void button5_Click_1(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            this.Hide();
            suppliers.Show();
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            custName.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
        }

    }
}
