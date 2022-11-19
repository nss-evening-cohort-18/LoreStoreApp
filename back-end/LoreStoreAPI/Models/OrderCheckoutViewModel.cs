using System.ComponentModel.DataAnnotations;

namespace LoreStoreAPI.Models
{
    public class OrderCheckoutViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime OrderDate { get; set; }
        public Boolean IsComplete { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public int InventoryQuantity { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string? PhotoUrl { get; set; }

        [MaxLength(28)]
        public string? FirstName { get; set; }

        [MaxLength(28)]
        public string? LastName { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationMonth { get; set; }
        public string? ExpirationYear { get; set; }
        public string? Cvv { get; set; }
    }
}
