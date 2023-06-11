using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string NameOnCard { get; set; }
        public string BillingAddress1 { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethodNonce { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingZipCode { get; set; }
    }
}
