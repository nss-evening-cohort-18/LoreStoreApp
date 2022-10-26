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

        static public List<string> OrderValidator(Order order)
        {
            List<string> errors = new();

            if(order is null)
            {
                errors.Add("Order  is null.");
                return errors;
            }
            if(order.UserId <= 0)
            {
                errors.Add("User Id must be greater than 0");
            }
            if(order.PaymentMethodId <= 0)
            {
                errors.Add("Payment Method Id must be greater than 0");
            }
            if(order.Total <= 0)
            {
                errors.Add("Total must be greater than 0");
            }
            //not sure how to validate DateTime for OrderDate or Boolean for
            //IsComplete or string for Status (assumming we want/need to validate for these)
            return errors;
        }
    }
}
