
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard
{
    public partial class Dashboard : Form
    {
        Employee loggedEmployee; 
        public Dashboard(Employee e)
        {
            InitializeComponent();
            
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            loggedEmployee = e;
            DashboardForms.DashboardMain fm = new DashboardForms.DashboardMain(e);
            BringFormPanel(fm);
            ShowCorrectDashboard();
        }
       
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        private void ShowCorrectDashboard()
        {
            //MANAGERS/ADMINS
            if (loggedEmployee.Role == 0 || loggedEmployee.Role == 1)
            {

            }   
            else if(loggedEmployee.Role == 2)
            {
                itemsBtn.Visible = false;
            }
            //DEPOT and STORE WORKER
            else if(loggedEmployee.Role == 3 || loggedEmployee.Role == 4)
            {
                employeeBtn.Visible = false;
                button1.Visible = false;
            }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
       
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();
        }
 
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Red, sizeGripRectangle);
        }
       
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Alert!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Alert!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

      
      

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 230)
                this.tmExpandirMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width + 5;
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 230)
            {
                this.tmContraerMenu.Start();
            }
            else if (panelMenu.Width == 50)
            {
                this.tmExpandirMenu.Start();
            }

        }

        private void employeeBtn_Click(object sender, EventArgs e)
        {
            EmployeeSystemForms.EmployeeForm fm = new EmployeeSystemForms.EmployeeForm();
            BringFormPanel(fm);
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardForms.DashboardMain fm = new DashboardForms.DashboardMain(loggedEmployee);
            BringFormPanel(fm);
        }

        private void reservationsBtn_Click(object sender, EventArgs e)
        {
            if(loggedEmployee.Role == 0 || loggedEmployee.Role == 1 || loggedEmployee.Role == 2)
            {
                ComplaintsSystemForms.AdminComplaintForm fm = new ComplaintsSystemForms.AdminComplaintForm(loggedEmployee);
                BringFormPanel(fm);
            }
            else
            {
                ComplaintsSystemForms.EmployeeComplaintForm fm = new ComplaintsSystemForms.EmployeeComplaintForm(loggedEmployee.ID);
                BringFormPanel(fm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationKeySystem.KeySystemForm key = new RegistrationKeySystem.KeySystemForm();
            BringFormPanel(key);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
           
        }

        private void locationsBtn_Click(object sender, EventArgs e)
        {
            if (loggedEmployee.Role == 0 || loggedEmployee.Role == 1 || loggedEmployee.Role == 2)
            {
                ScheduleSystemForms.Form1 fm = new ScheduleSystemForms.Form1(loggedEmployee,0,"Weekly");
                BringFormPanel(fm);
            }
            else
            {
                ScheduleSystemForms.Form1 fm = new ScheduleSystemForms.Form1(loggedEmployee, 1, "Weekly");
                BringFormPanel(fm);
            }
        }

        private void itemsBtn_Click(object sender, EventArgs e)
        {
            if(loggedEmployee.Role == 4)
            {
                ProductsSystemForms.ReshelfRequestSending productMain = new ProductsSystemForms.ReshelfRequestSending();
                BringFormPanel(productMain);
            }
            else if(loggedEmployee.Role == 3)
            {
                ProductsSystemForms.CashierForm productMain = new ProductsSystemForms.CashierForm();
                BringFormPanel(productMain);
            }
            else
            {
                ProductsSystemForms.ProductMain productMain = new ProductsSystemForms.ProductMain();
                BringFormPanel(productMain);
            }
            
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 50)
                this.tmContraerMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width - 5;
        }

       

        private void BringFormPanel(object formHijo)
        {
            if (this.panelContenedorForm.Controls.Count > 0)
                this.panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;            
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }

       

       

      
      
 

    }
}
