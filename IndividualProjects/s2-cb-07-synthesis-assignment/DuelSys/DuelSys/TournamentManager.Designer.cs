namespace DuelSys
{
    partial class TournamentManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentManager));
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.TbxLocation = new System.Windows.Forms.TextBox();
            this.CbxSport = new System.Windows.Forms.ComboBox();
            this.CbxTournamentType = new System.Windows.Forms.ComboBox();
            this.RtxDescription = new System.Windows.Forms.RichTextBox();
            this.TbxMinimumPlayers = new System.Windows.Forms.TextBox();
            this.TbxMaximumPlayers = new System.Windows.Forms.TextBox();
            this.BtnAddTournament = new System.Windows.Forms.Button();
            this.BtnUpdateTournament = new System.Windows.Forms.Button();
            this.BtnDeleteTournament = new System.Windows.Forms.Button();
            this.TbxSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewShowTournaments = new System.Windows.Forms.DataGridView();
            this.TbxId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowTournaments)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(60, 45);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerStartDate.TabIndex = 0;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(370, 45);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerEndDate.TabIndex = 1;
            // 
            // TbxLocation
            // 
            this.TbxLocation.Location = new System.Drawing.Point(60, 185);
            this.TbxLocation.Name = "TbxLocation";
            this.TbxLocation.Size = new System.Drawing.Size(250, 27);
            this.TbxLocation.TabIndex = 2;
            // 
            // CbxSport
            // 
            this.CbxSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxSport.FormattingEnabled = true;
            this.CbxSport.Location = new System.Drawing.Point(60, 257);
            this.CbxSport.Name = "CbxSport";
            this.CbxSport.Size = new System.Drawing.Size(250, 28);
            this.CbxSport.TabIndex = 4;
            // 
            // CbxTournamentType
            // 
            this.CbxTournamentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxTournamentType.FormattingEnabled = true;
            this.CbxTournamentType.Location = new System.Drawing.Point(380, 257);
            this.CbxTournamentType.Name = "CbxTournamentType";
            this.CbxTournamentType.Size = new System.Drawing.Size(250, 28);
            this.CbxTournamentType.TabIndex = 5;
            // 
            // RtxDescription
            // 
            this.RtxDescription.Location = new System.Drawing.Point(60, 327);
            this.RtxDescription.Name = "RtxDescription";
            this.RtxDescription.Size = new System.Drawing.Size(570, 77);
            this.RtxDescription.TabIndex = 6;
            this.RtxDescription.Text = "";
            // 
            // TbxMinimumPlayers
            // 
            this.TbxMinimumPlayers.Location = new System.Drawing.Point(60, 120);
            this.TbxMinimumPlayers.Name = "TbxMinimumPlayers";
            this.TbxMinimumPlayers.Size = new System.Drawing.Size(250, 27);
            this.TbxMinimumPlayers.TabIndex = 7;
            // 
            // TbxMaximumPlayers
            // 
            this.TbxMaximumPlayers.Location = new System.Drawing.Point(370, 120);
            this.TbxMaximumPlayers.Name = "TbxMaximumPlayers";
            this.TbxMaximumPlayers.Size = new System.Drawing.Size(250, 27);
            this.TbxMaximumPlayers.TabIndex = 8;
            // 
            // BtnAddTournament
            // 
            this.BtnAddTournament.Location = new System.Drawing.Point(172, 466);
            this.BtnAddTournament.Name = "BtnAddTournament";
            this.BtnAddTournament.Size = new System.Drawing.Size(221, 69);
            this.BtnAddTournament.TabIndex = 10;
            this.BtnAddTournament.Text = "Add Tournament";
            this.BtnAddTournament.UseVisualStyleBackColor = true;
            this.BtnAddTournament.Click += new System.EventHandler(this.BtnAddTournament_Click);
            // 
            // BtnUpdateTournament
            // 
            this.BtnUpdateTournament.Location = new System.Drawing.Point(473, 466);
            this.BtnUpdateTournament.Name = "BtnUpdateTournament";
            this.BtnUpdateTournament.Size = new System.Drawing.Size(221, 69);
            this.BtnUpdateTournament.TabIndex = 11;
            this.BtnUpdateTournament.Text = "Update Tournament";
            this.BtnUpdateTournament.UseVisualStyleBackColor = true;
            this.BtnUpdateTournament.Click += new System.EventHandler(this.BtnUpdateTournament_Click);
            // 
            // BtnDeleteTournament
            // 
            this.BtnDeleteTournament.Location = new System.Drawing.Point(783, 466);
            this.BtnDeleteTournament.Name = "BtnDeleteTournament";
            this.BtnDeleteTournament.Size = new System.Drawing.Size(221, 69);
            this.BtnDeleteTournament.TabIndex = 12;
            this.BtnDeleteTournament.Text = "Delete Tournament";
            this.BtnDeleteTournament.UseVisualStyleBackColor = true;
            this.BtnDeleteTournament.Click += new System.EventHandler(this.BtnDeleteTournament_Click);
            // 
            // TbxSearch
            // 
            this.TbxSearch.Location = new System.Drawing.Point(682, 33);
            this.TbxSearch.Name = "TbxSearch";
            this.TbxSearch.Size = new System.Drawing.Size(492, 27);
            this.TbxSearch.TabIndex = 13;
            this.TbxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(653, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 27);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(60, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(370, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(60, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Minimum Players";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(370, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "Maximum Players";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(60, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 19;
            this.label5.Text = "Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(60, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 20;
            this.label6.Text = "Sport";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(380, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tournament Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(60, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "Description";
            // 
            // dataGridViewShowTournaments
            // 
            this.dataGridViewShowTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowTournaments.Location = new System.Drawing.Point(653, 66);
            this.dataGridViewShowTournaments.Name = "dataGridViewShowTournaments";
            this.dataGridViewShowTournaments.RowHeadersWidth = 51;
            this.dataGridViewShowTournaments.RowTemplate.Height = 29;
            this.dataGridViewShowTournaments.Size = new System.Drawing.Size(521, 338);
            this.dataGridViewShowTournaments.TabIndex = 23;
            this.dataGridViewShowTournaments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShowTournaments_CellContentClick);
            // 
            // TbxId
            // 
            this.TbxId.Location = new System.Drawing.Point(769, 414);
            this.TbxId.Name = "TbxId";
            this.TbxId.ReadOnly = true;
            this.TbxId.Size = new System.Drawing.Size(125, 27);
            this.TbxId.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(653, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Selected Id";
            // 
            // TournamentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1186, 547);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TbxId);
            this.Controls.Add(this.dataGridViewShowTournaments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TbxSearch);
            this.Controls.Add(this.BtnDeleteTournament);
            this.Controls.Add(this.BtnUpdateTournament);
            this.Controls.Add(this.BtnAddTournament);
            this.Controls.Add(this.TbxMaximumPlayers);
            this.Controls.Add(this.TbxMinimumPlayers);
            this.Controls.Add(this.RtxDescription);
            this.Controls.Add(this.CbxTournamentType);
            this.Controls.Add(this.CbxSport);
            this.Controls.Add(this.TbxLocation);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TournamentManager";
            this.Text = "TournamentManager";
            this.Load += new System.EventHandler(this.TournamentManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowTournaments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private TextBox TbxLocation;
        private ComboBox CbxSport;
        private ComboBox CbxTournamentType;
        private RichTextBox RtxDescription;
        private TextBox TbxMinimumPlayers;
        private TextBox TbxMaximumPlayers;
        private Button BtnAddTournament;
        private Button BtnUpdateTournament;
        private Button BtnDeleteTournament;
        private TextBox TbxSearch;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DataGridView dataGridViewShowTournaments;
        private TextBox TbxId;
        private Label label9;
    }
}