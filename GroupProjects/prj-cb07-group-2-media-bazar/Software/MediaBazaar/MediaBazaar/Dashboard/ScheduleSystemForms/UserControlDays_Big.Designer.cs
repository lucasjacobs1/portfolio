using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ScheduleSystemForms
{
    partial class UserControlDays_Big
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerSchedule = new System.Windows.Forms.Timer(this.components);
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.horizontalLine3 = new MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine();
            this.PnMorning = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnAfterNoon = new System.Windows.Forms.TableLayoutPanel();
            this.pnEvening = new System.Windows.Forms.TableLayoutPanel();
            this.horizontalLine1 = new MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerSchedule
            // 
            this.timerSchedule.Tick += new System.EventHandler(this.timerSchedule_Tick);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // horizontalLine3
            // 
            this.horizontalLine3.BackColor = System.Drawing.Color.Black;
            this.horizontalLine3.LineColor = System.Drawing.Color.Black;
            this.horizontalLine3.Location = new System.Drawing.Point(0, 157);
            this.horizontalLine3.MaximumSize = new System.Drawing.Size(1000, 2);
            this.horizontalLine3.Name = "horizontalLine3";
            this.horizontalLine3.Size = new System.Drawing.Size(100, 2);
            this.horizontalLine3.TabIndex = 3;
            this.horizontalLine3.Text = "horizontalLine3";
            // 
            // PnMorning
            // 
            this.PnMorning.BackColor = System.Drawing.Color.LightCyan;
            this.PnMorning.ColumnCount = 1;
            this.PnMorning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PnMorning.Location = new System.Drawing.Point(0, 27);
            this.PnMorning.Name = "PnMorning";
            this.PnMorning.RowCount = 5;
            this.PnMorning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.01961F));
            this.PnMorning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.98039F));
            this.PnMorning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.PnMorning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.PnMorning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.PnMorning.Size = new System.Drawing.Size(100, 132);
            this.PnMorning.TabIndex = 1;
            this.PnMorning.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnMorning_MouseDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 29);
            this.panel1.TabIndex = 4;
            // 
            // pnAfterNoon
            // 
            this.pnAfterNoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.pnAfterNoon.ColumnCount = 1;
            this.pnAfterNoon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnAfterNoon.Location = new System.Drawing.Point(0, 161);
            this.pnAfterNoon.Name = "pnAfterNoon";
            this.pnAfterNoon.RowCount = 6;
            this.pnAfterNoon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.42424F));
            this.pnAfterNoon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.57576F));
            this.pnAfterNoon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnAfterNoon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.pnAfterNoon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.pnAfterNoon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.pnAfterNoon.Size = new System.Drawing.Size(100, 180);
            this.pnAfterNoon.TabIndex = 5;
            this.pnAfterNoon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnAfterNoon_MouseDown_1);
            // 
            // pnEvening
            // 
            this.pnEvening.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnEvening.ColumnCount = 1;
            this.pnEvening.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnEvening.Location = new System.Drawing.Point(0, 342);
            this.pnEvening.Name = "pnEvening";
            this.pnEvening.RowCount = 6;
            this.pnEvening.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.96104F));
            this.pnEvening.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.03896F));
            this.pnEvening.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnEvening.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.pnEvening.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.pnEvening.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnEvening.Size = new System.Drawing.Size(100, 158);
            this.pnEvening.TabIndex = 6;
            this.pnEvening.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnEvening_MouseDown_1);
            // 
            // horizontalLine1
            // 
            this.horizontalLine1.BackColor = System.Drawing.Color.Black;
            this.horizontalLine1.LineColor = System.Drawing.Color.Black;
            this.horizontalLine1.Location = new System.Drawing.Point(0, 339);
            this.horizontalLine1.MaximumSize = new System.Drawing.Size(1000, 2);
            this.horizontalLine1.Name = "horizontalLine1";
            this.horizontalLine1.Size = new System.Drawing.Size(100, 2);
            this.horizontalLine1.TabIndex = 7;
            this.horizontalLine1.Text = "horizontalLine1";
            // 
            // UserControlDays_Big
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.horizontalLine3);
            this.Controls.Add(this.horizontalLine1);
            this.Controls.Add(this.pnEvening);
            this.Controls.Add(this.pnAfterNoon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnMorning);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UserControlDays_Big";
            this.Size = new System.Drawing.Size(100, 500);
            this.Load += new System.EventHandler(this.UserControlDays_Big_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlDays_Big_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControlDays_Big_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerSchedule;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine horizontalLine3;
        private TableLayoutPanel PnMorning;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel pnAfterNoon;
        private TableLayoutPanel pnEvening;
        private MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine horizontalLine1;
    }
}
