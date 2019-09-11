using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Model.Core;

namespace OrderSystem.Events
{

    public interface IEvents {

    }
    public static class OrderEvents
    {

        public class OrderPlaced : IEvents {
            public int OrderID { get;  set; }
            public DateTime OrderDate { get;  set; }

            public OrderItems[] lineItems { get;  set; }
        }
    }
}
