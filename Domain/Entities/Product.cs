namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool isActive { get; set; }
        public double AgentPrice { get; set; }
        public double OriginalPrice { get; set; }

        public double WholesalerPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PackagingList> PackagingLists { get; set; }
    }
    public class PackagingList
    {
        public int Id { get; set; }
        public string PackageName { get; set; } // 1.OP 2.PP
        public int ProductId { get; set; }
    }
}
