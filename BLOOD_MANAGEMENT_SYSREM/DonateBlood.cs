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
    public partial class DonateBlood : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private int oldstock;

        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }

        private void populate()
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    Con.Open();
                    string Query = "SELECT DNum, DName, DAge, DGender, DPhone, DAddress, DBGroup, LastDonationDate FROM DonorTb1";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    DonateBloodDGV.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donors: " + ex.Message);
            }
        }

        private void bloodStock()
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    Con.Open();
                    string Query = "SELECT * FROM BloodTb1";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    BloodStockDGV.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blood stock: " + ex.Message);
            }
        }

        private void GetStock(string Bgroup)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    Con.Open();
                    string query = "SELECT BStock FROM BloodTb1 WHERE BGroup = @BGroup";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@BGroup", Bgroup);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            oldstock = Convert.ToInt32(result);
                        }
                        else
                        {
                            oldstock = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting stock: " + ex.Message);
                oldstock = 0;
            }
        }

        private bool CanDonateBlood(DateTime lastDonationDate)
        {
            return lastDonationDate.AddMonths(4) <= DateTime.Now;
        }

        private void DonateBloodDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DNameTb.Text = DonateBloodDGV.Rows[e.RowIndex].Cells["DName"].Value?.ToString() ?? "";
                DBGroupCB.Text = DonateBloodDGV.Rows[e.RowIndex].Cells["DBGroup"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(DBGroupCB.Text))
                {
                    GetStock(DBGroupCB.Text);
                }
            }
        }

        private void Reset()
        {
            DNameTb.Text = "";
            DBGroupCB.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DNameTb.Text))
            {
                MessageBox.Show("Please select a donor from the list");
                return;
            }

            if (string.IsNullOrEmpty(DBGroupCB.Text))
            {
                MessageBox.Show("Please select a blood group");
                return;
            }

            try
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    Con.Open();

                    // Check if donor exists and get last donation date
                    string checkQuery = "SELECT LastDonationDate FROM DonorTb1 WHERE DName = @DName";
                    DateTime lastDonationDate = DateTime.MinValue;
                    bool hasDonatedBefore = false;

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, Con))
                    {
                        checkCmd.Parameters.AddWithValue("@DName", DNameTb.Text);
                        object result = checkCmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            lastDonationDate = Convert.ToDateTime(result);
                            hasDonatedBefore = true;
                        }
                    }

                    // Check eligibility
                    if (hasDonatedBefore)
                    {
                        if (!CanDonateBlood(lastDonationDate))
                        {
                            DateTime eligibleAfter = lastDonationDate.AddMonths(4);
                            MessageBox.Show($"This donor cannot donate blood yet. They must wait 4 months after their last donation.\n" +
                                          $"Last donation: {lastDonationDate:dd MMM yyyy}\n" +
                                          $"Eligible after: {eligibleAfter:dd MMM yyyy}");
                            return;
                        }
                    }

                    // Get current stock
                    GetStock(DBGroupCB.Text);

                    // Update blood stock
                    int newStock = oldstock + 1;
                    string updateBloodQuery = "UPDATE BloodTb1 SET BStock = @Stock WHERE BGroup = @BGroup";
                    using (SqlCommand bloodCmd = new SqlCommand(updateBloodQuery, Con))
                    {
                        bloodCmd.Parameters.AddWithValue("@Stock", newStock);
                        bloodCmd.Parameters.AddWithValue("@BGroup", DBGroupCB.Text);
                        bloodCmd.ExecuteNonQuery();
                    }

                    // Update donor's last donation date
                    string updateDonorQuery = "UPDATE DonorTb1 SET LastDonationDate = GETDATE() WHERE DName = @DName";
                    using (SqlCommand donorCmd = new SqlCommand(updateDonorQuery, Con))
                    {
                        donorCmd.Parameters.AddWithValue("@DName", DNameTb.Text);
                        donorCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Donation Successful! Blood stock updated and donor's record has been updated.");

                    // Refresh data
                    Reset();
                    bloodStock();
                    populate();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error during donation: " + Ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor viewDonor = new ViewDonor();
            viewDonor.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
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
    }
}