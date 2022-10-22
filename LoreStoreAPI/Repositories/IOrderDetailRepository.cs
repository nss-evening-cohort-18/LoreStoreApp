using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailsById(int id);
        List<OrderDetail> GetOrderDetailsByOrderId(int id);
        void AddOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(int id, OrderDetail orderDetail);
        void DeleteOrderDetail(int orderDetailId);
    }
}
