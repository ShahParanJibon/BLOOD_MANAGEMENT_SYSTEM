using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Bloodstock : Form
    {
        public Bloodstock()
        {
            InitializeComponent();
            bloodStock();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        // Method to load blood stock
        private void bloodStock()
        {
            try
            {
                Con.Open();
                string Query = "SELECT * FROM BloodTb1"; // Query to fetch all blood stock
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                var ds = new DataSet();
                sda.Fill(ds);

                // Check if data exists
                if (ds.Tables[0].Rows.Count > 0)
                {
                    BloodStockDGV.DataSource = ds.Tables[0]; // Bind the data to DataGridView
                }
                else
                {
                    MessageBox.Show("No blood stock data found!"); // Notify if no data is found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blood stock: " + ex.Message); // Show error message
            }
            finally
            {
                Con.Close(); // Close connection
            }
        }

        // ============ NAVIGATION METHODS ============

        // DASHBOARD NAVIGATION
        private void label8_Click_1(object sender, EventArgs e)
        {
            Dashboard_cs dashboard_Cs = new Dashboard_cs();
            dashboard_Cs.Show();
            this.Hide();
        }

        // BLOOD TRANSFER NAVIGATION
        private void label7_Click_1(object sender, EventArgs e)
        {
            BloodTransfer bloodTransfer = new BloodTransfer();
            bloodTransfer.Show();
            this.Hide();
        }

        // VIEW DONORS NAVIGATION
        private void label4_Click_1(object sender, EventArgs e)
        {
            ViewDonor donateBlood1 = new ViewDonor();
            donateBlood1.Show();
            this.Hide();
        }

        // PATIENT NAVIGATION
        private void label3_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        // VIEW PATIENTS NAVIGATION
        private void label5_Click_1(object sender, EventArgs e)
        {
            Viewpatients Vw = new Viewpatients();
            Vw.Show();
            this.Hide();
        }

        // DONOR NAVIGATION
        private void label2_Click_1(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        // DONATE BLOOD NAVIGATION
        private void label11_Click_1(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
            this.Hide();
        }

        // BLOOD STOCK NAVIGATION - CRITICAL FIX!
        // This should REFRESH the data since we're already on Blood Stock page
        private void label6_Click(object sender, EventArgs e)
        {
            // Refresh the blood stock data
            bloodStock();
            MessageBox.Show("Blood Stock data refreshed!"); // Optional: for debugging
        }

        // FILTER BY BLOOD GROUP
        private void label16_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string Query = "SELECT * FROM BloodTb1 WHERE BGroup = @BGroup"; // Query to filter by blood group
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);

                // Check if a blood group is selected
                if (DBGroupCB.SelectedItem != null)
                {
                    sda.SelectCommand.Parameters.AddWithValue("@BGroup", DBGroupCB.SelectedItem.ToString().Trim());
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    BloodStockDGV.DataSource = ds.Tables[0]; // Bind filtered data to DataGridView
                }
                else
                {
                    MessageBox.Show("Please select a blood group."); // Prompt user to select a blood group
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Show error message if any
            }
            finally
            {
                Con.Close(); // Close connection
            }
        }

        // LOGOUT
        private void label9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
