using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Small_Shop_API.Models;

namespace Small_Shop_API.Services
{
    public class OrdersRepository
    {
        public IQueryable<Order> Get()
        {
            var db = new ApplicationDbContext();
            return db.Set<Order>();
        }

        public int Post(Order order)
        {
            var db = new ApplicationDbContext();
            db.Orders.Add(order);
            foreach (LineItem item in order.LineItems)
            {
                var variant = db.Variants.SingleOrDefault(v => v.Id == item.VariantId);
                if (variant != null)
                {
                    variant.OldInventoryQuantity = variant.InventoryQuantity;
                    variant.InventoryQuantity -= item.Quantity;
                }
            }
            return db.SaveChanges();
        }
    }
}