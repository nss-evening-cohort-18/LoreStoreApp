using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;

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
					cmd.CommandText = @"SELECT  u.id, 
												u.firebaseId, 
												u.email, 
												u.firstName, 
												u.lastName, 
												u.username, 
												u.address1, 
												u.address2,
												u.city,
												u.[state],
												u.zip,
												ut.UserTypeId,
												ut.[Name] AS UserTypeName
										FROM [dbo].[User] u
										LEFT JOIN [dbo].[UserType] ut ON ut.UserTypeId = u.UserTypeId
									  ";

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						List<User> users = new List<User>();
						while (reader.Read())
						{
							User user = new User()
							{
								Id = reader.GetInt32(reader.GetOrdinal("id")),
								FirebaseUserId = reader.GetString(reader.GetOrdinal("firebaseId")),
								Email = reader.GetString(reader.GetOrdinal("email")),
								FirstName = reader[(reader.GetOrdinal("firstName"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("firstName")),
								LastName = reader[(reader.GetOrdinal("lastName"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("lastName")),
								Username = reader[(reader.GetOrdinal("username"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("username")),
								Address1 = reader[(reader.GetOrdinal("address1"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("address1")),
								Address2 = reader[(reader.GetOrdinal("address2"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("address2")),
								City = reader[(reader.GetOrdinal("city"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("city")),
								State = reader[(reader.GetOrdinal("state"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("state")),
								Zip = reader[(reader.GetOrdinal("zip"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("zip")),
								UserTypeId = reader.GetInt32(reader.GetOrdinal("UserTypeId")),
								UserType = new UserType()
								{
									Id = reader.GetInt32(reader.GetOrdinal("UserTypeId")),
									Name = reader.GetString(reader.GetOrdinal("UserTypeName"))
								}

							};
							users.Add(user);
						}
						return users;
					}

				}
			}
		}

		public User GetUserById(int id)
		{
			using (SqlConnection conn = Connection)
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"SELECT  u.id, 
												u.firebaseId, 
												u.email, 
												u.firstName, 
												u.lastName, 
												u.username, 
												u.address1, 
												u.address2,
												u.city,
												u.[state],
												u.zip,
												ut.UserTypeId,
												ut.[Name] AS UserTypeName
										FROM [dbo].[User] u
										LEFT JOIN [dbo].[UserType] ut ON ut.UserTypeId = u.UserTypeId
										WHERE u.id = @id
									  ";

					cmd.Parameters.AddWithValue("@id", id);


					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							User user = new User()
							{
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                FirebaseUserId = reader.GetString(reader.GetOrdinal("firebaseId")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                FirstName = reader[(reader.GetOrdinal("firstName"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader[(reader.GetOrdinal("lastName"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("lastName")),
                                Username = reader[(reader.GetOrdinal("username"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("username")),
                                Address1 = reader[(reader.GetOrdinal("address1"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("address1")),
                                Address2 = reader[(reader.GetOrdinal("address2"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("address2")),
                                City = reader[(reader.GetOrdinal("city"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("city")),
                                State = reader[(reader.GetOrdinal("state"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("state")),
                                Zip = reader[(reader.GetOrdinal("zip"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("zip")),
                                UserTypeId = reader.GetInt32(reader.GetOrdinal("UserTypeId")),
                                UserType = new UserType()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UserTypeId")),
                                    Name = reader.GetString(reader.GetOrdinal("UserTypeName"))
                                }
                            };
							return user;
						}
						else
						{
							return null;
						}
					}

				}
			}
		}


		public User GetUserByFirebaseId(string firebaseUserId)
		{
			using (SqlConnection conn = Connection)
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"SELECT  u.id, 
												u.firebaseId, 
												u.email, 
												u.firstName, 
												u.lastName, 
												u.username, 
												u.address1, 
												u.address2,
												u.city,
												u.[state],
												u.zip,
												ut.UserTypeId,
												ut.[Name] AS UserTypeName
								FROM [dbo].[User] u
								LEFT JOIN [dbo].[UserType] ut ON ut.UserTypeId = u.UserTypeId
								WHERE u.firebaseId = @FirebaseUserId
							  ";


					cmd.Parameters.AddWithValue("@FirebaseUserId", firebaseUserId);

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							User user = new User()
							{
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                FirebaseUserId = reader.GetString(reader.GetOrdinal("firebaseId")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                FirstName = reader[(reader.GetOrdinal("firstName"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader[(reader.GetOrdinal("lastName"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("lastName")),
                                Username = reader[(reader.GetOrdinal("username"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("username")),
                                Address1 = reader[(reader.GetOrdinal("address1"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("address1")),
                                Address2 = reader[(reader.GetOrdinal("address2"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("address2")),
                                City = reader[(reader.GetOrdinal("city"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("city")),
                                State = reader[(reader.GetOrdinal("state"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("state")),
                                Zip = reader[(reader.GetOrdinal("zip"))] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("zip")),
                                UserTypeId = reader.GetInt32(reader.GetOrdinal("UserTypeId")),
                                UserType = new UserType()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UserTypeId")),
                                    Name = reader.GetString(reader.GetOrdinal("UserTypeName"))
                                }
                            };
							return user;
						}
						else
						{
							return null;
						}
					}

				}
			}
		}

		public void AddUser(User user)
		{
			using (SqlConnection conn = Connection)
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"
											INSERT INTO [dbo].[User] 
															(firebaseId,
															email, 
															firstName, 
															lastName, 
															username, 
															address1, 
															address2, 
															city, 
															[state], 
															zip, 
															UserTypeId)
											OUTPUT INSERTED.ID
											VALUES (@firebaseId, @email, @firstName, @lastName, @username, @address1, @address2, @city, @state, @zip, @UserTypeId)
											";

					cmd.Parameters.AddWithValue("@firebaseId", user.FirebaseUserId);
					cmd.Parameters.AddWithValue("@email", user.Email);
					cmd.Parameters.AddWithValue("@firstName", user.FirstName != null ? user.FirstName : DBNull.Value);
					cmd.Parameters.AddWithValue("@lastName", user.LastName != null ? user.LastName : DBNull.Value);
					cmd.Parameters.AddWithValue("@username", user.Username != null ? user.Username : DBNull.Value);
					cmd.Parameters.AddWithValue("@address1", user.Address1 != null ? user.Address1 : DBNull.Value);
					cmd.Parameters.AddWithValue("@address2", user.Address2 != null ? user.Address2 : DBNull.Value);
					cmd.Parameters.AddWithValue("@city", user.City != null ? user.City : DBNull.Value);
					cmd.Parameters.AddWithValue("@state", user.State != null ? user.State : DBNull.Value);
					cmd.Parameters.AddWithValue("@zip", user.Zip != null ? user.Zip : DBNull.Value);
					cmd.Parameters.AddWithValue("@UserTypeId", user.UserTypeId);

					int id = (int)cmd.ExecuteScalar();

					user.Id = id;
				}
			}

		}

		public void UpdateUser(int id, User user)
		{
			using (SqlConnection conn = Connection)
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"
										UPDATE [dbo].[User]
										SET email = @email,
											firstName = @firstName,
											lastName = @lastname,
											username = @username,
											address1 = @address1,
											address2 = @address2,
											city = @city,
											[state] = @state,
											zip = @zip,
											UserTypeId = @UserTypeId
								
										WHERE Id = @id
										";
					cmd.Parameters.AddWithValue("@id", id);

					cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName != null ? user.FirstName : DBNull.Value);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName != null ? user.LastName : DBNull.Value);
                    cmd.Parameters.AddWithValue("@username", user.Username != null ? user.Username : DBNull.Value);
                    cmd.Parameters.AddWithValue("@address1", user.Address1 != null ? user.Address1 : DBNull.Value);
                    cmd.Parameters.AddWithValue("@address2", user.Address2 != null ? user.Address2 : DBNull.Value);
                    cmd.Parameters.AddWithValue("@city", user.City != null ? user.City : DBNull.Value);
                    cmd.Parameters.AddWithValue("@state", user.State != null ? user.State : DBNull.Value);
                    cmd.Parameters.AddWithValue("@zip", user.Zip != null ? user.Zip : DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserTypeId", user.UserTypeId);

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void DeleteUser(int id)
		{
			using (SqlConnection conn = Connection)
			{
				conn.Open();

				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"
								DELETE FROM [dbo].[User]
								WHERE Id = @id
							 ";

					cmd.Parameters.AddWithValue("@id", id);

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}



