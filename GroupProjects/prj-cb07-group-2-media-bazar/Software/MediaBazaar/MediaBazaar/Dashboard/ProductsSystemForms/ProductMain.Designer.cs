namespace MediaBazaar.Dashboard.ProductsSystemForms
{
    partial class ProductMain
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
            this.tbSearchProduct = new System.Windows.Forms.TextBox();
            this.lbProductSearchResult = new System.Windows.Forms.ListBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbAmountInStock = new System.Windows.Forms.TextBox();
            this.tbAmountSold = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRestockRequests = new System.Windows.Forms.ListBox();
            this.btnApproveRequest = new System.Windows.Forms.Button();
            this.btnRejectRequest = new System.Windows.Forms.Button();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbLength = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.btnViewHandledRequests = new System.Windows.Forms.Button();
            this.btnMoreDetailedView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSearchProduct
            // 
            this.tbSearchProduct.Location = new System.Drawing.Point(237, 12);
            this.tbSearchProduct.Name = "tbSearchProduct";
            this.tbSearchProduct.PlaceholderText = "Search";
            this.tbSearchProduct.Size = new System.Drawing.Size(265, 27);
            this.tbSearchProduct.TabIndex = 0;
            this.tbSearchProduct.TextChanged += new System.EventHandler(this.tbSearchProduct_TextChanged);
            // 
            // lbProductSearchResult
            // 
            this.lbProductSearchResult.FormattingEnabled = true;
            this.lbProductSearchResult.ItemHeight = 20;
            this.lbProductSearchResult.Location = new System.Drawing.Point(237, 45);
            this.lbProductSearchResult.Name = "lbProductSearchResult";
            this.lbProductSearchResult.Size = new System.Drawing.Size(265, 344);
            this.lbProductSearchResult.TabIndex = 1;
            this.lbProductSearchResult.SelectedIndexChanged += new System.EventHandler(this.lbProductSearchResult_SelectedIndexChanged);
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(11, 45);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.PlaceholderText = "Product Name";
            this.tbProductName.Size = new System.Drawing.Size(207, 27);
            this.tbProductName.TabIndex = 2;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(11, 77);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.PlaceholderText = "Description";
            this.tbDescription.Size = new System.Drawing.Size(207, 27);
            this.tbDescription.TabIndex = 3;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(11, 111);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.PlaceholderText = "Price";
            this.tbPrice.Size = new System.Drawing.Size(207, 27);
            this.tbPrice.TabIndex = 4;
            // 
            // tbAmountInStock
            // 
            this.tbAmountInStock.Location = new System.Drawing.Point(11, 144);
            this.tbAmountInStock.Name = "tbAmountInStock";
            this.tbAmountInStock.PlaceholderText = "Amount in stock";
            this.tbAmountInStock.Size = new System.Drawing.Size(207, 27);
            this.tbAmountInStock.TabIndex = 5;
            // 
            // tbAmountSold
            // 
            this.tbAmountSold.Location = new System.Drawing.Point(11, 177);
            this.tbAmountSold.Name = "tbAmountSold";
            this.tbAmountSold.PlaceholderText = "Amount sold";
            this.tbAmountSold.Size = new System.Drawing.Size(207, 27);
            this.tbAmountSold.TabIndex = 6;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(12, 342);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(162, 29);
            this.btnAddProduct.TabIndex = 7;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(12, 375);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(162, 29);
            this.btnRemoveProduct.TabIndex = 8;
            this.btnRemoveProduct.Text = "Remove Product";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(11, 410);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(162, 29);
            this.btnEditProduct.TabIndex = 9;
            this.btnEditProduct.Text = "Edit Product";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(508, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Re-stocking requests:";
            // 
            // lbRestockRequests
            // 
            this.lbRestockRequests.FormattingEnabled = true;
            this.lbRestockRequests.ItemHeight = 20;
            this.lbRestockRequests.Location = new System.Drawing.Point(508, 130);
            this.lbRestockRequests.Name = "lbRestockRequests";
            this.lbRestockRequests.Size = new System.Drawing.Size(255, 124);
            this.lbRestockRequests.TabIndex = 11;
            // 
            // btnApproveRequest
            // 
            this.btnApproveRequest.Location = new System.Drawing.Point(509, 265);
            this.btnApproveRequest.Name = "btnApproveRequest";
            this.btnApproveRequest.Size = new System.Drawing.Size(123, 60);
            this.btnApproveRequest.TabIndex = 12;
            this.btnApproveRequest.Text = "Approve request";
            this.btnApproveRequest.UseVisualStyleBackColor = true;
            this.btnApproveRequest.Click += new System.EventHandler(this.btnApproveRequest_Click);
            // 
            // btnRejectRequest
            // 
            this.btnRejectRequest.Location = new System.Drawing.Point(639, 265);
            this.btnRejectRequest.Name = "btnRejectRequest";
            this.btnRejectRequest.Size = new System.Drawing.Size(126, 60);
            this.btnRejectRequest.TabIndex = 13;
            this.btnRejectRequest.Text = "Reject request";
            this.btnRejectRequest.UseVisualStyleBackColor = true;
            this.btnRejectRequest.Click += new System.EventHandler(this.btnRejectRequest_Click);
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(12, 210);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.PlaceholderText = "Weight";
            this.tbWeight.Size = new System.Drawing.Size(206, 27);
            this.tbWeight.TabIndex = 14;
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(12, 243);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.PlaceholderText = "Height";
            this.tbHeight.Size = new System.Drawing.Size(206, 27);
            this.tbHeight.TabIndex = 15;
            // 
            // tbLength
            // 
            this.tbLength.Location = new System.Drawing.Point(12, 276);
            this.tbLength.Name = "tbLength";
            this.tbLength.PlaceholderText = "Length";
            this.tbLength.Size = new System.Drawing.Size(206, 27);
            this.tbLength.TabIndex = 16;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(11, 309);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.PlaceholderText = "Width";
            this.tbWidth.Size = new System.Drawing.Size(206, 27);
            this.tbWidth.TabIndex = 17;
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(509, 331);
            this.tbReason.Name = "tbReason";
            this.tbReason.PlaceholderText = "Reason for reject";
            this.tbReason.Size = new System.Drawing.Size(254, 27);
            this.tbReason.TabIndex = 18;
            // 
            // btnViewHandledRequests
            // 
            this.btnViewHandledRequests.Location = new System.Drawing.Point(509, 364);
            this.btnViewHandledRequests.Name = "btnViewHandledRequests";
            this.btnViewHandledRequests.Size = new System.Drawing.Size(256, 62);
            this.btnViewHandledRequests.TabIndex = 19;
            this.btnViewHandledRequests.Text = "View Handled Requests";
            this.btnViewHandledRequests.UseVisualStyleBackColor = true;
            this.btnViewHandledRequests.Click += new System.EventHandler(this.btnViewHandledRequests_Click);
            // 
            // btnMoreDetailedView
            // 
            this.btnMoreDetailedView.Location = new System.Drawing.Point(237, 397);
            this.btnMoreDetailedView.Name = "btnMoreDetailedView";
            this.btnMoreDetailedView.Size = new System.Drawing.Size(266, 29);
            this.btnMoreDetailedView.TabIndex = 20;
            this.btnMoreDetailedView.Text = "More Detailed View";
            this.btnMoreDetailedView.UseVisualStyleBackColor = true;
            this.btnMoreDetailedView.Click += new System.EventHandler(this.btnMoreDetailedView_Click);
            // 
            // ProductMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.btnMoreDetailedView);
            this.Controls.Add(this.btnViewHandledRequests);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.tbLength);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbWeight);
            this.Controls.Add(this.btnRejectRequest);
            this.Controls.Add(this.btnApproveRequest);
            this.Controls.Add(this.lbRestockRequests);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditProduct);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.tbAmountSold);
            this.Controls.Add(this.tbAmountInStock);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.lbProductSearchResult);
            this.Controls.Add(this.tbSearchProduct);
            this.Name = "ProductMain";
            this.Text = "ProductMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.TextBox tbSearchProduct;
        private System.Windows.Forms.ListBox lbProductSearchResult;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbAmountInStock;
        private System.Windows.Forms.TextBox tbAmountSold;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbRestockRequests;
        private System.Windows.Forms.Button btnApproveRequest;
        private System.Windows.Forms.Button btnRejectRequest;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbLength;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Button btnViewHandledRequests;
        private System.Windows.Forms.Button btnMoreDetailedView;
    }
}