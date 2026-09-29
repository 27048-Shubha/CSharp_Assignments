namespace LINQ.Service
{
    using System;
    using System.Collections.Generic;
    using LINQ.Models;
    using LINQ.Repository;

    /// <summary>
    /// Provides business operations for managing orders.
    /// </summary>
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">The repository used for order data persistence.</param>
        internal OrderService(OrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        /// <summary>
        /// Creates and stores a new order.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order.</param>
        /// <param name="orderDate">The date of the order.</param>
        /// <param name="orderStatus">The current status of the order.</param>
        public void Add(int orderId, string orderDate, Enums.OrderStatus orderStatus)
        {
            Order order = new Order()
            {
                Id = orderId,
                OrderDate = DateTime.Parse(orderDate),
                Status = orderStatus,
            };

            this._orderRepository.Add(order);
        }

        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>A read-only collection of orders.</returns>
        public IReadOnlyList<Order> GetAll()
        {
            return this._orderRepository.GetAll();
        }

        /// <summary>
        /// Removes all order data from storage.
        /// </summary>
        public void ClearFile() => this._orderRepository.ClearFile();
    }
}
