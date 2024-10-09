namespace DuelSys
{
    partial class GenerateTournamentSchedule
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
            this.BtnGenerateSchedule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbxId = new System.Windows.Forms.TextBox();
            this.LbxMatches = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowTournaments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShowTournaments
            // 
            this.dataGridViewShowTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowTournaments.Location = new System.Drawing.Point(36, 88);
            this.dataGridViewShowTournaments.Name = "dataGridViewShowTournaments";
            this.dataGridViewShowTournaments.RowHeadersWidth = 51;
            this.dataGridViewShowTournaments.RowTemplate.Height = 29;
            this.dataGridViewShowTournaments.Size = new System.Drawing.Size(593, 365);
            this.dataGridViewShowTournaments.TabIndex = 24;
            this.dataGridViewShowTournaments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShowTournaments_CellContentClick);
            // 
            // BtnGenerateSchedule
            // 
            this.BtnGenerateSchedule.Location = new System.Drawing.Point(162, 477);
            this.BtnGenerateSchedule.Name = "BtnGenerateSchedule";
            this.BtnGenerateSchedule.Size = new System.Drawing.Size(238, 47);
            this.BtnGenerateSchedule.TabIndex = 25;
            this.BtnGenerateSchedule.Text = "Generate Schedule";
            this.BtnGenerateSchedule.UseVisualStyleBackColor = true;
            this.BtnGenerateSchedule.Click += new System.EventHandler(this.BtnGenerateSchedule_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(741, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 27);
            this.label1.TabIndex = 27;
            this.label1.Text = "Generated Matches";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(36, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(593, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Select a Id of the tournament where you want to generate a schedule for";
            // 
            // TbxId
            // 
            this.TbxId.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxId.Location = new System.Drawing.Point(406, 477);
            this.TbxId.Name = "TbxId";
            this.TbxId.ReadOnly = true;
            this.TbxId.Size = new System.Drawing.Size(78, 47);
            this.TbxId.TabIndex = 29;
            this.TbxId.TextChanged += new System.EventHandler(this.TbxId_TextChanged);
            // 
            // LbxMatches
            // 
            this.LbxMatches.FormattingEnabled = true;
            this.LbxMatches.ItemHeight = 20;
            this.LbxMatches.Location = new System.Drawing.Point(723, 88);
            this.LbxMatches.Name = "LbxMatches";
            this.LbxMatches.Size = new System.Drawing.Size(392, 424);
            this.LbxMatches.TabIndex = 30;
            // 
            // GenerateTournamentSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1186, 547);
            this.Controls.Add(this.LbxMatches);
            this.Controls.Add(this.TbxId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGenerateSchedule);
            this.Controls.Add(this.dataGridViewShowTournaments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerateTournamentSchedule";
            this.Text = "GenerateTournamentSchedule";
            this.Load += new System.EventHandler(this.GenerateTournamentSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowTournaments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewShowTournaments;
        private Button BtnGenerateSchedule;
        private Label label1;
        private Label label2;
        private TextBox TbxId;
        private ListBox LbxMatches;
    }
}