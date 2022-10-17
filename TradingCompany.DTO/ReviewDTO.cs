using System;

namespace TradingCompany.DTO
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public decimal Rating { get; set; }
        public string Text { get; set; }
        public DateTime ReviewCreationDate { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public ProductDTO Product { get; set; }
        public UserDTO User { get; set; }
    }
}
