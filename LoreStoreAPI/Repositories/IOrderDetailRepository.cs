using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetails();
    }
}
