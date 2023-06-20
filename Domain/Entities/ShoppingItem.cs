
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShoppingItem
    {

        public int ItemId { get; set; }

        public int Amount { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string Packaging { get; set; }
        public Product Product { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public int ShoppingCartId { get; set; }

        public string Status { get; set; } // checkout -- 1, not check out -- 0
    }
}
