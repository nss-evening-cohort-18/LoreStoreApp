using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace LoreStoreAPI.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        OrderCheckoutViewModel GetOrderCheckoutViewByOrderId(int id);
        List<Order> GetAllOrdersByUserId(int id);
        List<Order> GetAllOrdersByOrderDate(DateTime dateTime);
        List<Order> GetAllOrdersByIsComplete(Boolean isComplete);
        List<Order> GetAllOrdersByStatus(string status);

        void AddOrder(Order order);

        int UpdateOrder(int id, Order order);
    }
}
