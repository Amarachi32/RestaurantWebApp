using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice
    {
       public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPostcode { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public double Gst { get; set; }
        public double PriceExclGst { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }

    }
}
