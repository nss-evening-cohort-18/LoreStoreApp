using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;

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
    }
}
