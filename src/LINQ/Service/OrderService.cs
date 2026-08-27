namespace LINQ.Service
{
    using LINQ.Models;
    using LINQ.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        internal OrderService(OrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public void Add(int orderId, string orderDate, Enums.OrderStatus orderStatus)
        {
            Order order = new Order()
            {
                Id = orderId,
                OrderDate = DateTime.Parse(orderDate),
                Status = orderStatus,
            };

            _orderRepository.Add(order);
        }

        public IReadOnlyList<Order> GetAll()
        {
            return this._orderRepository.GetAll();
        }
    }
}
