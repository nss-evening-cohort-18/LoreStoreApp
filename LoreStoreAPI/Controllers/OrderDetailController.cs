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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
