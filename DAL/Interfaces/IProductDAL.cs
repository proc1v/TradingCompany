using System.Collections.Generic;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Interfaces
{
    public interface IProductDAL
    {
        ProductDTO CreateProduct(ProductDTO productDTO);
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProduct(int id);
        void DeleteProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
    }
}
