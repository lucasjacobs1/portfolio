namespace MediaBazaar.Dashboard.ProductsSystemForms
{
    partial class HandledRequestsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbAcceptedRequests = new System.Windows.Forms.ListBox();
            this.lbRejectedRequests = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accepted Requests:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rejected Requests:";
            // 
            // lbAcceptedRequests
            // 
            this.lbAcceptedRequests.FormattingEnabled = true;
            this.lbAcceptedRequests.ItemHeight = 20;
            this.lbAcceptedRequests.Location = new System.Drawing.Point(12, 40);
            this.lbAcceptedRequests.Name = "lbAcceptedRequests";
            this.lbAcceptedRequests.Size = new System.Drawing.Size(267, 324);
            this.lbAcceptedRequests.TabIndex = 2;
            this.lbAcceptedRequests.SelectedIndexChanged += new System.EventHandler(this.lbAcceptedRequests_SelectedIndexChanged);
            // 
            // lbRejectedRequests
            // 
            this.lbRejectedRequests.FormattingEnabled = true;
            this.lbRejectedRequests.ItemHeight = 20;
            this.lbRejectedRequests.Location = new System.Drawing.Point(285, 40);
            this.lbRejectedRequests.Name = "lbRejectedRequests";
            this.lbRejectedRequests.Size = new System.Drawing.Size(267, 324);
            this.lbRejectedRequests.TabIndex = 3;
            this.lbRejectedRequests.SelectedIndexChanged += new System.EventHandler(this.lbRejectedRequests_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message added by sender:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 397);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(169, 20);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "No request selected yet!";
            // 
            // HandledRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 450);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbRejectedRequests);
            this.Controls.Add(this.lbAcceptedRequests);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HandledRequestsForm";
            this.Text = "HandledRequestsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbAcceptedRequests;
        private System.Windows.Forms.ListBox lbRejectedRequests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessage;
    }
}