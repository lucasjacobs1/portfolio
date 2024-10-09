using MediaBazaar.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.EmployeeSystemForms
{
    public partial class EditEmployeeDialog : Form
    {
        Employee e;
        int editType;
        private string key;
        //edittype2
        public EditEmployeeDialog(string key,int Type)
        {

            InitializeComponent();
            editType = Type;
            saveBtn.Text = "Register";
            this.key = key;
            comboBox1.DataSource = Enum.GetValues(typeof(Employee.RolesEnumeration));

        }
  
        public EditEmployeeDialog(Employee e,int editType)
        {
            InitializeComponent();
            this.e = e;
            this.editType = editType;
            //edit type 0 means that its by an admin from employee list
            FillData();
            if (editType == 0)
            {
                panel4.Visible = false;
                this.Size = this.MaximumSize;
            }
            //edit type 1 means that its by an user trying to edit his info
            else if (editType == 1)
            {
                panel9.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel2.Visible = false;
                this.Size = this.MinimumSize;
            }
            //edit type 3
            else if(editType == 3)
            {
                this.editType = editType;
                saveBtn.Text = "Approve";
                closeBtn.Text = "Reject";
                FirstNameBox.Enabled = false;
                emailBox.Enabled = false;
                panel4.Visible = false;
                salaryBox.Enabled = false;
                bsnBox.Enabled = false;
                phoneBox.Enabled = false;
                comboBox1.Enabled = false;
                StreetBox.Enabled = false;
                comboBox1.DataSource = Enum.GetValues(typeof(Employee.RolesEnumeration));

            }
        }
        private void FillData()
        {
            FirstNameBox.Text = e.FirstName;
            LastNameBox.Text = e.LastName;
            emailBox.Text = e.Email;
            StreetBox.Text = e.Street;
            CityBox.Text = e.City;
            HousenumberBox.Text = e.HouseNumber.ToString();
            PostalCodeBox.Text = e.PostalCode;
            FTEBox.Text = e.FTE.ToString();
            salaryBox.Text = e.Salary.ToString();
            bsnBox.Text = e.Bsn.ToString();
            phoneBox.Text = e.Phonenumber.ToString();
            comboBox1.DataSource = Enum.GetValues(typeof(Employee.RolesEnumeration));
            comboBox1.SelectedIndex = e.Role;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void EditEmployeeDialog_Load(object sender, EventArgs e)
        {

        }

        private void EditEmployeeDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if(editType==2)
            {
                this.Close();
                LoginMain loginMain = new LoginMain();
                loginMain.Show();
            }
            else if (editType==3)
            {
                EmployeeManagement employeeManagement = new EmployeeManagement();
                if (employeeManagement.RejectEmployee(this.e.ID))
                {
                    NotificationSystem.NotificationController.Alert("Successfully rejected", NotificationSystem.Form_Alert.enmType.Success);
                    this.Close();
                }
                else
                {
                    NotificationSystem.NotificationController.Alert("Error", NotificationSystem.Form_Alert.enmType.Error);
                }
            }
            else
            {
                this.Close();
            }
            
        }
        private void UpdateEmployeeInfo(int edittype)
        {
            Data_Layer.UserDAL userDAL = new Data_Layer.UserDAL();

            if (passwordBox.Text != "")
            {
                string newPassword = Logic_Layer.UserHelper.CreateMD5(passwordBox.Text).ToLower();
               
                Employee e = new Employee(this.e.ID,FirstNameBox.Text, LastNameBox.Text, StreetBox.Text, CityBox.Text, PostalCodeBox.Text, HousenumberBox.Text,emailBox.Text,  Convert.ToDouble(salaryBox.Text), Convert.ToInt32(bsnBox.Text), Convert.ToInt32(phoneBox.Text), Convert.ToInt32(comboBox1.SelectedIndex), Convert.ToDouble(FTEBox.Text));
                if (userDAL.EditEmployeeWithPassword(e, newPassword))
                {
                    NotificationSystem.NotificationController.Alert("Done", NotificationSystem.Form_Alert.enmType.Success);

                    this.Close();
                }
                else { NotificationSystem.NotificationController.Alert("Error", NotificationSystem.Form_Alert.enmType.Error); }
            }
            else
            {
                Employee e = new Employee(this.e.ID, FirstNameBox.Text, LastNameBox.Text, StreetBox.Text, CityBox.Text, PostalCodeBox.Text, HousenumberBox.Text, emailBox.Text, Convert.ToDouble(salaryBox.Text), Convert.ToInt32(bsnBox.Text), Convert.ToInt32(phoneBox.Text), Convert.ToInt32(comboBox1.SelectedIndex), Convert.ToDouble(FTEBox.Text));
                if (userDAL.EditEmployeeWithoutPassword(e))
                {
                    NotificationSystem.NotificationController.Alert("Done", NotificationSystem.Form_Alert.enmType.Success);
                    this.Close();
                }
                else { NotificationSystem.NotificationController.Alert("Error", NotificationSystem.Form_Alert.enmType.Error); }

            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(editType == 3)
            {
                EmployeeManagement employeeManagement = new EmployeeManagement();
                if(employeeManagement.ApproveEmployee(this.e.ID))
                {
                    NotificationSystem.NotificationController.Alert("Successfully approved", NotificationSystem.Form_Alert.enmType.Success);
                    this.Close();
                }
                else
                {
                    NotificationSystem.NotificationController.Alert("Error", NotificationSystem.Form_Alert.enmType.Error);
                    this.Close();
                }
                
            }
           else if(editType == 2)
            {
                
                string Password = Logic_Layer.UserHelper.CreateMD5(passwordBox.Text).ToLower();
                Employee employe = new Employee(this.e.ID, FirstNameBox.Text, LastNameBox.Text, StreetBox.Text, CityBox.Text, PostalCodeBox.Text, HousenumberBox.Text, emailBox.Text, Convert.ToDouble(salaryBox.Text), Convert.ToInt32(bsnBox.Text), Convert.ToInt32(phoneBox.Text), Convert.ToInt32(comboBox1.SelectedIndex), Convert.ToDouble(FTEBox.Text));
                EmployeeManagement employeeManagement = new EmployeeManagement();
                employeeManagement.AddEmployee(employe, Password);
                KeySystemData keySystemData = new KeySystemData();
                keySystemData.MarkKeyAsUsed(this.key, FirstNameBox.Text);
                NotificationSystem.NotificationController.Alert("Successfully registered", NotificationSystem.Form_Alert.enmType.Success);

                this.Close();
                LoginMain loginMain = new LoginMain();
                loginMain.Show();
            }
            else
            {
                UpdateEmployeeInfo(editType);
            }
            
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
