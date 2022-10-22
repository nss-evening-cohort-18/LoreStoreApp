namespace LoreStoreAPI.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string Expirationyear { get; set; }
        public string Cvv { get; set; }
    }
}
