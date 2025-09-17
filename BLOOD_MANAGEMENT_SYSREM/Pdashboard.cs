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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Pdashboard : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public Pdashboard()
        {
            InitializeComponent();
            CreateReviewsTable();
        }

        private void CreateReviewsTable()
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    Con.Open();
                    string query = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ReviewsTb1')
                        BEGIN
                            CREATE TABLE ReviewsTb1 (
                                ReviewId INT IDENTITY(1,1) PRIMARY KEY,
                                UserType VARCHAR(20) NOT NULL,
                                Rating VARCHAR(50) NOT NULL,
                                ReviewText VARCHAR(MAX) NOT NULL,
                                ReviewDate DATETIME DEFAULT GETDATE(),
                                UserName VARCHAR(100) NULL
                            )
                        END";

                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating reviews table: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hide review panel initially
            panel7.Visible = false;
            pictureBox2.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            PDonor pDonor = new PDonor();
            pDonor.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Patients patients = new Patients();
            patients.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Show review panel and hide picture
            panel7.Visible = true;
            pictureBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Please provide both rating and review text.");
                return;
            }

            try
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    Con.Open();
                    string query = "INSERT INTO ReviewsTb1 (UserType, Rating, ReviewText, UserName) " +
                                  "VALUES (@UserType, @Rating, @ReviewText, @UserName)";

                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        // You can modify this to get actual user type and name from your system
                        cmd.Parameters.AddWithValue("@UserType", "Donor/Patient");
                        cmd.Parameters.AddWithValue("@Rating", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@ReviewText", richTextBox1.Text);
                        cmd.Parameters.AddWithValue("@UserName", "Anonymous User");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thank you for your review! Your feedback is valuable to us.");

                        // Clear fields
                        comboBox1.SelectedIndex = -1;
                        richTextBox1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving review: " + ex.Message);
            }
        }

        // Optional: Method to view all reviews (you can add this as another feature)
        private void ViewAllReviews()
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    Con.Open();
                    string query = "SELECT * FROM ReviewsTb1 ORDER BY ReviewDate DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, Con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // You can display this in a DataGridView or another form
                    MessageBox.Show($"Total reviews: {dt.Rows.Count}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reviews: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}