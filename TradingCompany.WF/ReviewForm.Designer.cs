namespace TradingCompany.WF
{
    partial class ReviewForm
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
            this.lProductName = new System.Windows.Forms.Label();
            this.lProductPrice = new System.Windows.Forms.Label();
            this.lEnterRating = new System.Windows.Forms.Label();
            this.nudReviewRating = new System.Windows.Forms.NumericUpDown();
            this.rtbReview = new System.Windows.Forms.RichTextBox();
            this.bCancelReview = new System.Windows.Forms.Button();
            this.bSubmitReview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudReviewRating)).BeginInit();
            this.SuspendLayout();
            // 
            // lProductName
            // 
            this.lProductName.AutoSize = true;
            this.lProductName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductName.Location = new System.Drawing.Point(12, 9);
            this.lProductName.Name = "lProductName";
            this.lProductName.Size = new System.Drawing.Size(149, 28);
            this.lProductName.TabIndex = 0;
            this.lProductName.Text = "Product name:";
            // 
            // lProductPrice
            // 
            this.lProductPrice.AutoSize = true;
            this.lProductPrice.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductPrice.Location = new System.Drawing.Point(12, 50);
            this.lProductPrice.Name = "lProductPrice";
            this.lProductPrice.Size = new System.Drawing.Size(143, 28);
            this.lProductPrice.TabIndex = 1;
            this.lProductPrice.Text = "Product price:";
            // 
            // lEnterRating
            // 
            this.lEnterRating.AutoSize = true;
            this.lEnterRating.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEnterRating.Location = new System.Drawing.Point(12, 89);
            this.lEnterRating.Name = "lEnterRating";
            this.lEnterRating.Size = new System.Drawing.Size(128, 28);
            this.lEnterRating.TabIndex = 2;
            this.lEnterRating.Text = "Enter rating:";
            // 
            // nudReviewRating
            // 
            this.nudReviewRating.DecimalPlaces = 1;
            this.nudReviewRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudReviewRating.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudReviewRating.Location = new System.Drawing.Point(146, 89);
            this.nudReviewRating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudReviewRating.Name = "nudReviewRating";
            this.nudReviewRating.Size = new System.Drawing.Size(120, 30);
            this.nudReviewRating.TabIndex = 3;
            // 
            // rtbReview
            // 
            this.rtbReview.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbReview.Location = new System.Drawing.Point(17, 120);
            this.rtbReview.Name = "rtbReview";
            this.rtbReview.Size = new System.Drawing.Size(249, 193);
            this.rtbReview.TabIndex = 4;
            this.rtbReview.Text = "Write review... (optional)";
            this.rtbReview.Click += new System.EventHandler(this.rtbReview_Click);
            // 
            // bCancelReview
            // 
            this.bCancelReview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelReview.Location = new System.Drawing.Point(17, 319);
            this.bCancelReview.Name = "bCancelReview";
            this.bCancelReview.Size = new System.Drawing.Size(123, 29);
            this.bCancelReview.TabIndex = 5;
            this.bCancelReview.Text = "Cancel";
            this.bCancelReview.UseVisualStyleBackColor = true;
            // 
            // bSubmitReview
            // 
            this.bSubmitReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSubmitReview.Location = new System.Drawing.Point(143, 319);
            this.bSubmitReview.Name = "bSubmitReview";
            this.bSubmitReview.Size = new System.Drawing.Size(123, 29);
            this.bSubmitReview.TabIndex = 6;
            this.bSubmitReview.Text = "Submit";
            this.bSubmitReview.UseVisualStyleBackColor = true;
            this.bSubmitReview.Click += new System.EventHandler(this.bSubmitReview_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelReview;
            this.ClientSize = new System.Drawing.Size(282, 356);
            this.Controls.Add(this.bSubmitReview);
            this.Controls.Add(this.bCancelReview);
            this.Controls.Add(this.rtbReview);
            this.Controls.Add(this.nudReviewRating);
            this.Controls.Add(this.lEnterRating);
            this.Controls.Add(this.lProductPrice);
            this.Controls.Add(this.lProductName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReviewForm";
            this.Text = "New Review";
            ((System.ComponentModel.ISupportInitialize)(this.nudReviewRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.Label lProductPrice;
        private System.Windows.Forms.Label lEnterRating;
        private System.Windows.Forms.NumericUpDown nudReviewRating;
        private System.Windows.Forms.RichTextBox rtbReview;
        private System.Windows.Forms.Button bCancelReview;
        private System.Windows.Forms.Button bSubmitReview;
    }
}