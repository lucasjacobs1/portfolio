using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ScheduleSystemForms
{
    partial class EventForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEmp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(187, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Employee to selected date";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(187, 168);
            this.tbDate.Name = "tbDate";
            this.tbDate.PlaceholderText = "Date..";
            this.tbDate.Size = new System.Drawing.Size(267, 23);
            this.tbDate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(187, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Date:";
            // 
            // cbDepartment
            // 
            this.cbDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDepartment.ForeColor = System.Drawing.SystemColors.Window;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(12, 46);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(139, 23);
            this.cbDepartment.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pick a depertment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Pick an employee";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbEmp
            // 
            this.cbEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.cbEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEmp.ForeColor = System.Drawing.SystemColors.Window;
            this.cbEmp.FormattingEnabled = true;
            this.cbEmp.Location = new System.Drawing.Point(12, 129);
            this.cbEmp.Name = "cbEmp";
            this.cbEmp.Size = new System.Drawing.Size(139, 23);
            this.cbEmp.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(12, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Pick a shift type:";
            // 
            // cbShift
            // 
            this.cbShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.cbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShift.ForeColor = System.Drawing.SystemColors.Window;
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Items.AddRange(new object[] {
            "Morning",
            "Afternoon",
            "Evening"});
            this.cbShift.Location = new System.Drawing.Point(12, 212);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(139, 23);
            this.cbShift.TabIndex = 15;
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(466, 280);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbShift);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEmp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.button1);
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventForm_FormClosing);
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button1;
        private TextBox tbDate;
        private Label label1;
        private ComboBox cbDepartment;
        private Label label2;
        private Label label3;
        private ComboBox cbEmp;
        private Label label4;
        private ComboBox cbShift;
    }
}