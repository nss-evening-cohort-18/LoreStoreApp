using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LoreStoreAPI.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IConfiguration _config;
        public OrderDetailRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public List<OrderDetail> GetOrderDetails()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT id,
                                       orderId,
                                       bookId,
                                       quantity,
                                       unitPrice
                                FROM [dbo].[OrderDetail]
                                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<OrderDetail> orderDetails = new List<OrderDetail>();
                        while (reader.Read())
                        {
                            OrderDetail orderDetail = new OrderDetail()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                OrderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                                BookId = reader.GetInt32(reader.GetOrdinal("bookId")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                                UnitPrice = reader.GetDouble(reader.GetOrdinal("unitPrice"))
                            };

                            orderDetails.Add(orderDetail);
                        }

                        return orderDetails;
                    }
                }
            }
        }

        public OrderDetail GetOrderDetailsById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT id,
                                       orderId,
                                       bookId,
                                       quantity,
                                       unitPrice
                                FROM [dbo].[OrderDetail]
                                WHERE id = @ID
                                        ";
                    cmd.Parameters.AddWithValue("@ID", id);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            OrderDetail orderDetail = new OrderDetail()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                OrderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                                BookId = reader.GetInt32(reader.GetOrdinal("bookId")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                                UnitPrice = reader.GetDouble(reader.GetOrdinal("unitPrice"))
                            };
                            return orderDetail;

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

            public List<OrderDetail> GetOrderDetailsByOrderId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT id,
                                       orderId,
                                       bookId,
                                       quantity,
                                       unitPrice
                                FROM [dbo].[OrderDetail]
                                WHERE orderId = @ID
                                        ";
                    cmd.Parameters.AddWithValue("@ID", id);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<OrderDetail> orderDetails = new List<OrderDetail>();
                        while (reader.Read())
                        {
                            OrderDetail orderDetail = new OrderDetail()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                OrderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                                BookId = reader.GetInt32(reader.GetOrdinal("bookId")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                                UnitPrice = reader.GetDouble(reader.GetOrdinal("unitPrice"))
                            };

                            orderDetails.Add(orderDetail);
                        }

                        return orderDetails;
                    }
                }
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO OrderDetail (orderId, bookId, quantity, unitPrice)
                    OUTPUT INSERTED.ID
                    VALUES (@orderId, @bookId, @quantity, @unitPrice);
                ";

                    cmd.Parameters.AddWithValue("@orderId", orderDetail.OrderId);
                    cmd.Parameters.AddWithValue("@bookId", orderDetail.BookId);
                    cmd.Parameters.AddWithValue("@quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@unitPrice", orderDetail.UnitPrice);

                    int id = (int)cmd.ExecuteScalar();

                    orderDetail.Id = id;
                }
            }
        }

        public void UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            UPDATE OrderDetail
                            SET 
                                orderId = @orderId, 
                                bookId = @bookId, 
                                quantity = @quantity, 
                                unitPrice = @unitPrice 
                            WHERE id = @id";

                    cmd.Parameters.AddWithValue("@orderId", orderDetail.OrderId);
                    cmd.Parameters.AddWithValue("@bookId", orderDetail.BookId);
                    cmd.Parameters.AddWithValue("@quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@unitPrice", orderDetail.UnitPrice);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrderDetail(int orderDetailId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM OrderDetail
                            WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", orderDetailId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
