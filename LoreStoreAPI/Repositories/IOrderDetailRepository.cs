using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailById(int id);
        List<OrderDetail> GetOrderDetailsByOrderId(int id);
        void AddOrderDetail(OrderDetail orderDetail);
        int UpdateOrderDetail(int id, OrderDetail orderDetail);
        int DeleteOrderDetail(int orderDetailId);
        int DeleteOrderDetailByOrderId(int orderId);
    }
}
