using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        //ASP.NET will give us an instance of our Order Repository. This is called "Dependency Injection"
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/<OrderController>
        [HttpGet]

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();

        }

        //GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order GetOrderById(int id)
        {
            //would like to create an if then statement to account for null order but not sure how to write it,
            //if (Order == null)
            //{return NotFound();}
            return _orderRepository.GetOrderById(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
