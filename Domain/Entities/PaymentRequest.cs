using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingZipCode { get; set; }
    }

    public class Book
    {
        [Key] 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Price { get; set; }
    }
}
