namespace MediaBazaar.Dashboard.ProductsSystemForms
{
    partial class CashierForm
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
            this.barCodetext = new System.Windows.Forms.TextBox();
            this.manuallyBarCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.foundProduct = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inStock = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "BarCode :";
            // 
            // barCodetext
            // 
            this.barCodetext.Enabled = false;
            this.barCodetext.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.barCodetext.Location = new System.Drawing.Point(111, 6);
            this.barCodetext.Name = "barCodetext";
            this.barCodetext.Size = new System.Drawing.Size(240, 33);
            this.barCodetext.TabIndex = 1;
            this.barCodetext.TextChanged += new System.EventHandler(this.barCodetext_TextChanged);
            // 
            // manuallyBarCheckbox
            // 
            this.manuallyBarCheckbox.AutoSize = true;
            this.manuallyBarCheckbox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.manuallyBarCheckbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.manuallyBarCheckbox.Location = new System.Drawing.Point(374, 9);
            this.manuallyBarCheckbox.Name = "manuallyBarCheckbox";
            this.manuallyBarCheckbox.Size = new System.Drawing.Size(220, 29);
            this.manuallyBarCheckbox.TabIndex = 2;
            this.manuallyBarCheckbox.Text = "Manually add barcode";
            this.manuallyBarCheckbox.UseVisualStyleBackColor = true;
            this.manuallyBarCheckbox.CheckedChanged += new System.EventHandler(this.manuallyBarCheckbox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(40, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Found Product :";
            // 
            // foundProduct
            // 
            this.foundProduct.AutoSize = true;
            this.foundProduct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.foundProduct.ForeColor = System.Drawing.Color.Red;
            this.foundProduct.Location = new System.Drawing.Point(191, 79);
            this.foundProduct.Name = "foundProduct";
            this.foundProduct.Size = new System.Drawing.Size(22, 25);
            this.foundProduct.TabIndex = 4;
            this.foundProduct.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ammount in stock :";
            // 
            // inStock
            // 
            this.inStock.AutoSize = true;
            this.inStock.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inStock.ForeColor = System.Drawing.Color.Red;
            this.inStock.Location = new System.Drawing.Point(191, 115);
            this.inStock.Name = "inStock";
            this.inStock.Size = new System.Drawing.Size(22, 25);
            this.inStock.TabIndex = 7;
            this.inStock.Text = "0";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown1.Location = new System.Drawing.Point(191, 157);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 33);
            this.numericUpDown1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(26, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ammount to sell :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.Location = new System.Drawing.Point(182, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 58);
            this.button1.TabIndex = 10;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CashierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(869, 519);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.inStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.foundProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.manuallyBarCheckbox);
            this.Controls.Add(this.barCodetext);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "CashierForm";
            this.Text = "CashierForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CashierForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox barCodetext;
        private System.Windows.Forms.CheckBox manuallyBarCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label foundProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label inStock;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}