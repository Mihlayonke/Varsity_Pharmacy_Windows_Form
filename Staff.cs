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
    public partial class Staff : Form
    {

        public string Status;

        public Staff()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Do You Want To Update Staff ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {

                int count0 = 0;
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;

                string ID = staffID.Text;
                string Phone = staffPhone.Text;
                int ID_Num;
                int Date;
                int Year;
                int Month;
                int Day;

                if (ID.Length == 13 && Phone.Length == 12)
                {
                    ID = staffID.Text.Substring(0, 6);
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


                    for (int i = 0; i < staffEmail.Text.Length; i++)
                    {
                        if (staffEmail.Text[i] == '@' && (staffEmail.Text.EndsWith(".com") || staffEmail.Text.EndsWith(".co.za")))
                        {
                            count5++;
                            break;
                        }
                    }



                    if (count0 == 1 && (count1 == 1 || count2 == 1 || count3 == 1 || count4 == 1) && count5 == 1)
                    {
                        try
                        {
                            this.staffTableAdapter.UpdateQuery(staffName.Text, comboBox1.SelectedItem.ToString(), staffPhone.Text, staffEmail.Text, staffID.Text, staffPassword.Text, Status, Int32.Parse(textBox1.Text), Int32.Parse(textBox1.Text));
                            this.staffTableAdapter.Fill(this.varsityPharmacyDataSet.Staff);
                            staffName.Clear();
                            staffID.Clear();
                            staffPassword.Clear();
                            staffPhone.Clear();
                            staffEmail.Clear();
                            radioButton1.Checked = false;
                            radioButton2.Checked = false;
                            textBox1.Clear();
                            MessageBox.Show("Staff Updated");
                        }
                        catch
                        {
                            MessageBox.Show("Error While Updating");
                        }
                    }

                    else if (count5 == 0)
                    {
                        MessageBox.Show("Invalid Email Address");
                    }
                    else
                    {
                        MessageBox.Show("New customer not added");
                    }

                }
                else if (ID.Length < 13)
                {
                    MessageBox.Show("Invalid Legnth of ID Number");
                }
                else if (Phone.Length < 12)
                {
                    MessageBox.Show("Invalid Legnth of Phone Number");

                }

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Canceled To Updat Staff");
            }

        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.varsityPharmacyDataSet.Staff);
            // TODO: This line of code loads data into the 'varsityPharmacyDataSet.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.varsityPharmacyDataSet.Staff);
            
        }

        private void button1_Click(object sender, EventArgs e){

            DialogResult result = MessageBox.Show("Do You Want To Add Staff ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {

                int count0 = 0;
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;

                string ID = staffID.Text;
                string Phone = staffPhone.Text;
                int ID_Num;
                int Date;
                int Year;
                int Month;
                int Day;

                if (ID.Length == 13 && Phone.Length == 12)
                {
                    ID = staffID.Text.Substring(0, 6);
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


                    for (int i = 0; i < staffEmail.Text.Length; i++)
                    {
                        if (staffEmail.Text[i] == '@' && (staffEmail.Text.EndsWith(".com") || staffEmail.Text.EndsWith(".co.za")))
                        {
                            count5++;
                            break;
                        }
                    }

                    

                    if (count0 == 1 && (count1 == 1 || count2 == 1 || count3 == 1 || count4 == 1) && count5 == 1)
                    {
                        this.staffTableAdapter.InsertQuery(staffName.Text, comboBox1.SelectedItem.ToString(), staffPhone.Text, staffEmail.Text, staffID.Text, staffPassword.Text, Status);
                        this.staffTableAdapter.Fill(this.varsityPharmacyDataSet.Staff);
                        staffName.Clear();
                        staffID.Clear();
                        staffPassword.Clear();
                        staffPhone.Clear();
                        staffEmail.Clear();
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        textBox1.Clear();
                        MessageBox.Show("New Staff Added");
                    }

                    else if (count5 == 0)
                    {
                        MessageBox.Show("Invalid Email Address");
                    }
                    else
                    {
                        MessageBox.Show("New customer not added");
                    }

                }
                else if ( ID.Length < 13 )
                {
                    MessageBox.Show("Invalid Legnth of ID Number");
                }else if (Phone.Length < 12)
                {
                    MessageBox.Show("Invalid Legnth of Phone Number");

                }

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Canceled To Add New Staff!");
            }
           

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            staffName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            staffID.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            staffPassword.Text =dataGridView1.CurrentRow.Cells[6].Value.ToString();
            staffPhone.Text =dataGridView1.CurrentRow.Cells[3].Value.ToString();
            staffEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            

            Status = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            
            if (Status.Equals("Active")) {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton1_CheckedChanged_1(sender, e);
                
            }
            else if (Status.Equals("Deactive"))
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
                radioButton2_CheckedChanged_1(sender, e);
            }
        }

        

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
           
            String name = "%" + searchBox.Text + "%";
            this.staffTableAdapter.FillBy(this.varsityPharmacyDataSet.Staff, name);

        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            
            MainMenu form2 = new MainMenu();
            this.Hide();
            form2.Show();
        }

        


        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton1.Text = "Activated";
            Status = "Active";
            radioButton2.Text = "Deactivate";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton2.Text = "Deactivated";
            Status = "Deactive";
            radioButton1.Text = "Activate";
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want To Update Staff ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    this.staffTableAdapter.DeleteQuery(Int32.Parse(textBox1.Text));
                    this.staffTableAdapter.Fill(this.varsityPharmacyDataSet.Staff);
                    staffName.Clear();
                    staffID.Clear();
                    staffPassword.Clear();
                    staffPhone.Clear();
                    staffEmail.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    textBox1.Clear();
                    MessageBox.Show("Staff Deleted Successfully!");
                }
                catch
                {
                    MessageBox.Show("Error While Deleting a Staff");
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Canceled To Delete Staff!");
            }
        }
    }
}