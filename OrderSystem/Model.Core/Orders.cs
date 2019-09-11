using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Events;

namespace OrderSystem.Model.Core
{
    public class Orders: Entity
    {
        public Orders(int _orderid, OrderDateType _dt, OrderItems[] oi)
        {
            //List<OrderItems> li = new List<OrderItems>(oi);
            Apply(new OrderEvents.OrderPlaced
            {
                lineItems = oi,
                OrderDate = _dt,
                OrderID = _orderid
            }); ;

        }

        private Orders()
        {

        }
        public int OrderID { get;  set; }
        public OrderDateType OrderDate { get;  set; }

        public List<OrderItems> lineItems { get;  set; }

        public OrderStatus status { get; private set; }



        public void UpdateOrderDate() {

        }

        public void UpdateOrder() {

        }

        public void DeleteOrder() {

        }

        public override void Validate()
        {   
                if (status == OrderStatus.OrderPlaced)
                {

                }
        }



        public override void When(IEvents @event)
        {
            switch (@event) {
                case OrderEvents.OrderPlaced e:
                    {
                        this.OrderID = e.OrderID;
                        this.OrderDate = new OrderDateType(e.OrderDate);
                        this.lineItems = e.lineItems.ToList();
                        break;
                    }
                   
                    
            }
        }
    }

    public enum OrderStatus {
        OrderPlaced,
        OrderCancelled,
        OrderRejected,
        OrderSucceed,
        OrderFailed
    }

    public class OrderDateType : IEquatable<OrderDateType> {
        public DateTime OrderDate { get; private set; }
        public OrderDateType(DateTime dt)
        {
            OrderDate = dt;
            Validate();

        }

        private  OrderDateType()
        {

        }

        private void Validate()
        {
            if (OrderDate > DateTime.Now.AddMonths(1))
                throw new InvalidOperationException("order date cannot be more than one month in future");
        }

        public bool Equals(OrderDateType other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return (other.OrderDate == this.OrderDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (!ReferenceEquals(this, obj))
                return false;
            return Equals((OrderDateType)obj);
        }

        public static bool operator ==(OrderDateType right, OrderDateType left) {
            return (right.OrderDate == left.OrderDate);
        }

        public static bool operator !=(OrderDateType right, OrderDateType left)
        {
            return !(right.OrderDate == left.OrderDate);
        }

        public override int GetHashCode()
        {
            return this.OrderDate.GetHashCode();
        }

        public static implicit operator DateTime(OrderDateType obj) {
            return obj.OrderDate;
        }
    }

    public class OrderItems : IEquatable<OrderItems> {

        public OrderItems(int _productId, int _productQuantity, int _productPrice)
        {
            ProductID = _productId;
            ProductQuantity = _productQuantity;
            ProductPrice = _productPrice;
        }

        private OrderItems()
        {

        }
        public int ProductID { get;  set; }
        public int ProductQuantity { get;  set; }
        public int ProductPrice { get;  set; }

        public bool Equals(OrderItems other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return (other.ProductID == this.ProductID) && (other.ProductPrice == this.ProductPrice) && (other.ProductQuantity == this.ProductQuantity);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (!ReferenceEquals(this, obj))
                return false;
            return Equals((OrderItems)obj);
        }

        public static bool operator ==(OrderItems right, OrderItems left)
        {
            return (right.ProductID == left.ProductID) && (right.ProductPrice == left.ProductPrice) && (right.ProductQuantity == left.ProductQuantity);
        }

        public static bool operator !=(OrderItems right, OrderItems left)
        {
            return !(right.ProductID == left.ProductID) && (right.ProductPrice == left.ProductPrice) && (right.ProductQuantity == left.ProductQuantity);
        }

        public override int GetHashCode()
        {
            return this.ProductID.GetHashCode() + this.ProductPrice.GetHashCode() + this.ProductQuantity.GetHashCode();
        }
    }
}
