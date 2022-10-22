using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace LoreStoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
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

        public List<User> GetUsers()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, 
                                               email, 
                                               firstName, 
                                               lastName, 
                                               username, 
                                               address1, 
                                               address2, 
                                               city, 
                                               [state], 
                                               zip, 
                                               isAdmin
                                          FROM [dbo].[User]
                                      ";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader.GetString(reader.GetOrdinal("lastName")),
                                Username = reader.GetString(reader.GetOrdinal("username")),
                                Address1 = reader.GetString(reader.GetOrdinal("address1")),
                                Address2 = reader.GetString(reader.GetOrdinal("address2")),
                                City = reader.GetString(reader.GetOrdinal("city")),
                                State = reader.GetString(reader.GetOrdinal("state")),
                                Zip = reader.GetString(reader.GetOrdinal("zip")),
                                IsAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin"))

                            };
                            users.Add(user);
                        }
                        return users;
                    }
                                        
                }
            }
        }
    }
}
