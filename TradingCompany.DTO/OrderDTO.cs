using System;

namespace TradingCompany.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public UserDTO User { get; set; }
        public int UserID { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderCreationDate { get; set; }
        public DateTime RowUpdateTime { get; set; }
    }
}
