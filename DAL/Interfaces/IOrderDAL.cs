using System.Collections.Generic;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Interfaces
{
    public interface IOrderDAL
    {
        OrderDTO CreateOrder(OrderDTO order);
        List<OrderDTO> GetAllOrders();
        OrderDTO GetOrder(int id);
        void UpdateOrder(OrderDTO order);
        void DeleteOrder(OrderDTO order);
    }
}
