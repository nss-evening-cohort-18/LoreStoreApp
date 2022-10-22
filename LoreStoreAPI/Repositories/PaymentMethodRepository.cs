using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;

namespace LoreStoreAPI.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly IConfiguration _config;
        public PaymentMethodRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        public List<PaymentMethod> GetPaymentMethods()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT id,
                                        userId,
                                        firstName,
                                        lastName,
                                        cardNumber,
                                        expirationMonth,
                                        expirationYear,
                                        cvv
                                FROM [dbo].[PaymentMethod]
                                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<PaymentMethod> paymentmethods = new List<PaymentMethod>();
                        while (reader.Read())
                        {
                            PaymentMethod paymentmethod = new PaymentMethod()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("userId")),
                                FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader.GetString(reader.GetOrdinal("lastName")),
                                CardNumber = reader.GetString(reader.GetOrdinal("cardNumber")),
                                ExpirationMonth = reader.GetString(reader.GetOrdinal("expirationMonth")),
                                ExpirationYear = reader.GetString(reader.GetOrdinal("expirationYear")),
                                Cvv = reader.GetString(reader.GetOrdinal("cvv"))
                            };

                            paymentmethods.Add(paymentmethod);
                        }

                        return paymentmethods;
                    }
                }
            }
        }

        public List<PaymentMethod> GetPaymentMethod(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT id,
                                        userId,
                                        firstName,
                                        lastName,
                                        cardNumber,
                                        expirationMonth,
                                        expirationYear,
                                        cvv
                                FROM [dbo].[PaymentMethod]
                                WHERE id = " + id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<PaymentMethod> paymentmethods = new List<PaymentMethod>();
                        while (reader.Read())
                        {
                            PaymentMethod paymentmethod = new PaymentMethod()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("userId")),
                                FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader.GetString(reader.GetOrdinal("lastName")),
                                CardNumber = reader.GetString(reader.GetOrdinal("cardNumber")),
                                ExpirationMonth = reader.GetString(reader.GetOrdinal("expirationMonth")),
                                ExpirationYear = reader.GetString(reader.GetOrdinal("expirationYear")),
                                Cvv = reader.GetString(reader.GetOrdinal("cvv"))
                            };

                            paymentmethods.Add(paymentmethod);
                        }

                        return paymentmethods;
                    }
                }
            }
        }

    }
}