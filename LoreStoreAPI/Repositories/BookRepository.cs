using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;

namespace LoreStoreAPI.Repositories
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

        public List<Book> GetBookById(int id)
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
                                WHERE id = @ID
                                       ";
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Book> resultBooks = new List<Book>();
                        if (reader.Read())
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

                            resultBooks.Add(book);

                            return resultBooks;
                        } else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void AddBook(Book book)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO Book (title, authorFirstName, authorLastName, datePublished, description, isFiction, subGenre, price, inventoryQuantity, photoURl)
                                        OUTPUT INSERTED.ID
                                        VALUES (@title, @authorFirstName, @authorLastName, @datePublished, @description, @isFiction, @subGenre, @price, @inventoryQuantity, @photoUrl);
                                       ";

                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@authorFirstName", book.AuthorLastName);
                    cmd.Parameters.AddWithValue("@authorLastName", book.AuthorFirstName);
                    cmd.Parameters.AddWithValue("@datePublished", book.DatePublished);
                    cmd.Parameters.AddWithValue("@description", book.Description);
                    cmd.Parameters.AddWithValue("@isFiction", book.IsFiction);
                    cmd.Parameters.AddWithValue("@subGenre", book.SubGenre);
                    cmd.Parameters.AddWithValue("@price", book.Price);
                    cmd.Parameters.AddWithValue("@inventoryQuantity", book.InventoryQuantity);
                    cmd.Parameters.AddWithValue("@photoUrl", book.PhotoUrl);

                    int id = (int)cmd.ExecuteScalar();
                    book.Id = id;
                }
            }
        }

        public int DeleteBook(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                    DELETE FROM Book
                                    WHERE id = @id
                                        ";
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int UpdateBook(int Id, Book book)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        UPDATE [dbo].[book]
                                        SET
                                            Title = @Title,
                                            AuthorFirstName = @authorFirstName,
                                            AuthorLastName = @authorLastName,
                                            DatePublished = @datePublished,
                                            Description = @description,
                                            IsFiction = @isFiction,
                                            SubGenre = @subGenre,
                                            Price = @price,
                                            InventoryQuantity = @inventoryQuantity,
                                            PhotoURl = @photoUrl
                                        WHERE Id = @id
                                        ";
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@authorFirstName", book.AuthorLastName);
                    cmd.Parameters.AddWithValue("@authorLastName", book.AuthorFirstName);
                    cmd.Parameters.AddWithValue("@datePublished", book.DatePublished);
                    cmd.Parameters.AddWithValue("@description", book.Description);
                    cmd.Parameters.AddWithValue("@isFiction", book.IsFiction);
                    cmd.Parameters.AddWithValue("@subGenre", book.SubGenre);
                    cmd.Parameters.AddWithValue("@price", book.Price);
                    cmd.Parameters.AddWithValue("@inventoryQuantity", book.InventoryQuantity);
                    cmd.Parameters.AddWithValue("@photoUrl", book.PhotoUrl);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}