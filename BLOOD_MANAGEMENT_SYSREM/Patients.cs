using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Patients : Form
    {
        // Connection string for your database
        private SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public Patients()
        {
            InitializeComponent();
            // Load data when form is initialized
            populate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // You can call populate() here again if needed when the form loads
        }

        // Method to populate DataGridView with patient data
        private void populate()
        {
            try
            {
                // Open the connection
                Con.Open();

                // SQL Query to select all data from PatientTb1 table
                string query = "SELECT * FROM PatientTb1";

                // SqlDataAdapter is used to fetch data and fill it in a DataTable
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataSet ds = new DataSet();

                // Fill the DataSet with the result of the query
                sda.Fill(ds);

                // Set the DataGridView data source to the filled DataTable
                PatientsDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is always closed
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        // DataGridView cell click event
        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optionally, you can handle cell clicks here, if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pdashboard pdashboard = new Pdashboard();
            pdashboard.Show();
            this.Hide();
        }
    }
}
