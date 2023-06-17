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
            var token = paymentGateway.ClientToken.Generate();
            
            return Ok(token);
        }



        [HttpPost]
        public IActionResult Create(BookPurchaseVM model)
        {
            var gateway = _braintreeService.GetGateway();
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal("250"),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest("Failure");
            }
        }


    /*    [HttpPost]
            public IActionResult PurchaseBook(BookPurchaseVM data)
            {
                // Process the book purchase
                // Example code:
                if (ModelState.IsValid)
                {
                    // Process the purchase logic using the provided book purchase data

                    // Optionally, you can retrieve the payment method nonce from the data.Nonce property
                    // and use it for payment processing

                    // Return a success response
                    return Ok();
                }
                else
                {
                    // Return a validation error response
                    return BadRequest(ModelState);
                }
            }
        
*/  


    /*    [HttpPost]
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


        [HttpPost]
        public IActionResult MakeCardPayment(IFormCollection collection)
        {
            Random rnd = new Random();
            string paymentStatus = string.Empty;
            string nonceFromtheClient = collection["payment_method_nonce"];
            var request = new TransactionRequest
            {
                Amount = rnd.Next(1, 100),
                PaymentMethodNonce = nonceFromtheClient,
                OrderId = "55502",
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }

            };
            var Gateway = _braintreeService.GetGateway();
            var gateway = _braintreeService.GetGateway();
            Result<Transaction> result = gateway.Transaction.Sale(request);
            // if(result.Target.ProcessorResponseText = "Approved")
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
   */
    }
}
