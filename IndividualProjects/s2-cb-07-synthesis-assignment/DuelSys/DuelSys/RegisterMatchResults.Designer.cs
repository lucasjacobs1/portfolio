namespace DuelSys
{
    partial class RegisterMatchResults
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
            this.dataGridViewShowTournaments = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LbxMatches = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbxScoreAway = new System.Windows.Forms.TextBox();
            this.TbxScoreHome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnRegisterMatchResult = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowTournaments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShowTournaments
            // 
            this.dataGridViewShowTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowTournaments.Location = new System.Drawing.Point(34, 73);
            this.dataGridViewShowTournaments.Name = "dataGridViewShowTournaments";
            this.dataGridViewShowTournaments.RowHeadersWidth = 51;
            this.dataGridViewShowTournaments.RowTemplate.Height = 29;
            this.dataGridViewShowTournaments.Size = new System.Drawing.Size(521, 344);
            this.dataGridViewShowTournaments.TabIndex = 24;
            this.dataGridViewShowTournaments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShowTournaments_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(34, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "All ongoing tournaments";
            // 
            // LbxMatches
            // 
            this.LbxMatches.FormattingEnabled = true;
            this.LbxMatches.ItemHeight = 20;
            this.LbxMatches.Location = new System.Drawing.Point(625, 73);
            this.LbxMatches.Name = "LbxMatches";
            this.LbxMatches.Size = new System.Drawing.Size(544, 344);
            this.LbxMatches.TabIndex = 26;
            this.LbxMatches.SelectedIndexChanged += new System.EventHandler(this.LbxMatches_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(625, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(467, 28);
            this.label2.TabIndex = 27;
            this.label2.Text = "All unregistered matches of the selected tournament";
            // 
            // TbxScoreAway
            // 
            this.TbxScoreAway.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxScoreAway.Location = new System.Drawing.Point(561, 535);
            this.TbxScoreAway.Name = "TbxScoreAway";
            this.TbxScoreAway.Size = new System.Drawing.Size(186, 31);
            this.TbxScoreAway.TabIndex = 28;
            // 
            // TbxScoreHome
            // 
            this.TbxScoreHome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxScoreHome.Location = new System.Drawing.Point(301, 535);
            this.TbxScoreHome.Name = "TbxScoreHome";
            this.TbxScoreHome.Size = new System.Drawing.Size(190, 31);
            this.TbxScoreHome.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(168, 509);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Result:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(301, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Score Team Home";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(561, 509);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "Score Team Away";
            // 
            // BtnRegisterMatchResult
            // 
            this.BtnRegisterMatchResult.Location = new System.Drawing.Point(794, 509);
            this.BtnRegisterMatchResult.Name = "BtnRegisterMatchResult";
            this.BtnRegisterMatchResult.Size = new System.Drawing.Size(233, 57);
            this.BtnRegisterMatchResult.TabIndex = 33;
            this.BtnRegisterMatchResult.Text = "Register Match Result";
            this.BtnRegisterMatchResult.UseVisualStyleBackColor = true;
            this.BtnRegisterMatchResult.Click += new System.EventHandler(this.BtnRegisterMatchResult_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(625, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Select a match to register results.";
            // 
            // RegisterMatchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1202, 591);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnRegisterMatchResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TbxScoreHome);
            this.Controls.Add(this.TbxScoreAway);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LbxMatches);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewShowTournaments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterMatchResults";
            this.Text = "RegisterMatchResults";
            this.Load += new System.EventHandler(this.RegisterMatchResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowTournaments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewShowTournaments;
        private Label label1;
        private ListBox LbxMatches;
        private Label label2;
        private TextBox TbxScoreAway;
        private TextBox TbxScoreHome;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button BtnRegisterMatchResult;
        private Label label6;
    }
}