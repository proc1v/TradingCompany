using System.Collections.Generic;
using TradingCompany.DTO;

namespace TradingCompany.BL.Interfaces
{
    public interface IOrderManager
    {
        List<OrderDTO> GetUserOrders(int currUserID);
        bool CreateOrder(OrderDTO orderDTO);
    }
}
