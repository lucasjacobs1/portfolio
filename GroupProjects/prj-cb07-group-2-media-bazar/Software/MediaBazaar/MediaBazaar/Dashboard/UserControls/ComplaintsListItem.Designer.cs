namespace MediaBazaar.Dashboard.UserControls
{
    partial class ComplaintsListItem
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
            this.advancedPanel1 = new BevelPanel.AdvancedPanel();
            this.horizontalLine1 = new MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine();
            this.verticalLine1 = new MediaBazaarSoftware.Dashboard.UserControls.VerticalLine();
            this.topicLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.complainerLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.readBtn = new System.Windows.Forms.Button();
            this.line1 = new MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine();
            this.advancedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // advancedPanel1
            // 
            this.advancedPanel1.BackgroundGradientMode = BevelPanel.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel1.Controls.Add(this.horizontalLine1);
            this.advancedPanel1.Controls.Add(this.verticalLine1);
            this.advancedPanel1.Controls.Add(this.topicLbl);
            this.advancedPanel1.Controls.Add(this.label2);
            this.advancedPanel1.Controls.Add(this.complainerLbl);
            this.advancedPanel1.Controls.Add(this.label1);
            this.advancedPanel1.Controls.Add(this.readBtn);
            this.advancedPanel1.Controls.Add(this.line1);
            this.advancedPanel1.EdgeWidth = 2;
            this.advancedPanel1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.advancedPanel1.FlatBorderColor = System.Drawing.Color.Transparent;
            this.advancedPanel1.Location = new System.Drawing.Point(8, 8);
            this.advancedPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.advancedPanel1.Name = "advancedPanel1";
            this.advancedPanel1.RectRadius = 1;
            this.advancedPanel1.ShadowColor = System.Drawing.Color.DimGray;
            this.advancedPanel1.ShadowShift = 1;
            this.advancedPanel1.ShadowStyle = BevelPanel.AdvancedPanel.ShadowMode.ForwardDiagonal;
            this.advancedPanel1.Size = new System.Drawing.Size(374, 80);
            this.advancedPanel1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.advancedPanel1.Style = BevelPanel.AdvancedPanel.BevelStyle.Flat;
            this.advancedPanel1.TabIndex = 2;
            this.advancedPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.advancedPanel1_Paint);
            // 
            // horizontalLine1
            // 
            this.horizontalLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.horizontalLine1.LineColor = System.Drawing.Color.Black;
            this.horizontalLine1.Location = new System.Drawing.Point(3, 33);
            this.horizontalLine1.MaximumSize = new System.Drawing.Size(1000, 2);
            this.horizontalLine1.Name = "horizontalLine1";
            this.horizontalLine1.Size = new System.Drawing.Size(252, 2);
            this.horizontalLine1.TabIndex = 16;
            this.horizontalLine1.Text = "horizontalLine1";
            // 
            // verticalLine1
            // 
            this.verticalLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.verticalLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.verticalLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.verticalLine1.Location = new System.Drawing.Point(253, -1);
            this.verticalLine1.MaximumSize = new System.Drawing.Size(2, 1000);
            this.verticalLine1.Name = "verticalLine1";
            this.verticalLine1.Size = new System.Drawing.Size(2, 80);
            this.verticalLine1.TabIndex = 15;
            this.verticalLine1.Text = "verticalLine1";
            // 
            // topicLbl
            // 
            this.topicLbl.AutoSize = true;
            this.topicLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.topicLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.topicLbl.Location = new System.Drawing.Point(72, 38);
            this.topicLbl.Name = "topicLbl";
            this.topicLbl.Size = new System.Drawing.Size(43, 17);
            this.topicLbl.TabIndex = 14;
            this.topicLbl.Text = "Topic ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Topic :";
            // 
            // complainerLbl
            // 
            this.complainerLbl.AutoSize = true;
            this.complainerLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.complainerLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.complainerLbl.Location = new System.Drawing.Point(121, 11);
            this.complainerLbl.Name = "complainerLbl";
            this.complainerLbl.Size = new System.Drawing.Size(52, 21);
            this.complainerLbl.TabIndex = 12;
            this.complainerLbl.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Addresser :";
            // 
            // readBtn
            // 
            this.readBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.readBtn.FlatAppearance.BorderSize = 0;
            this.readBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(103)))));
            this.readBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.readBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.readBtn.Location = new System.Drawing.Point(262, 21);
            this.readBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(102, 35);
            this.readBtn.TabIndex = 10;
            this.readBtn.Text = "Read";
            this.readBtn.UseVisualStyleBackColor = false;
            this.readBtn.Click += new System.EventHandler(this.readBtn_Click);
            // 
            // line1
            // 
            this.line1.LineColor = System.Drawing.Color.Black;
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.line1.MaximumSize = new System.Drawing.Size(2, 1154);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(2, 0);
            this.line1.TabIndex = 0;
            // 
            // ComplaintsListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.advancedPanel1);
            this.Name = "ComplaintsListItem";
            this.Size = new System.Drawing.Size(390, 98);
            this.advancedPanel1.ResumeLayout(false);
            this.advancedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BevelPanel.AdvancedPanel advancedPanel1;
        private System.Windows.Forms.Button readBtn;
        private MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine line1;
        private MediaBazaarSoftware.Dashboard.UserControls.HorizontalLine horizontalLine1;
        private MediaBazaarSoftware.Dashboard.UserControls.VerticalLine verticalLine1;
        private System.Windows.Forms.Label topicLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label complainerLbl;
        private System.Windows.Forms.Label label1;
    }
}
