
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

    public partial class Dashboard_cs : Form

    {

        public Dashboard_cs()

        {

            InitializeComponent();

            GetData();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahp\OneDrive - American International University-Bangladesh\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void GetData()

        {

            try

            {

                Con.Open();

                // Donor Count

                SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTb1", Con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                DonorLbl.Text = dt.Rows[0][0].ToString();

                // Transfer Count

                SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTb1", Con);

                DataTable dt1 = new DataTable();

                sda1.Fill(dt1);

                TransferLbl.Text = dt1.Rows[0][0].ToString();

                // Employee Count

                SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from EmployeeTb1", Con);

                DataTable dt2 = new DataTable();

                sda2.Fill(dt2);

                EmployeeLbl.Text = dt2.Rows[0][0].ToString();

                // Total Blood Stock

                SqlDataAdapter sda3 = new SqlDataAdapter("Select Sum(BStock) from BloodTb1", Con);

                DataTable dt3 = new DataTable();

                sda3.Fill(dt3);

                int BStock = 0;

                if (dt3.Rows[0][0] != DBNull.Value)

                {

                    BStock = Convert.ToInt32(dt3.Rows[0][0]);

                }

                TotalLbl.Text = BStock.ToString();

                // O+ Blood Stock

                SqlDataAdapter sda4 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='O+'", Con);

                DataTable dt4 = new DataTable();

                sda4.Fill(dt4);

                OplusNumLbl.Text = (dt4.Rows.Count > 0) ? dt4.Rows[0][0].ToString() : "0";

                double OplusPercentage = (BStock > 0 && dt4.Rows.Count > 0) ? (Convert.ToDouble(dt4.Rows[0][0]) / BStock) * 100 : 0;

                OPlusProgress.Value = Convert.ToInt32(OplusPercentage);

                // AB+ Blood Stock

                SqlDataAdapter sda5 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='AB+'", Con);

                DataTable dt5 = new DataTable();

                sda5.Fill(dt5);

                ABPlusLBL.Text = (dt5.Rows.Count > 0) ? dt5.Rows[0][0].ToString() : "0";

                double ABplusPercentage = (BStock > 0 && dt5.Rows.Count > 0) ? (Convert.ToDouble(dt5.Rows[0][0]) / BStock) * 100 : 0;

                ABPlusProgressLbl.Value = Convert.ToInt32(ABplusPercentage);

                // O- Blood Stock

                SqlDataAdapter sda6 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='O-'", Con);

                DataTable dt6 = new DataTable();

                sda6.Fill(dt6);

                ONegLbl.Text = (dt6.Rows.Count > 0) ? dt6.Rows[0][0].ToString() : "0";

                double ONegPercentage = (BStock > 0 && dt6.Rows.Count > 0) ? (Convert.ToDouble(dt6.Rows[0][0]) / BStock) * 100 : 0;

                ONegProgressLbl.Value = Convert.ToInt32(ONegPercentage);

                // AB- Blood Stock

                SqlDataAdapter sda7 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='AB-'", Con);

                DataTable dt7 = new DataTable();

                sda7.Fill(dt7);

                ABPNegLbl.Text = (dt7.Rows.Count > 0) ? dt7.Rows[0][0].ToString() : "0";

                double ABPpercentage = (BStock > 0 && dt7.Rows.Count > 0) ? (Convert.ToDouble(dt7.Rows[0][0]) / BStock) * 100 : 0;

                ABNegProgressLbl.Value = Convert.ToInt32(ABPpercentage);

            }

            catch (Exception ex)

            {

                MessageBox.Show("Error loading dashboard data: " + ex.Message);

            }

            finally

            {

                Con.Close();

            }

        }

        // ============ NAVIGATION METHODS ============

        private void label2_Click(object sender, EventArgs e)

        {

            Donor donor = new Donor();

            donor.Show();

            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)

        {

            DonateBlood donateBlood = new DonateBlood();

            donateBlood.Show();

            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)

        {

            ViewDonor donor = new ViewDonor();

            donor.Show();

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

            Viewpatients Vw = new Viewpatients();

            Vw.Show();

            this.Hide();

        }

        // BLOOD STOCK NAVIGATION - Goes to Bloodstock form

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

        // DASHBOARD NAVIGATION - Refresh current data

        private void label8_Click(object sender, EventArgs e)

        {

            GetData(); // Refresh dashboard data

        }

        private void label9_Click(object sender, EventArgs e)

        {

            Login login = new Login();

            login.Show();

            this.Hide();

        }

        private void Dashboard_cs_Load(object sender, EventArgs e)

        {

            // Additional initialization if needed

        }

        private void DonorLbl_Click(object sender, EventArgs e)

        {

            // Label click event if needed

        }

    }

}
