using System;
using System.Collections.Generic;
using TradingCompany.BL.Interfaces;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.BL.Concrete
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDAL _orderDAL;
        public OrderManager(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public bool CreateOrder(OrderDTO orderDTO)
        {
            var res = _orderDAL.CreateOrder(orderDTO);
            return res.OrderID != 0;
        }

        public List<OrderDTO> GetUserOrders(int currUserID)
        {
            return _orderDAL.GetUserOrders(currUserID);
        }
    }
}
