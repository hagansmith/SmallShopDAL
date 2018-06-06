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
        readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<LineItem> Get()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var lineItems =
                    db.Query<LineItem>(@"SELECT 
                                           [id]
                                          ,[variant_id]
                                          ,[title]
                                          ,[quantity]
                                          ,[price]
                                          ,[sku]
                                          ,[variant_title]
                                          ,[vendor]
                                          ,[fulfillment_service]
                                          ,[product_id]
                                          ,[requires_shipping]
                                          ,[taxable]
                                          ,[gift_card]
                                          ,[name]
                                          ,[variant_inventory_management]
                                    FROM [dbo].[LineItem]");
                return lineItems.ToList();
            }
        }

        public int Post(Order order)
        {
            var db = new ApplicationDbContext();
            db.Orders.Add(order);
            return db.SaveChanges();
        }
    }
}