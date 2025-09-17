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
    public partial class PRegister : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public PRegister()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text; 
            string password = textBox2.Text; 
            string mobileNo = textBox3.Text; 

           
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(mobileNo))
            {
                MessageBox.Show("Please fill in all the fields before proceeding.");
                return;
            }

            // SQL query to insert data into the RegisterTb table
            string query = "INSERT INTO [dbo].[RegisterTb] (UserName, Password, MobileNo) VALUES (@UserName, @Password, @MobileNo)";

            try
            {
               
                Con.Open();
               
                SqlCommand command = new SqlCommand(query, Con);
              
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@MobileNo", mobileNo);

               
                command.ExecuteNonQuery();

               
                MessageBox.Show("You have been registered successfully!");
            }
            catch (SqlException sqlEx)
            {
               
                MessageBox.Show($"Oops! Something went wrong with the database. Please try again. Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"An unexpected error occurred. Please try again. Error: {ex.Message}");
            }
            finally
            {
                
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"We encountered an issue while navigating to the login page. Please try again later. Error: {ex.Message}");
            }
        }
    }
}
