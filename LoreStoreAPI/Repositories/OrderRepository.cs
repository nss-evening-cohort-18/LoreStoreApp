using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
                                        VALUES (@UserId, @PaymentMethodId, @Total, @OrderDate, @isComplete, @[Status])
                                        ";
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@PaymentMethodId", order.PaymentMethodId);
                    cmd.Parameters.AddWithValue("@Total", order.Total);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@isComplete", order.IsComplete);
                    cmd.Parameters.AddWithValue("@[Status]", order.Status);

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
                                            [Status] = @[Status]
                                        WHERE Id = @id
                                        ";
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@PaymentMethodId", order.PaymentMethodId);
                    cmd.Parameters.AddWithValue("@Total", order.Total);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@isComplete", order.IsComplete);
                    cmd.Parameters.AddWithValue("@[Status]", order.Status);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
