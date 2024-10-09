namespace MediaBazaar.Dashboard.ComplaintsSystemForms
{
    partial class EmployeeComplaintForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.receiverPicker = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.anonymouslyCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.topicTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(268, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pick an manager : ";
            // 
            // receiverPicker
            // 
            this.receiverPicker.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.receiverPicker.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.receiverPicker.FormattingEnabled = true;
            this.receiverPicker.Items.AddRange(new object[] {
            "EVERYBODY"});
            this.receiverPicker.Location = new System.Drawing.Point(440, 43);
            this.receiverPicker.Name = "receiverPicker";
            this.receiverPicker.Size = new System.Drawing.Size(223, 33);
            this.receiverPicker.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(268, 170);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(395, 185);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(324, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Complain :";
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendButton.Location = new System.Drawing.Point(375, 402);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(172, 43);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // anonymouslyCheck
            // 
            this.anonymouslyCheck.AutoSize = true;
            this.anonymouslyCheck.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.anonymouslyCheck.ForeColor = System.Drawing.Color.Gainsboro;
            this.anonymouslyCheck.Location = new System.Drawing.Point(361, 361);
            this.anonymouslyCheck.Name = "anonymouslyCheck";
            this.anonymouslyCheck.Size = new System.Drawing.Size(190, 29);
            this.anonymouslyCheck.TabIndex = 5;
            this.anonymouslyCheck.Text = "Send anonymously";
            this.anonymouslyCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(361, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Topic :";
            // 
            // topicTxtBox
            // 
            this.topicTxtBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.topicTxtBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.topicTxtBox.Location = new System.Drawing.Point(440, 89);
            this.topicTxtBox.Name = "topicTxtBox";
            this.topicTxtBox.Size = new System.Drawing.Size(223, 33);
            this.topicTxtBox.TabIndex = 7;
            // 
            // EmployeeComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(870, 457);
            this.Controls.Add(this.topicTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.anonymouslyCheck);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.receiverPicker);
            this.Controls.Add(this.label1);
            this.Name = "EmployeeComplaintForm";
            this.Text = "EmployeeComplaintForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox receiverPicker;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.CheckBox anonymouslyCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox topicTxtBox;
    }
}