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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin Adm = new AdminLogin();
            Adm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open the connection
            Con.Open();

            // Query for Employee login validation
            string empQuery = "SELECT COUNT(*) FROM [dbo].[EmployeeTb1] WHERE EmpName=@UserName AND EmpPass=@Password";
            SqlCommand empCmd = new SqlCommand(empQuery, Con);
            empCmd.Parameters.AddWithValue("@UserName", EmpNameTb.Text);
            empCmd.Parameters.AddWithValue("@Password", EmpPassTb.Text);

            int empResult = (int)empCmd.ExecuteScalar();

            // Query for PRegister login validation
            string pRegisterQuery = "SELECT COUNT(*) FROM [dbo].[RegisterTb] WHERE UserName=@UserName AND Password=@Password";
            SqlCommand pRegisterCmd = new SqlCommand(pRegisterQuery, Con);
            pRegisterCmd.Parameters.AddWithValue("@UserName", EmpNameTb.Text);
            pRegisterCmd.Parameters.AddWithValue("@Password", EmpPassTb.Text);

            int pRegisterResult = (int)pRegisterCmd.ExecuteScalar();

            if (empResult == 1)
            {
                // Employee login success, show Mainform
                Mainform mainForm = new Mainform();
                mainForm.Show();
                this.Hide();
            }
            else if (pRegisterResult == 1)
            {
                // PRegister login success, show PDashboard
                Pdashboard pDashboard = new Pdashboard();
                pDashboard.Show();
                this.Hide();
            }
            else
            {
                // Show error message for invalid credentials
                MessageBox.Show("Wrong UserName or Password");
            }

            // Close the connection
            Con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PRegister pRegister = new PRegister();
            pRegister.Show();
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showPass.Checked)
            {
                EmpPassTb.PasswordChar = '\0';
            }
            else
            {
               EmpPassTb.PasswordChar = '*';
            }
        }
    }
}