using System;

namespace TradingCompany.DTO
{
    public class ProductDTO : IComparable
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ProductDTO other = obj as ProductDTO;
            if (other != null)
                return this.ProductName.CompareTo(other.ProductName);
            else
                throw new ArgumentException("Object is not a Product");
        }

        public override string ToString()
        {
            return $"{ProductName} {Price}$";
        }
    }
}
