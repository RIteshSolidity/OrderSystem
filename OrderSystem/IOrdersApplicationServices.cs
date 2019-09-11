using OrderSystem.Commands;
using OrderSystem.EventPublisher;
using OrderSystem.Events;
using OrderSystem.Model.Core;
using OrderSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem
{
    public interface IOrdersApplicationServices
    {
        void handle(ICommand obj);
    }

    public class OrdersApplicationServices : IOrdersApplicationServices
    {
        private IOrdersRepository _repo;
        private IServiceBusEventPublisher _publisher;
        public OrdersApplicationServices(IOrdersRepository repo , IServiceBusEventPublisher publisher)
        {
            _repo = repo;
            _publisher = publisher;
        }
        public void handle(ICommand obj)
        {
            switch (obj) {
                case CreateOrder co: {
                        var order = new Orders(((CreateOrder)obj).OrderID,
                            new OrderDateType(((CreateOrder)obj).OrderDate),
                            ((CreateOrder)obj).lineItems
                            );

                        _repo.AddOrder(order);

                        IEnumerable<IEvents> allevents = order.GetEvents();
                        foreach (var e in allevents) {
                            switch (e)
                            {
                                case OrderEvents.OrderPlaced op: {
                                        _publisher.PublishEvent(e);
                                        break;
                                    }

                            }
                        }
                        break;

                    }
            }

            
        }
    }
}
