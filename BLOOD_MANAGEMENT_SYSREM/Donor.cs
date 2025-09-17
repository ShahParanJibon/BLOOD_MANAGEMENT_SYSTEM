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

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Donor : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public Donor()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhoneTb.Text = "";
            DGenderCb.SelectedIndex = -1;
            DBGroupCB.SelectedIndex = -1;
            DAddressTb.Text = "";
            DLastDonationDate.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || DPhoneTb.Text == "" || DAgeTb.Text == "" || DGenderCb.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string lastDonationDate = DLastDonationDate.Value.ToString("yyyy-MM-dd");

                    using (SqlConnection Con = new SqlConnection(connectionString))
                    {
                        Con.Open();
                        string query = "INSERT INTO DonorTb1 (DName, DAge, DGender, DPhone, DAddress, DBGroup, LastDonationDate) " +
                                      "VALUES (@DName, @DAge, @DGender, @DPhone, @DAddress, @DBGroup, @LastDonationDate)";

                        using (SqlCommand cmd = new SqlCommand(query, Con))
                        {
                            cmd.Parameters.AddWithValue("@DName", DNameTb.Text);
                            cmd.Parameters.AddWithValue("@DAge", Convert.ToInt32(DAgeTb.Text));
                            cmd.Parameters.AddWithValue("@DGender", DGenderCb.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@DPhone", DPhoneTb.Text);
                            cmd.Parameters.AddWithValue("@DAddress", DAddressTb.Text);
                            cmd.Parameters.AddWithValue("@DBGroup", DBGroupCB.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@LastDonationDate", lastDonationDate);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Donor Successfully Saved");
                            Reset();
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error: " + Ex.Message);
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor viewDonor = new ViewDonor();
            viewDonor.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients viewpatients = new Viewpatients();
            viewpatients.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bloodstock bloodstock = new Bloodstock();
            bloodstock.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodtransfer = new BloodTransfer();
            bloodtransfer.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard_cs dashboard_Cs = new Dashboard_cs();
            dashboard_Cs.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }
    }
}