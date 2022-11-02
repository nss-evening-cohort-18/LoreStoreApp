using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Authorize]
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
        public IActionResult GetAllOrders()
        {
            List<Order> order = _orderRepository.GetAllOrders();
            if(order.Count <= 0 || order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            Order order = _orderRepository.GetOrderById(id);
            if(order is null)
            {
                return NoContent();
            }
            return Ok(order);
        }

        //GET api/<OrderController>/5
        [HttpGet("UserId/{id}")]
        public IActionResult GetAllOrdersByUserId(int id)
        {
            List<Order> order = _orderRepository.GetAllOrdersByUserId(id);
            if (order.Count <= 0 || order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //GET api/<OrderController>/DateTime
        [HttpGet("DateTime/{dateTime}")]
        public IActionResult GetAllOrdersByOrderDate(DateTime dateTime)
        {
            List<Order> order = _orderRepository.GetAllOrdersByOrderDate(dateTime);
            if (order.Count <= 0 || order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //GET api/<OrderController>/isComplete
        [HttpGet("isComplete/{isComplete}")]
        public IActionResult GetAllOrdersByIsComplete(Boolean isComplete)
        {
            List<Order> order = _orderRepository.GetAllOrdersByIsComplete(isComplete);
            if (order.Count <= 0 || order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //GET api/<OrderController>/status
        [HttpGet("Status/{status}")]
        public IActionResult GetAllOrdersByStatus(string status)
        {
            List<Order> order = _orderRepository.GetAllOrdersByStatus(status);
            if (order.Count <= 0 || order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            List<string> errors = Order.OrderValidator(order);
            if(errors.Count > 0)
            {
                string errorString = "";
                foreach(string error in errors)
                {
                    errorString += error + "\n";   
                }
                return BadRequest(errorString);
            }
            else
            {
                _orderRepository.AddOrder(order);
                return Ok();
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            List<string> errors = Order.OrderValidator(order);
            if (order == null || id <= 0 || errors.Count > 0)
            {
                string errorString = "";
                foreach (string error in errors)
                {
                    errorString += error + "\n";
                }
                return BadRequest(errorString);
            }

            int orderToUpdate = _orderRepository.UpdateOrder(id, order);
            if (orderToUpdate <= 0)
            {
                return BadRequest("Order does not exist");
            }
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
