using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Account { get; set; }
        public string Status { get; set; }

        public string BillingCustomerName { get; set; }
        public string BillingStreetNumber { get; set; }
        public string BillingAddressLine { get; set; }
        public string BillingSuburb { get; set; }
        public string BillingState { get; set; }
        public string BillingPostCode { get; set; }
        public string ShippingCustomerName { get; set; }
        public string ShippingStreetNumber { get; set; }
        public string ShippingAddressLine { get; set; }
        public string ShippingSuburb { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostCode { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string BussinessName { get; set; }
        public string Role { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        //public List<Order> Orders { get; set; }
       // public List<ShoppingItem> ShoppingItems { get; set; }
    }

    public enum RoleName
    {
        admin,
        agent,
        wholesaler
    }
}
