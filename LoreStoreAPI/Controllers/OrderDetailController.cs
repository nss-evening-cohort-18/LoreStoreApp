using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

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
        public IActionResult GetAllOrderDetails()
        {
            List<OrderDetail> orderDetails = _orderDetailData.GetOrderDetails();
            if(orderDetails.Count <= 0 || orderDetails is null)
            {
                return NotFound();
            } 
                return Ok(orderDetails);
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            OrderDetail orderDetail = _orderDetailData.GetOrderDetailById(id);
            if(orderDetail is null)
            {
                return NoContent();
            }
            return Ok(orderDetail);
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("OrderId/{id}")]
        public IActionResult GetOrderDetailByOrderId(int id)
        {
            List <OrderDetail> orderDetails = _orderDetailData.GetOrderDetailsByOrderId(id);
            if( orderDetails.Count <= 0 || orderDetails is null)
            {
                return NoContent();
            }
            return Ok(orderDetails);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public IActionResult PostNewOrderDetail([FromBody] OrderDetail orderDetail)
        {
            List<string> errors = OrderDetail.OrderDetailValidator(orderDetail);
            if (errors.Count > 0)
            {
                string errorString = "";
                foreach (string error in errors)
                {
                    errorString += error + "\n";
                }
                return BadRequest(errorString);
            }
            else
            {
            _orderDetailData.AddOrderDetail(orderDetail);
            return Ok();
            }
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetail orderDetail)
        {
            List<string> errors = OrderDetail.OrderDetailValidator(orderDetail);
            if(orderDetail == null || id <= 0 || errors.Count > 0)
            {
                string errorString = "";
                foreach (string error in errors)
                {
                    errorString += error + "\n";
                }
                return BadRequest(errorString);
            }

            int orderToUpdate = _orderDetailData.UpdateOrderDetail(id, orderDetail);

            if (orderToUpdate <=0)
            {
                return BadRequest("Order detail does not exist");
            }
           
            return Ok();
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOredrDetail(int id)
        {
            int orderToDelete = _orderDetailData.DeleteOrderDetail(id);

            if (orderToDelete <= 0)
            {
                return BadRequest("Order detail does not exist");
            }

            
            return Ok();
        }
    }
}
