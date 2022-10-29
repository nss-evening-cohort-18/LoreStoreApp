namespace LoreStoreAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public DateTime DatePublished { get; set; }
        public string Description { get; set; }
        public bool IsFiction { get; set; }
        public string SubGenre { get; set; }
        public double Price { get; set; }
        public int InventoryQuantity { get; set; }
        public string? PhotoUrl { get; set; }


        static public List<string> BookValidator(Book book)
        {
            List<string> errors = new();

            if (book is null)
            {
                errors.Add("Book item is null.");
                return errors;
            }
            if (book.Title is null)
            {
                errors.Add("Book must have a title");
            }
            if (book.Description is null)
            {
                errors.Add("Book must have a description");
            }
            if (book.IsFiction != (true || false))
            {
                errors.Add("Book must have a fiction type");
            }
            if (book.SubGenre is null)
            {
                errors.Add("Book must have a sub genre");
            }
            if (book.Price <= 0)
            {
                errors.Add("Book must have a price above $0");
            }
            if (book.InventoryQuantity <= 0)
            {
                errors.Add("New book inventory must be at least 1");
            }
            //not sure how to validate DateTime for OrderDate or Boolean for
            //IsComplete or string for Status (assumming we want/need to validate for these)
            return errors;
        }
    }
}