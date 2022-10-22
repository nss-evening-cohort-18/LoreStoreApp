using LoreStoreAPI.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace LoreStoreAPI.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
    }
}
