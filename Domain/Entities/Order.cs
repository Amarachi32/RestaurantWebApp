
namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set;}
        public string OrderNo { get; set;}
        public int ProductId { get; set;}
        public Product Product { get; set;}
        public int Quantity { get; set;}
        public decimal TotalPrice { get; set;}
        public decimal Balance { get; set;}
        public string UserId { get; set;}
        public User User { get; set;}
        public string Status { get; set;}
        public int PaymentId { get; set;}
        public int ShoppingCartId { get; set;}
        public string InvoiceNo { get; set;}
        public string ClientMessage { get; set;}
        public string AdminMessage { get; set;}
        public DateTime OrderDate { get; set;}
    }
}
