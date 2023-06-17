using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs
{
   
        public record GetProductDto(int id, string name, string description);
       
    public class GetOneProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateProductDto
    {
        public int ProductId { get; set; }// = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public  decimal Price { get; set;}
        public string Description { get; set;} =    string.Empty;
       // public string ImageUrl { get; set;} =    string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Category Category { get; set; }    
    }

    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public string ImageUrl { get; set; } = string.Empty;

        public string Description { get; set; }

    }
}
