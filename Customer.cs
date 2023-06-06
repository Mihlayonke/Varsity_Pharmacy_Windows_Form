

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
    public partial class Customer : Form
    {
        int Age;
        string ID ;
        int ID_Num;
        int Date;
        int Year;
        int Month;
        int Day;
        string Age1;
        int Age2;
        int CurrYear = 1900;
        string str;
        int gender;
        string Status;

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.varsityPharmacyDataSet.Customers);



            try
            {
                // TODO: This line of code loads data into the 'varsityPharmacyDataSet3.Customers' table. You can move, or remove it, as needed.
                this.customersTableAdapter.Fill(this.varsityPharmacyDataSet.Customers);

            }
            catch
            {
                MessageBox.Show("Error while filling customer");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to confirm customer ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {

                int count0 = 0;
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;
                

                ID = Identity.Text;
                string Phone = this.Phone.Text;
                
           
                if (ID.Length == 13 || Phone.Length == 10)
                {
                    ID = Identity.Text.Substring(0, 6);
                    Age1 = ID.Substring(0, 2);
                    Age2 = Int32.Parse(Age1);
                    
                    if (Age2 > 21)
                    {
                        CurrYear = 1900;
                        
                    }else if (Age2 <= 21)
                    {
                        CurrYear = 2000;
                    }
                    Age2 += CurrYear;

                    Age = (2021 - Age2);

                    ID_Num = Int32.Parse(ID);
                    Date = ID_Num;
                    Year = Date / 10000;
                    Month = Date % 10000;
                    Month = Month / 100;
                    Day = Date % 100;

                    if (Month > 0 && Month < 13)
                    {
                        count0++;

                        if (Year % 4 != 0 || Year % 400 != 0)
                        {
                            if (Month == 2)
                            {
                                if (Day <= 0 || Day > 28)
                                {
                                    MessageBox.Show("Invalid Day of birth for the Identity 1, Day:" + Day);
                                    //break;
                                }
                                else
                                {
                                    count1++;
                                }
                            }
                        }
                        else
                        {
                            if (Month == 2)
                            {
                                if (Day <= 0 || Day > 29)
                                {
                                    MessageBox.Show("Invalid Day of birth for the Identity 1, Day:" + Day);
                                }
                                else
                                {
                                    count2++;
                                }
                            }
                        }

                        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                        {
                            if (Day <= 0 || Day > 31)
                            {
                                MessageBox.Show("Invalid Day of Birth for the Identiry 2, Day: " + Day);
                            }
                            else
                            {
                                count3++;
                            }
                        }

                        if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                        {
                            if (Day <= 0 || Day > 30)
                            {
                                MessageBox.Show("Invalid Day of Birth for the Identity 3, Day: " + Day);
                            }
                            else
                            {
                                count4++;
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Invalid Month of Birth for the Identity");
                    }

                    for (int i = 0; i < Email.Text.Length; i++)
                    {
                        if (Email.Text[i] == '@' && (Email.Text.EndsWith(".com") || Email.Text.EndsWith(".co.za")))
                        {
                            count5++;
                            break;
                        }
                    }

                    if (count0 == 1 && (count1 == 1 || count2 == 1 || count3 == 1 || count4 == 1) && count5 == 1)
                    {
                        str = Identity.Text.Substring(6, 7);
                        gender = Int32.Parse(str);
                        
                        if (gender >= 0 && gender < 5)
                        {
                            Gend.Text = "Female";

                        }
                        else if (gender >= 5 && gender < 10)
                        {
                            Gend.Text = "Male";
                        }

                        radioButton1.Text = "Activated";
                        radioButton2.Text = "Deactivated";

                        if (radioButton1.Text == "Activated")
                        {
                            Status = radioButton1.Text;
                            radioButton1.Text = "Activate";
                            radioButton2.Text = "Deactivate";
                        }
                        else if (radioButton2.Text == "Deactivated")
                        {
                            Status = radioButton2.Text;
                            radioButton1.Text = "Activate";
                            radioButton2.Text = "Deactivate";
                        }

                        customersTableAdapter.InsertQuery(Name.Text, Surname.Text, Email.Text, Identity.Text, Age, this.Phone.Text, Gend.Text, Convert.ToInt16(AidNumber.Text), Number.Text, Status, AidName.Text);
                        customersTableAdapter.Fill(this.varsityPharmacyDataSet.Customers);
                        MessageBox.Show("New Customer Added");
                    }
                    else if (count5 == 0)
                    {
                        MessageBox.Show("Invalid Email Address");
                    }
                }
                else if (ID.Length < 13 )
                {
                    MessageBox.Show(" Invalid Length of ID Number ! ");
                }
                else if (Phone.Length < 12)
                {
                    MessageBox.Show("Invalid Legnth of Phone Number !");

                }
            }

            else if (result == DialogResult.No)
            {
                MessageBox.Show("New cell Customer not added");
            }
            else
            {
                MessageBox.Show("Cancelled");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Hide();
            menu.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to confirm Update customer ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {

                int count0 = 0;
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;


                ID = Identity.Text;
                string Phone = this.Phone.Text;


                if (ID.Length == 13 || Phone.Length == 10)
                {
                    ID = Identity.Text.Substring(0, 6);
                    Age1 = ID.Substring(0, 2);
                    Age2 = Int32.Parse(Age1);
                    
                    if (Age2 > 21)
                    {
                        CurrYear = 1900;

                    }
                    else if (Age2 <= 21)
                    {
                        CurrYear = 2000;
                    }

                    Age2 += CurrYear;

                    ID_Num = Int32.Parse(ID);
                    Age = (2021 - Age2);
                    Date = ID_Num;
                    Year = Date / 10000;
                    Month = Date % 10000;
                    Month = Month / 100;
                    Day = Date % 100;

                    if (Month > 0 && Month < 13)
                    {
                        count0++;

                        if (Year % 4 != 0 || Year % 400 != 0)
                        {
                            if (Month == 2)
                            {
                                if (Day <= 0 || Day > 28)
                                {
                                    MessageBox.Show("Invalid Day of birth for the Identity 1, Day:" + Day);
                                    //break;
                                }
                                else
                                {
                                    count1++;
                                }
                            }
                        }
                        else
                        {
                            if (Month == 2)
                            {
                                if (Day <= 0 || Day > 29)
                                {
                                    MessageBox.Show("Invalid Day of birth for the Identity 1, Day:" + Day);
                                }
                                else
                                {
                                    count2++;
                                }
                            }
                        }

                        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                        {
                            if (Day <= 0 || Day > 31)
                            {
                                MessageBox.Show("Invalid Day of Birth for the Identiry 2, Day: " + Day);
                            }
                            else
                            {
                                count3++;
                            }
                        }

                        if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                        {
                            if (Day <= 0 || Day > 30)
                            {
                                MessageBox.Show("Invalid Day of Birth for the Identity 3, Day: " + Day);
                            }
                            else
                            {
                                count4++;
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Invalid Month of Birth for the Identity");
                    }

                    for (int i = 0; i < Email.Text.Length; i++)
                    {
                        if (Email.Text[i] == '@' && (Email.Text.EndsWith(".com") || Email.Text.EndsWith(".co.za")))
                        {
                            count5++;
                            break;
                        }
                    }

                    //MessageBox.Show(""+count0+""+count1 +""+count2 +"" + count3 +""+count4+"" + count5 +"");

                    if (count0 == 1 && (count1 == 1 || count2 == 1 || count3 == 1 || count4 == 1) && count5 == 1)
                    {
                        str = Identity.Text.Substring(6, 7);
                       
                        gender = Int32.Parse(str);
                        if (gender >= 0 && gender < 5000000)
                        {
                            Gend.Text = "Female";

                        }
                        else if (gender >= 5000000 && gender < 10000000)
                        {
                            Gend.Text = "Male";
                        }
                      

                        if (radioButton1.Text == "Activated")
                        {
                            Status = "Active";
                            radioButton1.Text = "Activated";
                            radioButton2.Text = "Deactivate";
                        }
                        else if (radioButton2.Text == "Deactivated")
                        {
                            Status = "Deactive";
                            radioButton1.Text = "Activate";
                            radioButton2.Text = "Deactivated";
                        }

                        customersTableAdapter.UpdateQuery(Name.Text, Surname.Text, Email.Text, Identity.Text, int.Parse(Number.Text), this.Phone.Text, Gend.Text.ToString(), int.Parse(AidNumber.Text), Number.Text, Status, AidName.Text, int.Parse(customerID.Text), int.Parse(customerID.Text));
                        customersTableAdapter.Fill(this.varsityPharmacyDataSet.Customers);
                        MessageBox.Show("Customer Updated");
                    }
                    else if (count5 == 0)
                    {
                        MessageBox.Show("Invalid Email Address");
                    }
                }
                else if (ID.Length < 13)
                {
                    MessageBox.Show(" Invalid Length of ID Number ! ");
                }
                else if (Phone.Length < 12)
                {
                    MessageBox.Show("Invalid Legnth of Phone Number !");

                }
            }

            else if (result == DialogResult.No)
            {
                MessageBox.Show("Customer Not Updated");
            }
            else
            {
                MessageBox.Show("Cancelled");
            }

            customerID.Clear();
            Name.Clear();
            Surname.Clear();
            Email.Clear();
            Identity.Clear();
            Number.Clear();
            Phone.Clear();
            Gend.Clear();
            AidName.SelectedItem = "";
            AidNumber.Clear();
        }



        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            

            try
            {

                customerID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Surname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Email.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Identity.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Number.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Phone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                Gend.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                AidNumber.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                AidName.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                string name = AidName.Text;
                AidName.Items.Equals(name);

                if ( (dataGridView1.CurrentRow.Cells[10].Value.Equals("Active")) ){
                    radioButton1_CheckedChanged(sender, e);
                }
                else if ((dataGridView1.CurrentRow.Cells[10].Value.Equals("Deactive")))
                {
                    radioButton2_CheckedChanged(sender, e);
                }
                
                

                str = Identity.Text.Substring(6, 7);
                gender = Int32.Parse(str);
                if (gender >= 0 && gender < 5000000)
                {
                    Gend.Text = "Female";

                }
                else if (gender >= 5000000 && gender < 10000000)
                {
                    Gend.Text = "Male";
                }

            }
            catch
            {
                MessageBox.Show("Error while Filling TextBoxs ");
            }
            
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Text == "Activate")
            {
                radioButton1.Text = "Activated";
            }
            else
            {
                radioButton1.Text = "Activate";
                radioButton2.Text = "Deactivate";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Text == "Deactivate")
            {
                radioButton2.Text = "Deactivated";
            }
            else
            {
                radioButton2.Text = "Deactivate";
                radioButton1.Text = "Activate";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string custName = "%" + Search.Text + "%";
                this.customersTableAdapter.FillBy(this.varsityPharmacyDataSet.Customers, custName);
            }
            catch
            {
                MessageBox.Show(Search, " NOT FOUND");
            }
        }

    }
}
