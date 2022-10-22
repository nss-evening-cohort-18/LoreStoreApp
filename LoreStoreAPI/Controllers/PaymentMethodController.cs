using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {

        private IPaymentMethodRepository _paymentMethodData;
        public PaymentMethodController(IPaymentMethodRepository paymentMethodData)
        {
            _paymentMethodData = paymentMethodData;
        }

        // GET: api/<PaymentMethodController>
        [HttpGet]
        public List<PaymentMethod> GetAllPaymentMethods()
        {
            return _paymentMethodData.GetPaymentMethods();

        }

        // GET api/<PaymentMethodController>/5
        [HttpGet("{id}")]
        public List<PaymentMethod> GetPaymentMethod(int id)
        {
            return _paymentMethodData.GetPaymentMethod(id);
        }

        // POST api/<PaymentMethodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}