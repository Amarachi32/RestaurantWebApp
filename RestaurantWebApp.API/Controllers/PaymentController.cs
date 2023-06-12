using Braintree;
using Contracts.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Interfaces;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IBraintreeService _braintreeService;
        public PaymentController(IBraintreeService braintreeService)
        {
            _braintreeService = braintreeService;
        }

        [HttpGet]
        public IActionResult GetPayment()
        {
            var paymentGateway = _braintreeService.GetGateway();
            paymentGateway.ClientToken.Generate();
            return Ok(paymentGateway);
        }

        [HttpPost]
        public IActionResult MakePayment(PaymentDto model)
        {
            string paymentStatus = string.Empty;
            var gateway = _braintreeService.GetGateway();
            var request = new TransactionRequest
            {
                //Amount = Convert.ToDecimal("250"),
                Amount = model.Price,
                PaymentMethodNonce = model.PaymentMethodNonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };
            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                paymentStatus = "Succeded";
            }
            else
            {
                paymentStatus = "Failure";
            }
            return Ok(paymentStatus);
        }
    }
}
