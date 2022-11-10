using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Concrete
{
    public class OrderDAL : IOrderDAL
    {
        private readonly IMapper _mapper;

        public OrderDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderDTO CreateOrder(OrderDTO order)
        {
            order.OrderID = 0;
            order.Product = null;
            order.User = null;
            using (var entities = new CourseProject2022Entities())
            {
                var orderInDB = _mapper.Map<Order>(order);
                orderInDB.OrderCreationDate = DateTime.UtcNow;
                orderInDB.RowUpdateTime = DateTime.UtcNow;
                entities.Orders.Add(orderInDB);
                entities.SaveChanges();
                return _mapper.Map<OrderDTO>(orderInDB);
            }
        }

        public void DeleteOrder(OrderDTO order)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Orders.SingleOrDefault(o => o.OrderID == order.OrderID);
                entities.Orders.Remove(found);
                entities.SaveChanges();
            }
        }

        public List<OrderDTO> GetAllOrders()
        {
            using (var entities = new CourseProject2022Entities())
            {
                var orders = entities.Orders.ToList();
                return _mapper.Map<List<OrderDTO>>(orders);
            }
        }

        public List<OrderDTO> GetUserOrders(int userID)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var orders = entities.Orders.Where(u => u.UserID == userID).ToList();
                return _mapper.Map<List<OrderDTO>>(orders);
            }
        }

        public OrderDTO GetOrder(int id)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Orders.SingleOrDefault(o => o.OrderID == id);
                return _mapper.Map<OrderDTO>(found);
            }
        }

        public void UpdateOrder(OrderDTO order)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Orders.SingleOrDefault(o => o.OrderID == order.OrderID);
                if (found != null)
                {
                    found.UserID = order.UserID;
                    found.ProductID = order.ProductID;
                    found.Quantity = (byte)order.Quantity;
                    found.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
