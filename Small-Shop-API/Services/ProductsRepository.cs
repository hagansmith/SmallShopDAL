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
                var products = db.Query<Variant>(@"
                                                        SELECT variants.[Id]
                                                              ,variants.[productId]
                                                              ,variants.title as option1
                                                              ,minimumStock as option2
                                                              ,[price]
                                                              ,[sku]
                                                              ,variants.[createdAt]
                                                              ,variants.[updatedAt]
                                                              ,[InventoryQuantity]
                                                              ,[weight]
                                                              ,[requiresShipping]
                                                              ,[OldInventoryQuantity]
                                                              ,[AllocatedStock]
                                                              ,[minimumStock]
	                                                          ,Products.title as title
                                                              ,i.src as imageId
                                                              ,l.Name as option3
                                                          FROM [Variants]
                                                          JOIN Products on Variants.productId = Products.id
                                                          JOIN Images i on products.id = i.productId
                                                          LEFT JOIN Locations l on Variants.Id = l.VariantId
                                                          ORDER BY title");
                return products.ToList();
            }
        }

        public List<InventoryDto> GetLowStock()
        {
            //var db = new ApplicationDbContext();
            //var prods = db.Products.SqlQuery(@"SELECT p.title, i.src image, v.sku, v.inventoryQuantity, v.Id
            //                                  FROM [dbo].[Products] p
            //                                  JOIN dbo.Variants v on p.id = v.productId
            //                                  JOIN dbo.Images i on p.id = i.productId
            //                                 WHERE v.inventoryQuantity <= v.minimumStock and v.sku <> ''");
            //return prods.ToList();

            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var products = db.Query<InventoryDto>(@"
                                            SELECT p.title, i.src image, v.sku, v.inventoryQuantity as inventory_quantity, v.Id as variantId
                                              FROM [dbo].[Products] p
                                              JOIN dbo.Variants v on p.id = v.productId
                                              JOIN dbo.Images i on p.id = i.productId
                                              WHERE v.inventoryQuantity <= v.minimumStock and v.sku <> ''");
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
                                                                      ,[inventoryQuantity]
                                                                      ,[Id]
                                                                  FROM [dbo].[Variants]
                                                                  WHERE Variants.sku = @id", new { id });
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
                var lines = db.Execute(@"INSERT INTO [dbo].[Reorders]
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
                var products = db.Query<InventoryDto>(@"
                                                        SELECT p.title, i.src image, v.sku, v.inventoryQuantity remaining, v.Id, r.quantity orderedInventoryQty, r.orderDate reorderDate, r.quantityReceived, r.id
                                                        FROM dbo.Reorders r
                                                        JOIN dbo.Variants v on r.variantId = v.Id
											            JOIN dbo.Products p on v.productId = p.id
                                                        JOIN dbo.Images i on p.Id = i.productId
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
                var result = db.Execute(@"UPDATE [dbo].[Reorders]
                                             SET [dateReceived] = @date
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

        public bool PatchCount(ProductCountDto product)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var date = DateTime.Now;
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Variants]
                                             SET [inventoryQuantity] = @inventory_quantity
                                                ,[minimumStock] = @option2
                                         WHERE Id = @Id", product);

                
                    db.Execute(@"if exists (select variantId from Locations where variantId = @Id)
	                                update Locations
		                            set Name=@location, Available=@inventory_quantity, UpdatedAt=@date
		                            where variantId=@Id
                                else
	                                Insert Into dbo.Locations (name, available, updatedAt, variantId)
                                    values (@location
                                    ,@inventory_quantity
                                    ,@date
                                    ,@Id)", new {location=product.location, inventory_quantity=product.inventory_quantity, Id=product.Id, date });

                return result == 1;
            }
        }

        public bool Delete(long id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                  var productRowsAffected = connection.Execute(@" DELETE FROM[dbo].[Variants]
                                                                        WHERE Id = @id", new { id });

                        
                  return productRowsAffected == 1;
            }
            
        }
    }
}