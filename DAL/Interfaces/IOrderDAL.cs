using System.Collections.Generic;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Interfaces
{
    public interface IOrderDAL
    {
        OrderDTO CreateOrder(OrderDTO order);
        List<OrderDTO> GetAllOrders();
        List<OrderDTO> GetUserOrders(int userID);
        OrderDTO GetOrder(int id);
        void UpdateOrder(OrderDTO order);
        void DeleteOrder(OrderDTO order);
    }
}
