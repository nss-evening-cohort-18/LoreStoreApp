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
    }
}