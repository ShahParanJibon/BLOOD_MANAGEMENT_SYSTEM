using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class PDonor : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public PDonor()
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
        {/*
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
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // This should navigate to the main dashboard or close the form
            // Assuming Pdashboard is your main dashboard form
           // Pdashboard pdashboard = new Pdashboard();
            //pdashboard.Show();
            //this.Close();
        }

        private void DLastDonationDate_ValueChanged(object sender, EventArgs e)
        {
            // Optional: Add any logic needed when date changes
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Pdashboard pdashboard = new Pdashboard();
            pdashboard.Show();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        // Add navigation methods similar to Donor form if needed

    }
    }
