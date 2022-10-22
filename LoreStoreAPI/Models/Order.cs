namespace LoreStoreAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public Boolean IsComplete { get; set; }
        public string Status { get; set; }
    }
}
