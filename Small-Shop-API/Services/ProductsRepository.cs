using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Small_Shop_API.Models;
using Small_Shop_API.Dto;

namespace Small_Shop_API.Services
{
    public class ProductsRepository
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int Post(Product product)
        {
            var db = new ApplicationDbContext();
            db.Products.Add(product);
            return db.SaveChanges();
        }

        public List<Variant> Get()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var products = db.Query<Variant>(@"USE [Small-Shop-Dev]
                                                        SELECT [variantId]
                                                              ,productVariant.[productId]
                                                              ,productVariant.title as option1
                                                              ,minimumStock as option2
                                                              ,[price]
                                                              ,[sku]
                                                              ,ProductVariant.[created]
                                                              ,ProductVariant.[updated]
                                                              ,[imageId]
                                                              ,[inventory_quantity]
                                                              ,[weight]
                                                              ,[requiresShipping]
                                                              ,[oldInventoryQty]
                                                              ,[allocatedInventoryQty]
                                                              ,[minimumStock]
	                                                          ,Product.title as title
                                                              ,i.src as image
                                                          FROM [Small-Shop-Dev].[dbo].[ProductVariant]
                                                          JOIN Product on ProductVariant.productId = Product.id
                                                          JOIN ProductImage i on product.id = i.productId
                                                          ORDER BY title");
                return products.ToList();
            }
        }

        public List<InventoryDto> GetLowStock()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var products = db.Query<InventoryDto>(@"USE [Small-Shop-Dev]
                                            SELECT p.title, i.src image, v.sku, v.inventory_quantity, v.variantId
                                              FROM [dbo].[Product] p
                                              JOIN dbo.ProductVariant v on p.id = v.productId
                                              JOIN dbo.ProductImage i on p.id = i.productId
                                              WHERE v.inventory_quantity <= v.minimumStock and v.sku <> ''");
                return products.ToList();
            }
        }

        public InventoryDto GetProductById(string id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var product = db.QueryFirst<InventoryDto>(@"SELECT  [title] 
                                                                      ,[sku]
                                                                      ,[imageId]
                                                                      ,[inventory_quantity]
                                                                      ,[variantId]
                                                                  FROM [dbo].[ProductVariant]
                                                                  WHERE ProductVariant.sku = @id", new { id });
                return product;
            }
        }

        public int DecrementProductCount(string variantId, int quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var lines = connection.Execute(@"UPDATE [dbo].[ProductVariant]
                                                        SET [updated] = GETDATE()
                                                           ,[inventory_quantity] -= @quantity
                                                        WHERE ProductVariant.variantId = @variantId", new {variantId, quantity});
                return lines;
            }

        }

        public int CreateReorder(string variantId, int count)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var reorderDate = DateTime.Now;
                db.Open();
                var lines = db.Execute(@"INSERT INTO [dbo].[Reorder]
                                                            ([variantId]
                                                            ,[quantity]
                                                            ,[orderDate])
                                                    VALUES
                                                            (@variantId
                                                            ,@count
                                                            ,@reorderDate)", new { variantId, count, reorderDate });
                return lines;
            }
        }

        public List<InventoryDto> GetProductsOnReorder()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var products = db.Query<InventoryDto>(@"USE [Small-Shop-Dev]
                                                        SELECT p.title, i.src image, v.sku, v.inventory_quantity remaining, v.variantId, r.quantity orderedInventoryQty, r.orderDate reorderDate, r.quantityReceived, r.id
                                                        FROM dbo.Reorder r
                                                        JOIN dbo.ProductVariant v on r.variantId = v.variantId
											            JOIN dbo.Product p on v.productId = p.id
                                                        JOIN dbo.ProductImage i on p.Id = i.productId
                                                        WHERE r.quantityReceived < r.quantity OR r.quantityReceived IS NULL");
                return products.ToList();
            }
        }

        public int Receive(int id, int count)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var date = DateTime.Now;
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Reorder]
                                             SET [dateRecieved] = @date
                                                ,[quantityReceived] = @count
                                           WHERE Id = @id", new {id, count, date});
                return result;
            } 
        }

        public int Edit(Variant product)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[ProductVariant]
                                               SET [title] = @title
                                                  ,[price] = @price
                                                  ,[sku] = @sku
                                                  ,[created] = @created
                                                  ,[updated] = @updated
                                                  ,[inventoryQty] = @inventoryQty
                                                  ,[weight] = @weight
                                                  ,[minimumStock] = @minimumStock
                                             WHERE variantId = @variantId", product);

                return result;
            }
        }

        public int PatchCount(Variant product)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[ProductVariant]
                                             SET [inventory_quantity] = @inventory_quantity
                                                ,[minimumStock] = @option2
                                         WHERE variantId = @variantId", product);

                return result;
            }
        }

        public int Delete(long id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                  var productRowsAffected = connection.Execute(@" DELETE FROM[dbo].[ProductVariant]
                                                                        WHERE variantId = @id", new { id });

                        
                  return productRowsAffected;
            }
            
        }
    }
}