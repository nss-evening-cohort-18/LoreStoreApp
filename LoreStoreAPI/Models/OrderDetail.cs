namespace LoreStoreAPI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        static public List<string> OrderDetailValidator(OrderDetail od)
        {
            List<string> errors = new();

            if(od is null)
            {
                errors.Add("Order detail is null.");
                return errors;
            }
            if(od.OrderId <= 0)
            {
                errors.Add("Order Id must be greater than 0");
            }
            if(od.BookId <= 0)
            {
                errors.Add("Book Id must be greater than 0");
            }
            if( od.Quantity <= 0)
            {
                errors.Add("Quantity must be greater than 0");
            }
            if(od.UnitPrice <= 0)
            {
                errors.Add("Unit price must be greater than 0");
            }
            return errors;
            
        }
    }
}
