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
											   UserTypeId
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
								UserTypeId = reader.GetInt32(reader.GetOrdinal("UserTypeId"))

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
								   UserTypeId
							  FROM [dbo].[User]
							  WHERE id = @id
						  ";

					cmd.Parameters.AddWithValue("@id", id);


					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
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
								UserTypeId = reader.GetInt32(reader.GetOrdinal("UserTypeId"))

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
															(email, 
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
											VALUES (@email, @firstName, @lastName, @username, @address1, @address2, @city, @state, @zip, @UserTypeId)
											";

						
							cmd.Parameters.AddWithValue("@email", user.Email );
							cmd.Parameters.AddWithValue("@firstName", user.FirstName );
							cmd.Parameters.AddWithValue("@lastName", user.LastName );
							cmd.Parameters.AddWithValue("@username", user.Username );
							cmd.Parameters.AddWithValue("@address1", user.Address1 );
							cmd.Parameters.AddWithValue("@address2", user.Address2 );
							cmd.Parameters.AddWithValue("@city", user.City );
							cmd.Parameters.AddWithValue("@state", user.State );
							cmd.Parameters.AddWithValue("@zip", user.Zip );
							cmd.Parameters.AddWithValue("@UserTypeId", user.UserTypeId );

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
					cmd.Parameters.AddWithValue("@firstName", user.FirstName);
					cmd.Parameters.AddWithValue("@lastName", user.LastName);
					cmd.Parameters.AddWithValue("@username", user.Username);
					cmd.Parameters.AddWithValue("@address1", user.Address1);
					cmd.Parameters.AddWithValue("@address2", user.Address2);
					cmd.Parameters.AddWithValue("@city", user.City);
					cmd.Parameters.AddWithValue("@state", user.State);
					cmd.Parameters.AddWithValue("@zip", user.Zip);
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



