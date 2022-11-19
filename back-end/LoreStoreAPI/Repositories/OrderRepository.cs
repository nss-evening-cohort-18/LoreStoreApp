using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LoreStoreAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _config;

        //The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public OrderRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Order> GetAllOrders()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, 
                                UserId, 
                                PaymentMethodId, 
                                Total, 
                                OrderDate, 
                                isComplete, 
                                [Status]
                        FROM [dbo].[Order]
                    ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PaymentMethodId = reader.GetInt32(reader.GetOrdinal("PaymentMethodId")),
                                Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };

                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }

        public Order GetOrderById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, 
                                UserId, 
                                PaymentMethodId, 
                                Total, 
                                OrderDate, 
                                isComplete, 
                                [Status]
                        FROM [dbo].[Order]
                        WHERE Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PaymentMethodId = reader.GetInt32(reader.GetOrdinal("PaymentMethodId")),
                                Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };

                            return order;
                        } else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public OrderCheckoutViewModel GetOrderCheckoutViewByOrderId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT o.Id,
                                        o.UserId AS UserId,
                                        od.OrderId AS OrderId,
                                        od.BookId AS BookId,
                                        o.PaymentMethodId AS PaymentMethodId,
                                        o.OrderDate AS OrderDate,
                                        o.isComplete AS IsComplete,
                                        o.Status AS Status,
                                        b.title AS title,
                                        b.authorLastName AS authorLastName,
                                        b.authorFirstName AS authorFirstName,
                                        b.price AS price,
                                        o.Total AS Total,
                                        b.inventoryQuantity AS inventoryQuantity,
                                        od.quantity AS quantity,
                                        od.unitPrice AS unitPrice,
                                        b.photoUrl AS photoUrl,
                                        u.firstName AS firstName,
                                        u.lastName AS lastName,
                                        u.address1 AS address1,
                                        u.address2 AS address2,
                                        u.city AS city,
                                        u.state AS state,
                                        u.zip AS zip,
                                        p.cardNumber AS cardNumber,
                                        p.expirationMonth AS expirationMonth,
                                        p.expirationYear AS expirationYear,
                                        p.cvv AS cvv
                                        FROM [dbo].[Order] o
										LEFT JOIN [dbo].[User] AS u ON u.Id = o.UserId
                                        LEFT JOIN [dbo].[OrderDetail] AS od ON od.orderId = o.Id
                                        LEFT JOIN [dbo].[Book] AS b ON b.id = od.bookId
                                        LEFT JOIN [dbo].[PaymentMethod] AS p ON p.UserId = u.id
                                        WHERE o.Id = @id
                                        ";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            OrderCheckoutViewModel orderCheckoutViewModel = new OrderCheckoutViewModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                                BookId = reader.GetInt32(reader.GetOrdinal("BookId")),
                                PaymentMethodId = reader.GetInt32(reader.GetOrdinal("PaymentMethodId")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                AuthorLastName = reader.GetString(reader.GetOrdinal("authorLastName")),
                                AuthorFirstName = reader.GetString(reader.GetOrdinal("authorFirstName")),
                                Price = reader.GetDouble(reader.GetOrdinal("price")),
                                Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                InventoryQuantity = reader.GetInt32(reader.GetOrdinal("inventoryQuantity")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                                UnitPrice = reader.GetDouble(reader.GetOrdinal("unitPrice")),
                                PhotoUrl = reader.GetString(reader.GetOrdinal("photoUrl")),
                                FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader.GetString(reader.GetOrdinal("lastName")),
                                Address1 = reader.GetString(reader.GetOrdinal("address1")),
                                Address2 = reader.GetString(reader.GetOrdinal("address2")),
                                City = reader.GetString(reader.GetOrdinal("city")),
                                State = reader.GetString(reader.GetOrdinal("state")),
                                Zip = reader.GetString(reader.GetOrdinal("zip")),
                                CardNumber = reader.GetString(reader.GetOrdinal("cardNumber")),
                                ExpirationMonth = reader.GetString(reader.GetOrdinal("expirationMonth")),
                                ExpirationYear = reader.GetString(reader.GetOrdinal("expirationYear")),
                                Cvv = reader.GetString(reader.GetOrdinal("cvv"))
                            };
                            return orderCheckoutViewModel;
                        } else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Order> GetAllOrdersByUserId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT Id, 
                                UserId, 
                                PaymentMethodId, 
                                Total, 
                                OrderDate, 
                                isComplete, 
                                [Status]
                        FROM [dbo].[Order]
                        WHERE UserId = @id
                                        ";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PaymentMethodId = reader.GetInt32(reader.GetOrdinal("PaymentMethodId")),
                                Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };

                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }

        public List<Order> GetAllOrdersByOrderDate(DateTime dateTime)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT Id, 
                                UserId, 
                                PaymentMethodId, 
                                Total, 
                                OrderDate, 
                                isComplete, 
                                [Status]
                        FROM [dbo].[Order]
                        WHERE OrderDate = @dateTime
                                        ";
                    cmd.Parameters.AddWithValue("@dateTime", dateTime);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PaymentMethodId = reader.GetInt32(reader.GetOrdinal("PaymentMethodId")),
                                Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };

                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }

        public List<Order> GetAllOrdersByIsComplete (Boolean isComplete)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT Id, 
                                UserId, 
                                PaymentMethodId, 
                                Total, 
                                OrderDate, 
                                isComplete, 
                                [Status]
                        FROM [dbo].[Order]
                        WHERE isComplete = @isComplete
                                        ";
                    cmd.Parameters.AddWithValue("@isComplete", isComplete);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PaymentMethodId = reader.GetInt32(reader.GetOrdinal("PaymentMethodId")),
                                Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };

                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }

        public List<Order> GetAllOrdersByStatus(string status)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT Id, 
                                UserId, 
                                PaymentMethodId, 
                                Total, 
                                OrderDate, 
                                isComplete, 
                                [Status]
                        FROM [dbo].[Order]
                        WHERE [Status] = @status
                                        ";
                    cmd.Parameters.AddWithValue("@status", status);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PaymentMethodId = reader.GetInt32(reader.GetOrdinal("PaymentMethodId")),
                                Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };

                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }

        public void AddOrder(Order order)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO [dbo].[Order] (UserId, PaymentMethodId, Total, OrderDate, isComplete, [Status])
                                        OUTPUT INSERTED.ID
                                        VALUES (@UserId, @PaymentMethodId, @Total, @OrderDate, @isComplete, @Status)
                                        ";
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@PaymentMethodId", order.PaymentMethodId);
                    cmd.Parameters.AddWithValue("@Total", order.Total);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@isComplete", order.IsComplete);
                    cmd.Parameters.AddWithValue("@Status", order.Status);

                    int id = (int)cmd.ExecuteScalar();
                    order.Id = id;
                }
            }
        }

        public int UpdateOrder(int id, Order order)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        UPDATE [dbo].[Order]
                                        SET
                                            UserId = @UserId, 
                                            PaymentMethodId = @PaymentMethodId, 
                                            Total = @Total, 
                                            OrderDate = @OrderDate, 
                                            isComplete = @isComplete, 
                                            [Status] = @Status
                                        WHERE Id = @id
                                        ";
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@PaymentMethodId", order.PaymentMethodId);
                    cmd.Parameters.AddWithValue("@Total", order.Total);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@isComplete", order.IsComplete);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
