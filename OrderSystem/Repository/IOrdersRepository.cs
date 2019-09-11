using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Model.Core;

namespace OrderSystem.Repository
{
    public interface IOrdersRepository
    {
        Task AddOrder(Orders o);

        IEnumerable<Orders> GetOrders();
    }
}
