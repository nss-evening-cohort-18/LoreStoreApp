using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
                        SELECT Id, UserId, PaymentMethodId, Total, OrderDate, isComplete, [Status]
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
                        SELECT Id, UserId, PaymentMethodId, Total, OrderDate, isComplete, [Status]
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
    }
}
