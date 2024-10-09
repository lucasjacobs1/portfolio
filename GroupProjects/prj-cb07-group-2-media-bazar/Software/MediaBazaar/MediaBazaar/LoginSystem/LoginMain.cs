using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar
{
    public partial class LoginMain : Form
    {
        public LoginMain()
        {
            InitializeComponent();
            
        }
        
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitBtn_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic_Layer.UserHelper userHelper = new Logic_Layer.UserHelper();
            if(userHelper.IsValidEmail(emailBox.Text))
            {
                if (userHelper.ValidateLogin(emailBox.Text, passBox.Text))
                {
                    EmployeeManagement employeeManagement = new EmployeeManagement();
                    Employee loggedEmployee = employeeManagement.GetEmployeeByEmail(emailBox.Text);
                    Dashboard.Dashboard dashboardMain = new Dashboard.Dashboard(loggedEmployee);
                    this.Hide();
                    NotificationSystem.NotificationController.Alert("Logged in successfully", NotificationSystem.Form_Alert.enmType.Success);
                    dashboardMain.Show();
                }
                else
                {
                    NotificationSystem.NotificationController.Alert("Password is not valid", NotificationSystem.Form_Alert.enmType.Error);
                }
            }
            else
            {
                NotificationSystem.NotificationController.Alert("Email is not valid", NotificationSystem.Form_Alert.enmType.Error);
            }

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard.RegistrationKeySystem.InsertKeyDialog insertKeyDialog = new Dashboard.RegistrationKeySystem.InsertKeyDialog();
            insertKeyDialog.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
