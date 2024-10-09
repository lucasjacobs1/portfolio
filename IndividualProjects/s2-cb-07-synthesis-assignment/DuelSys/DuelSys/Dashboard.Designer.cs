namespace DuelSys
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.BtnRegisterMatchResults = new System.Windows.Forms.Button();
            this.BtnGenerateTournamentSchedule = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.BtnTournamentManager = new System.Windows.Forms.Button();
            this.PnlView = new System.Windows.Forms.Panel();
            this.PnlTitleBar = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.timerDate = new System.Windows.Forms.Timer(this.components);
            this.PnlMainContent = new System.Windows.Forms.Panel();
            this.PnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.PnlTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMenu
            // 
            this.PnlMenu.BackColor = System.Drawing.Color.Black;
            this.PnlMenu.Controls.Add(this.BtnRegisterMatchResults);
            this.PnlMenu.Controls.Add(this.BtnGenerateTournamentSchedule);
            this.PnlMenu.Controls.Add(this.pictureBox1);
            this.PnlMenu.Controls.Add(this.panel1);
            this.PnlMenu.Controls.Add(this.BtnTournamentManager);
            this.PnlMenu.Controls.Add(this.PnlView);
            this.PnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlMenu.Location = new System.Drawing.Point(0, 0);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Size = new System.Drawing.Size(231, 699);
            this.PnlMenu.TabIndex = 0;
            // 
            // BtnRegisterMatchResults
            // 
            this.BtnRegisterMatchResults.BackColor = System.Drawing.Color.DimGray;
            this.BtnRegisterMatchResults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRegisterMatchResults.FlatAppearance.BorderSize = 0;
            this.BtnRegisterMatchResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegisterMatchResults.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRegisterMatchResults.Location = new System.Drawing.Point(9, 316);
            this.BtnRegisterMatchResults.Name = "BtnRegisterMatchResults";
            this.BtnRegisterMatchResults.Size = new System.Drawing.Size(216, 52);
            this.BtnRegisterMatchResults.TabIndex = 16;
            this.BtnRegisterMatchResults.Text = "Register match results";
            this.BtnRegisterMatchResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegisterMatchResults.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRegisterMatchResults.UseVisualStyleBackColor = false;
            this.BtnRegisterMatchResults.Click += new System.EventHandler(this.BtnRegisterMatchResults_Click);
            // 
            // BtnGenerateTournamentSchedule
            // 
            this.BtnGenerateTournamentSchedule.BackColor = System.Drawing.Color.DimGray;
            this.BtnGenerateTournamentSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnGenerateTournamentSchedule.FlatAppearance.BorderSize = 0;
            this.BtnGenerateTournamentSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateTournamentSchedule.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateTournamentSchedule.Location = new System.Drawing.Point(9, 246);
            this.BtnGenerateTournamentSchedule.Name = "BtnGenerateTournamentSchedule";
            this.BtnGenerateTournamentSchedule.Size = new System.Drawing.Size(216, 53);
            this.BtnGenerateTournamentSchedule.TabIndex = 15;
            this.BtnGenerateTournamentSchedule.Text = "Generate Tournament Schedule";
            this.BtnGenerateTournamentSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateTournamentSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnGenerateTournamentSchedule.UseVisualStyleBackColor = false;
            this.BtnGenerateTournamentSchedule.Click += new System.EventHandler(this.BtnGenerateTournamentSchedule_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblDate);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Controls.Add(this.LblTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 509);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 190);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Welcome:";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDate.Location = new System.Drawing.Point(9, 100);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(63, 15);
            this.LblDate.TabIndex = 13;
            this.LblDate.Text = "00:00:00";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblName.Location = new System.Drawing.Point(113, 16);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(46, 21);
            this.LblName.TabIndex = 14;
            this.LblName.Text = "xxxx";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTime.Location = new System.Drawing.Point(36, 133);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(157, 38);
            this.LblTime.TabIndex = 12;
            this.LblTime.Text = "00:00:00";
            // 
            // BtnTournamentManager
            // 
            this.BtnTournamentManager.BackColor = System.Drawing.Color.DimGray;
            this.BtnTournamentManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnTournamentManager.FlatAppearance.BorderSize = 0;
            this.BtnTournamentManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTournamentManager.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnTournamentManager.Location = new System.Drawing.Point(9, 195);
            this.BtnTournamentManager.Name = "BtnTournamentManager";
            this.BtnTournamentManager.Size = new System.Drawing.Size(216, 35);
            this.BtnTournamentManager.TabIndex = 13;
            this.BtnTournamentManager.Text = "Tournament Manager";
            this.BtnTournamentManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTournamentManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnTournamentManager.UseVisualStyleBackColor = false;
            this.BtnTournamentManager.Click += new System.EventHandler(this.BtnTournamentManager_Click);
            // 
            // PnlView
            // 
            this.PnlView.BackColor = System.Drawing.Color.White;
            this.PnlView.Location = new System.Drawing.Point(3, 194);
            this.PnlView.Name = "PnlView";
            this.PnlView.Size = new System.Drawing.Size(10, 36);
            this.PnlView.TabIndex = 11;
            // 
            // PnlTitleBar
            // 
            this.PnlTitleBar.BackColor = System.Drawing.Color.Black;
            this.PnlTitleBar.Controls.Add(this.LblTitle);
            this.PnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTitleBar.Location = new System.Drawing.Point(231, 0);
            this.PnlTitleBar.Name = "PnlTitleBar";
            this.PnlTitleBar.Size = new System.Drawing.Size(1202, 108);
            this.PnlTitleBar.TabIndex = 1;
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTitle.ForeColor = System.Drawing.Color.Transparent;
            this.LblTitle.Location = new System.Drawing.Point(32, 41);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(129, 23);
            this.LblTitle.TabIndex = 1;
            this.LblTitle.Text = "DuelSys inc.";
            // 
            // timerDate
            // 
            this.timerDate.Enabled = true;
            this.timerDate.Tick += new System.EventHandler(this.timerDate_Tick);
            // 
            // PnlMainContent
            // 
            this.PnlMainContent.BackColor = System.Drawing.Color.Silver;
            this.PnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMainContent.Location = new System.Drawing.Point(231, 108);
            this.PnlMainContent.Name = "PnlMainContent";
            this.PnlMainContent.Size = new System.Drawing.Size(1202, 591);
            this.PnlMainContent.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 699);
            this.Controls.Add(this.PnlMainContent);
            this.Controls.Add(this.PnlTitleBar);
            this.Controls.Add(this.PnlMenu);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load_1);
            this.PnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PnlTitleBar.ResumeLayout(false);
            this.PnlTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlMenu;
        private Panel PnlTitleBar;
        private Panel panel1;
        private Label label1;
        private Label LblDate;
        private Label LblName;
        private Label LblTime;
        private Button BtnTournamentManager;
        private Panel PnlView;
        private System.Windows.Forms.Timer timerDate;
        private Label LblTitle;
        private PictureBox pictureBox1;
        private Panel PnlMainContent;
        private Button BtnGenerateTournamentSchedule;
        private Button BtnRegisterMatchResults;
    }
}