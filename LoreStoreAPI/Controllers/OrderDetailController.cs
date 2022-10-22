using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository _orderDetailData;
        public OrderDetailController(IOrderDetailRepository orderDetailData)
        {
            _orderDetailData = orderDetailData;
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        public List<OrderDetail> Get()
        {
            return _orderDetailData.GetOrderDetails();
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public OrderDetail Get(int id)
        {
            return _orderDetailData.GetOrderDetailsById(id);
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("OrderId/{id}")]
        public List<OrderDetail> GetByOrderId(int id)
        {
            return _orderDetailData.GetOrderDetailsByOrderId(id);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public void Post([FromBody] OrderDetail orderDetail)
        {
            _orderDetailData.AddOrderDetail(orderDetail);
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDetail orderDetail)
        {
            _orderDetailData.UpdateOrderDetail(id, orderDetail);
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderDetailData.DeleteOrderDetail(id);
        }
    }
}
