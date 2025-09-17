using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            //MessageBox.Show("Splash form initialized");
        }

        int startpos = 0;

        // This event handler updates the progress bar
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            MyProgress.Value = startpos;  // Update progress bar value

            // When the progress reaches 50, stop the timer and show the login form
            if (MyProgress.Value == 50)
            {
                MyProgress.Value = 0;
                timer1.Stop();  // Stop the timer
                Login login = new Login();  // Instantiate the login form
                login.Show();  // Show the login form
                this.Hide();  // Hide the splash form
            }
        }

        // This method starts the timer when the splash form loads
        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();  // Start the timer to begin updating the progress bar
        }
    }
}
