using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Authorize]
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
        public IActionResult PostNewPaymentMethod([FromBody] PaymentMethod paymentMethod)
        {
            List<string> errors = PaymentMethod.PaymentMethodValidator(paymentMethod);
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
                _paymentMethodData.AddPaymentMethod(paymentMethod);
                return Ok();
            }

        }

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePaymentMethod(int id, [FromBody] PaymentMethod paymentMethod)
        {
            List<string> errors = PaymentMethod.PaymentMethodValidator(paymentMethod);
            if (paymentMethod == null || id <= 0 || errors.Count > 0)
            {
                string errorString = "";
                foreach (string error in errors)
                {
                    errorString += error + "\n";
                }
                return BadRequest(errorString);
            }

            int paymentToUpdate = _paymentMethodData.UpdatePaymentMethod(id, paymentMethod);
            if (paymentToUpdate <= 0)
            {
                return BadRequest("Payment method does not exist.");
            }

            return Ok();
        }

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePaymentMethod(int id)
        {
            int paymentMethodToDelete = _paymentMethodData.DeletePaymentMethod(id);
            if (paymentMethodToDelete <= 0)
            {
                return BadRequest("Payment method does not exist.");
            }

            return Ok();
        }
    }
}