using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs
{
    public class PaymentRequestDto
    {

    }


    public class PaymentDto: Book
    {
        public decimal Price { get; set; }
        public string PaymentMethodNonce { get; set; }
    }
}
