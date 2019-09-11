using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Model.Core;


namespace OrderSystem.Repository
{
    public class OrderRepository : IOrdersRepository
    {
        private OrdersDBContext _context;
        public OrderRepository(OrdersDBContext context)
        {
            _context = context;
        }
        public async Task AddOrder(Orders o)
        {
            try
            {
                _context.Add(o);
                 _context.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex) {
            }
        }

        public IEnumerable< Orders> GetOrders()
        {
            var ordersCollection = _context.Orders.ToList();
            return ordersCollection;
        }
    }
}
