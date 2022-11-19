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

        public PaymentMethod GetPaymentMethodByUserId(int id)
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
                                WHERE userId = " + id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PaymentMethod result = new PaymentMethod()
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

                            return result;
                        } else
                        {
                            return null;
                        }

                    }
                }
            }
        }

        public void AddPaymentMethod(PaymentMethod paymentMethod)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [dbo].PaymentMethod (userId, firstName, lastName, cardNumber, expirationMonth, expirationYear, cvv)
                        OUTPUT INSERTED.ID
                        VALUES (@userId, @firstName, @lastName, @cardNumber, @expirationMonth, @expirationYear, @cvv);
                    ";

                    cmd.Parameters.AddWithValue("@userId", paymentMethod.UserId);
                    cmd.Parameters.AddWithValue("@firstName", paymentMethod.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", paymentMethod.LastName);
                    cmd.Parameters.AddWithValue("@cardNumber", paymentMethod.CardNumber);
                    cmd.Parameters.AddWithValue("@expirationMonth", paymentMethod.ExpirationMonth);
                    cmd.Parameters.AddWithValue("@expirationYear", paymentMethod.ExpirationYear);
                    cmd.Parameters.AddWithValue("@cvv", paymentMethod.Cvv);

                    int id = (int)cmd.ExecuteScalar();

                    paymentMethod.Id = id;
                }
            }
        }

        public int UpdatePaymentMethod(int id, PaymentMethod paymentMethod)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            UPDATE [dbo].PaymentMethod
                            SET 
                                userId = @userId, 
                                firstName = @firstName, 
                                lastName = @lastName, 
                                cardNumber = @cardNumber,
                                expirationMonth = @expirationMonth,
                                expirationYear = @expirationYear,
                                cvv = @cvv
                            WHERE id = @id";

                    cmd.Parameters.AddWithValue("@userId", paymentMethod.UserId);
                    cmd.Parameters.AddWithValue("@firstName", paymentMethod.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", paymentMethod.LastName);
                    cmd.Parameters.AddWithValue("@cardNumber", paymentMethod.CardNumber);
                    cmd.Parameters.AddWithValue("@expirationMonth", paymentMethod.ExpirationMonth);
                    cmd.Parameters.AddWithValue("@expirationYear", paymentMethod.ExpirationYear);
                    cmd.Parameters.AddWithValue("@cvv", paymentMethod.Cvv);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeletePaymentMethod(int paymentMethodId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM [dbo].PaymentMethod
                            WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", paymentMethodId);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}