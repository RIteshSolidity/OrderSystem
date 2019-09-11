using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using OrderSystem.Model.Core;

namespace OrderSystem.Repository
{
    public class OrdersDBContext : DbContext
    {

        public OrdersDBContext(DbContextOptions options) : base(options)
        {

        }
        public OrdersDBContext()
        {

        }

        public virtual DbSet<Orders> Orders {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>().OwnsOne(w => w.OrderDate).Property(x => x.OrderDate).HasColumnName("OrderDate");
            modelBuilder.Entity<Orders>().HasKey(w => w.OrderID);
            
            modelBuilder.Entity<Orders>().OwnsMany(w => w.lineItems).Property(x => x.ProductID).HasColumnName("ProductIdentifier");
            modelBuilder.Entity<Orders>().OwnsMany(w => w.lineItems).Property(x => x.ProductPrice).HasColumnName("ProductPrice");
            modelBuilder.Entity<Orders>().OwnsMany(w => w.lineItems).Property(x => x.ProductQuantity).HasColumnName("Quantity");

            modelBuilder.Entity<Orders>().OwnsMany(w => w.lineItems,
                x => {
                    x.HasForeignKey("OrderId");
                    x.Property<int>("OrderLineItemID").HasColumnName("OrderLineItemID");
                    x.HasKey("OrderLineItemID");
                    x.ToTable("OrderLine");
                }


                ) ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
