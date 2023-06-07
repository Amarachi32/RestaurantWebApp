﻿
namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}