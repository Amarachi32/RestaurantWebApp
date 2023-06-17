using Braintree;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class BraintreeService : IBraintreeService
    {
        private readonly IConfiguration _config;
        public BraintreeSettings braintree { get; set; }
        private IBraintreeGateway gateway { get; set; }
        public BraintreeService( IConfiguration config)//IConfiguration config, IOptions<BraintreeSettings> options)
        {
            _config = config;
            _config = config;
            //  braintree = options.Value;
        }


        public IBraintreeGateway CreateGateway()
        {
            var newGateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _config["BraintreeGateway:MerchantId"],
                PublicKey = _config["BraintreeGateway:PublicKey"],
                PrivateKey = _config["BraintreeGateway:PrivateKey"]
            };
            return newGateway;
            // gateway.Transaction.Sale(newGateway);

            // return new BraintreeGateway(braintree.Enviroment, braintree.MerchantId, braintree.PublicKey, braintree.PrivateId);

        }

        public IBraintreeGateway GetGateway()
        {
            if(gateway == null)
            {
                gateway = CreateGateway();
            }

            return CreateGateway();

        }

 /*       public async Task<Result> RefundPayment(string transactionId)
        {
            Result<Transaction> result = await gateway.Transaction.RefundAsync(transactionId);

            // Process the result and return appropriate response
            // Example: return new Result { Success = result.IsSuccess(), Message = result.Message };
            return result;
        }*/

    }
}
