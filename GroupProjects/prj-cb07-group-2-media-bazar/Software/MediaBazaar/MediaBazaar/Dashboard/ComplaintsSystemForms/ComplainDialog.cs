using MediaBazaar.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ComplaintsSystemForms
{
    public partial class ComplainDialog : Form
    {
        Complaint compl;
        public ComplainDialog(Complaint c)
        {
            InitializeComponent();
            compl = c;
            if (c.Anonymous == 0)
            {
                complainerLbl.Text = c.Complainer.ToString();
            }
            else
            {
                complainerLbl.Text = "Anonymous";
            }
            emailBox.Text = compl.Complain;
            phoneBox.Text = compl.Phone.ToString();
            StreetBox.Text = compl.Topic;
            CityBox.Text = compl.Receiver;
            HousenumberBox.Text = compl.ToALL.ToString();
            PostalCodeBox.Text = compl.Joker;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            //Solve and archive
            ComplainManagement complainManagement = new ComplainManagement();
            
            if(complainManagement.SolveAndArchieveComplaint(compl.Id,compl.EmployeeId, compl.Complain, compl.Topic, compl.Receiver, compl.Joker, compl.ToALL.ToString(), compl.Phone))
            {
                NotificationSystem.NotificationController.Alert("Successfully", NotificationSystem.Form_Alert.enmType.Success);
                this.Close();
            } else
            {
                NotificationSystem.NotificationController.Alert("Error", NotificationSystem.Form_Alert.enmType.Error);
            }
            complainManagement.DeleteRequestUpdateInformationEmp(compl.Id);
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ComplainDialog_Load(object sender, EventArgs e)
        {

        }

        private void ComplainDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void BtnDisapprove_Click(object sender, EventArgs e)
        {
            ComplainManagement complainManagement = new ComplainManagement();
            if (complainManagement.DeleteRequestUpdateInformationEmp(compl.Id))
            {
                NotificationSystem.NotificationController.Alert("Successfully", NotificationSystem.Form_Alert.enmType.Success);
                this.Close();
            }
            else
            {
                NotificationSystem.NotificationController.Alert("Error", NotificationSystem.Form_Alert.enmType.Error);
            }
        }
    }
}
