namespace MediaBazaar.Dashboard.ComplaintsSystemForms
{
    partial class AdminComplaintForm
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
            this.complainsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // complainsPanel
            // 
            this.complainsPanel.Location = new System.Drawing.Point(12, 12);
            this.complainsPanel.Name = "complainsPanel";
            this.complainsPanel.Size = new System.Drawing.Size(846, 433);
            this.complainsPanel.TabIndex = 0;
            // 
            // AdminComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(870, 457);
            this.Controls.Add(this.complainsPanel);
            this.Name = "AdminComplaintForm";
            this.Text = "AdminComplaintForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel complainsPanel;
    }
}