using System;
using System.Windows.Forms;
using TradingCompany.BL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.WF
{
    public partial class ReviewForm : Form
    {
        private readonly IReviewManager _reviewManager;
        //private readonly ProductDTO _product;
        private bool firstClickOnReviewTextBox = true;
        public ReviewForm(IReviewManager reviewManager)
        {
            InitializeComponent();

            _reviewManager = reviewManager;
            // _product = product;

            lProductName.Text = lProductName.Text+ " " + Program.CurrenOrder.Product.ProductName;
            lProductPrice.Text = lProductPrice.Text + " " + Program.CurrenOrder.Product.Price + "$";
        }

        private void rtbReview_Click(object sender, EventArgs e)
        {
            if (firstClickOnReviewTextBox)
            {
                rtbReview.Text = "";
            }
        }

        private void bSubmitReview_Click(object sender, EventArgs e)
        {
            ReviewDTO review = new ReviewDTO
            {
                Rating = nudReviewRating.Value,
                Text = (string.IsNullOrWhiteSpace(rtbReview.Text) || rtbReview.Text.Equals("Write review... (optional)")) ? "" : rtbReview.Text,
                ProductID = Program.CurrenOrder.Product.ProductID,
                UserID = Program.CurrentUserID
            };

            if (_reviewManager.CreateReview(review))
            {
                MessageBox.Show("New review created!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error occured", "Failed", MessageBoxButtons.OK);
            }
            this.Close();
        }
    }
}
