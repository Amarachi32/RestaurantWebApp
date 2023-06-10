using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs
{
   
        public record GetProductDto(int id, string name, string description);
       
    

    public class CreateProductDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public  string Price { get; set;}
        public string Category { get; set; }    
    }

    public class UpdateProductDto
    {
        public string Id { get; set; } 
        public string Price { get; set; }
    }
}
