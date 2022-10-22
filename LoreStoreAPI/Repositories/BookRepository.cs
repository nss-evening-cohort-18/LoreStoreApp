﻿using backend.Models;
using Microsoft.Data.SqlClient;

namespace backend.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _config;
        public BookRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        public List<Book> GetBooks()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT id,
                                        title,
                                        authorFirstName,
                                        authorLastName,
                                        datePublished,
                                        description,
                                        isFiction,
                                        subGenre,
                                        price,
                                        inventoryQuantity,
                                        photoUrl
                                FROM [dbo].[Book]
                                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Book> books = new List<Book>();
                        while (reader.Read())
                        {
                            Book book = new Book()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                AuthorFirstName = reader[reader.GetOrdinal("authorFirstName")] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("authorFirstName")),
                                AuthorLastName = reader[reader.GetOrdinal("authorLastName")] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("authorLastName")),
                                DatePublished = reader.GetDateTime(reader.GetOrdinal("datePublished")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                IsFiction = reader.GetBoolean(reader.GetOrdinal("isFiction")),
                                SubGenre = reader.GetString(reader.GetOrdinal("subGenre")),
                                Price = reader.GetDouble(reader.GetOrdinal("price")),
                                InventoryQuantity = reader.GetByte(reader.GetOrdinal("inventoryQuantity")),
                                PhotoUrl = reader[reader.GetOrdinal("photoUrl")] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("photoUrl"))
                        };

                            books.Add(book);
                        }

                        return books;
                    }
                }
            }
        }

    }
}