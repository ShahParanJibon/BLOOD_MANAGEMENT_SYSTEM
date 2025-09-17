using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        // SqlConnection string
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        // Variable to store the selected review ID
        private int selectedReviewId = 0;

        // Form Load event to populate reviews
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            populateReviews();
        }

        // Method to populate reviews into the DataGridView
        private void populateReviews()
        {
            try
            {
                // Ensure the connection is closed before opening
                if (Con.State == ConnectionState.Open)
                    Con.Close();

                Con.Open();
                string Query = "SELECT * FROM ReviewsTb1 ORDER BY ReviewDate DESC"; // Query to fetch reviews
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                ReviewsDGV.DataSource = ds.Tables[0]; // Bind the result to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reviews: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed in case of error
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        // Button click event to delete selected review
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedReviewId == 0)
            {
                MessageBox.Show("Please select a review to delete.");
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this review?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Ensure the connection is closed before executing the delete operation
                    if (Con.State == ConnectionState.Open)
                        Con.Close();

                    Con.Open();
                    string query = "DELETE FROM ReviewsTb1 WHERE ReviewId = @ReviewId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@ReviewId", selectedReviewId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Review successfully deleted.");
                        populateReviews(); // Refresh the data grid view
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the review.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting review: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed in case of error
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                }
            }
        }

        // Label click event to navigate to the Login page
        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        // Label click event to navigate to the Employee page
        private void label3_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Hide();
        }

        // Label click event to refresh reviews
        private void label5_Click(object sender, EventArgs e)
        {
            populateReviews();
        }

        // DataGridView CellClick event to select a review
        private void ReviewsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is clicked
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ReviewsDGV.Rows[e.RowIndex];

                // Make sure the ReviewId column exists and handle DBNull
                if (row.Cells["ReviewId"].Value != DBNull.Value)
                {
                    selectedReviewId = Convert.ToInt32(row.Cells["ReviewId"].Value);
                }
                else
                {
                    MessageBox.Show("Invalid Review ID.");
                }
            }
        }

    }
}
