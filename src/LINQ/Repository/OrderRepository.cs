namespace LINQ.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LINQ.Models;

    public class OrderRepository
    {
        internal OrderRepository()
        {
            this.Orders = new List<Order>();
        }

        public List<Order> Orders { get; set; }

        public void Add(Order product)
        {
            this.Orders.Add(product);
        }

        public IReadOnlyList<Order> GetAll()
        {
            return (IReadOnlyList<Order>)this.Orders;
        }
    }
}
