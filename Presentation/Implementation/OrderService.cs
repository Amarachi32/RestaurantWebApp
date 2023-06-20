using AutoMapper;
using CloudinaryDotNet.Actions;
using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Interfaces;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly IRepository<Order> _orderDataRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartDataRepository;
        private readonly IRepository<ShoppingItem> _shoppingItemDataRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IShare share;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _orderDataRepository = unitOfWork.GetRepository<Order>();
            _shoppingItemDataRepository = unitOfWork.GetRepository<ShoppingItem>();
            _httpContextAccessor= httpContextAccessor;
            _userManager = userManager;
            _shoppingCartDataRepository = unitOfWork.GetRepository<ShoppingCart>();
            _mapper = mapper;

        }
        public async Task<ApiResponse> AddOrders(ShoppingCart cart, double gst, double priceExclGst, double discount)
        {
            try
            {
                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Quantity = cart.TotalItems,
                    TotalPrice = cart.TotalPrice,
                    Status = "Unprocessed",
                    UserId = cart.UserId,
                    ShoppingCartId = cart.CartId,
                    InvoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    ClientMessage = cart.PaymentMethod == "onaccount" ? "ON ACCOUNT" : "PREPAYMENT",
                    AdminMessage = "",
                    Balance = 0
                };
                _orderDataRepository.Add(order);
                int orderId;
                if (!(await _orderDataRepository.Queryable.AnyAsync()))//.ToList()).Count < 1)//.GetListAsync()).Count < 1)
                {
                    orderId = 1;
                }
                else
                {
                    orderId = _orderDataRepository.Queryable.LastOrDefault().OrderId + 1;
                }
                // var currentUser = await userRepository.GetUserByAccount(cart.UserId);
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

                double priceIncGst = priceExclGst + gst;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<div style='padding: 0; margin: 0; width:100%; height: 100%; background:#fbfaf7;'>");
                stringBuilder.Append("<table width='100%' height='100%' align='center' cellspacing='0' cellpadding='0' bgcolor='#fbfaf7'>");
                stringBuilder.Append("<tbody>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'>&nbsp;</td></tr>");
                stringBuilder.Append("<tr>");
                stringBuilder.Append("<td style='color:#343731;'><table width='600px' bgcolor='#ffffff' cellspacing='0' cellpadding='0' align='center' border='0' style='border:1px solid #232323;text-align:center'><tbody><tr><td style='padding:10px;color:#343731'>");
                stringBuilder.Append("<h2 style='font-weight:400;text-transform:uppercase'>Trojan Trading Company PTY LTD</h2>");
                stringBuilder.Append("</td></tr>");
                stringBuilder.Append("<tr style='text-align:left'><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'><table width='90%'><tbody>");
                stringBuilder.Append("<tr><td valign='top' width='50%' style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'><h3 style='margin:15px 20px 10px 20px;font-size:1.1em;color:#454545;text-align:left'>Shipping Address</h3>");
                stringBuilder.Append("<p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545;margin:12px 20px 10px 20px;margin-bottom:0'>" + currentUser.BussinessName + "<br>");
                stringBuilder.Append(currentUser.ShippingStreetNumber + " " + currentUser.ShippingAddressLine + "<br> " + currentUser.ShippingSuburb + ", " + currentUser.ShippingState + ", " + currentUser.ShippingPostCode + "<br>");
                stringBuilder.Append("<strong>Email:</strong><a href='" + currentUser.Email + "' target='_blank'>" + currentUser.Email + "</a><br><strong>Phone:</strong>" + currentUser.PhoneNumber + "</p></td>");
                stringBuilder.Append("<td valign='top' width='50%' style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'><h3 style='margin:15px 20px 10px 20px;font-size:1.1em;color:#454545;text-align:left'>Billing Address</h3>");
                stringBuilder.Append("<p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545;margin:12px 20px 10px 20px;margin-bottom:0'>" + currentUser.BussinessName + "<br>");
                stringBuilder.Append(currentUser.BillingStreetNumber + " " + currentUser.BillingAddressLine + "<br> " + currentUser.BillingSuburb + ", " + currentUser.BillingState + ", " + currentUser.BillingPostCode + "<br>");
                stringBuilder.Append("<strong>Email:</strong><a href='" + currentUser.Email + "' target='_blank'>" + currentUser.Email + "</a><br><strong>Phone:</strong>" + currentUser.PhoneNumber + "</p></td>");
                stringBuilder.Append("</tr></tbody></table></td></tr>");
                stringBuilder.Append("</tbody></table></td></tr>");
                stringBuilder.Append("<tr><td width='600' style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'>");
                stringBuilder.Append("<table cellspacing='0' cellpadding='0' width='600' align='center' bgcolor='#ffffff' border='0' style='border-right:1px solid #d3d3d3;border-left:1px solid #d3d3d3'>");
                stringBuilder.Append("<tbody><tr><td align='center' style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'>&nbsp;</td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'>");
                stringBuilder.Append("<h3 style='margin:15px 20px 10px 20px;font-size:1.1em;color:#454545;text-align:center'>Order #" + share.RandomString(4, true) + share.RandomNumber(1000, 9999).ToString() + " for Customer " + currentUser.Account + "</h3>");
                stringBuilder.Append("</td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'><table width='90%' cellspacing='0' cellpadding='0' align='center' bgcolor='#ffffff' border='0'>");
                stringBuilder.Append("<tbody><tr>");
                stringBuilder.Append("<td style='padding:1em 0.25em;border-bottom:1px solid #c4c4c4'></td>");
                stringBuilder.Append("<td style='padding:1em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong style ='font-size:10px'>Packaging</strong></td>");
                stringBuilder.Append("<td style='padding:1em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong style ='font-size:10px'>Original Price</strong></td>");
                stringBuilder.Append("<td style='padding:1em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong style='font-size:10px'>Buy Price</strong></td>");
                stringBuilder.Append("<td style='padding:1em 0.25em;border-bottom:1px solid #c4c4c4;text-align:center'><strong style ='font-size:10px'>Order Qty</strong></td>");
                stringBuilder.Append("<td style='padding:1em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong style='font-size:10px'>Line Amount</strong></td></tr>");
                foreach (var item in cart.ShoppingItems)
                {
                    stringBuilder.Append("<tr><td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4'><h4 style='margin:0'>" + item.Product.Name + "</h4></td>");
                    stringBuilder.Append("<td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><p style='font:12px/1.5 Arial,Helvetica,sans-serif;margin:0 0 0 0'>" + item.Packaging + "</p></td>");
                    stringBuilder.Append("<td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><p style='font:12px/1.5 Arial,Helvetica,sans-serif;margin:0 0 0 0'>$" + item.Product.OriginalPrice + "</p></td>");
                    if (currentUser.Role.ToLower() == "agent")
                    {
                        stringBuilder.Append("<td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong>$" + String.Format("{0:0.00}", item.Product.AgentPrice) + "</strong></td>");
                    }
                    else if (currentUser.Role.ToLower() == "wholesaler")
                    {
                        stringBuilder.Append("<td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong>$" + String.Format("{0:0.00}", item.Product.WholesalerPrice) + "</strong></td>");
                    }
                    stringBuilder.Append("<td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4;text-align:center'>" + item.Amount + "</td>");
                    if (currentUser.Role.ToLower() == "agent")
                    {
                        stringBuilder.Append("<td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><span><strong>$" + String.Format("{0:0.00}", item.Product.AgentPrice * item.Amount) + "</strong></span></td></tr>");
                    }
                    else if (currentUser.Role.ToLower() == "wholesaler")
                    {
                        stringBuilder.Append("<td style='padding:0 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><span><strong>$" + String.Format("{0:0.00}", item.Product.WholesalerPrice * item.Amount) + "</strong></span></td></tr>");
                    }
                }
                stringBuilder.Append("</tbody>");
                stringBuilder.Append("<tfoot>");
                stringBuilder.Append("<tr><td colspan='2'>&nbsp;</td><td colspan='3' width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4'>Payment Method</td>");
                stringBuilder.Append("<td width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong><span>" + String.Format("{0}", cart.PaymentMethod == "onaccount" ? "On Account" : "Prepayment") + "</span></strong></td></tr>");
                stringBuilder.Append("<tr><td colspan='2'>&nbsp;</td><td colspan='3' width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4'>Total Price Excl.GST</td>");
                stringBuilder.Append("<td width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong>$<span>" + String.Format("{0:0.00}", priceExclGst) + "</span></strong></td></tr>");
                stringBuilder.Append("<tr><td colspan='2'>&nbsp;</td><td colspan='3' width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4'>GST</td>");
                stringBuilder.Append("<td width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong>$<span>" + String.Format("{0:0.00}", gst) + "</span></strong></td></tr>");
                stringBuilder.Append("<tr><td colspan='2'>&nbsp;</td><td colspan='3' width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4'>Total Price Inc.GST</td>");
                stringBuilder.Append("<td width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong>$<span>" + String.Format("{0:0.00}", priceIncGst) + "</span></strong></td></tr>");
                stringBuilder.Append("<tr><td colspan='2'>&nbsp;</td><td colspan='3' width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4'>Total Discount Earned</td>");
                stringBuilder.Append("<td width='100' style='padding:0.5em 0.25em;border-bottom:1px solid #c4c4c4;text-align:right'><strong>$<span>" + String.Format("{0:0.00}", discount) + "</span></strong></td></tr>");
                stringBuilder.Append("</tfoot></table></td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'>&nbsp;</td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545;text-align:center;border-bottom:1px solid #d3d3d3'><p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#45659d;margin:12px 20px 10px 20px;text-decoration:none'>BSB: </p><p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#45659d;margin:12px 20px 10px 20px;text-decoration:none'>Account Number: </p><p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#45659d;margin:12px 20px 10px 20px;text-decoration:none'>Account Name: </p></td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545;text-align:center;'><p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#45659d;margin:12px 20px 10px 20px;text-decoration:none'>Diclaimer</p></td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545;text-align:center;border-bottom:1px solid #d3d3d3'><p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#45659d;margin:12px 20px 10px 20px;text-decoration:none'>xxxxxx</p></td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545;background:#f6f4ef;text-align:center;border-bottom:1px solid #d3d3d3'><p style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#45659d;margin:12px 20px 10px 20px;text-decoration:none'><a style='color:#454545;text-decoration:none' target='_blank'><strong>https://XXXXXXXX</strong></a></p></td></tr>");
                stringBuilder.Append("</tbody></table></td></tr>");
                stringBuilder.Append("<tr><td style='font:12px/1.5 Arial,Helvetica,sans-serif;color:#454545'>&nbsp;</td></tr>");
                stringBuilder.Append("</tbody></table></div>");
                string emailBody = stringBuilder.ToString();
                share.SendEmail("testprojectemail2019@gmail.com", currentUser.Email, "test", emailBody, "", "", true);

                foreach (var si in cart.ShoppingItems)
                {
                    si.Status = "1";
                    si.Product = null;
                    si.ShoppingCartId = cart.CartId;
                }
               // _orderDataRepository.UpdateRange(cart.ShoppingItems.ToList());
                _shoppingItemDataRepository.UpdateRange(cart.ShoppingItems.ToList());
               // await _shoppingItemDataRepository.SaveChangesAsync();
                cart.Status = "1";
                _shoppingCartDataRepository.Update(cart);
               // await _shoppingCartDataRepository.SaveChangesAsync();
                ShoppingCart sc = new ShoppingCart()
                {
                    TotalItems = 0,
                    OriginalPrice = 0,
                    TotalPrice = 0,
                    UserId = order.UserId,
                    Status = "0",
                    PaymentMethod = "onaccount"
                };

                _shoppingCartDataRepository.Add(sc);
               // await _shoppingCartDataRepository.SaveChangesAsync();

                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully create order"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }

        }
      
        
        public async Task<ApiResponse> AddOrder(ShoppingCart cart, double gst, double priceExclGst, double discount)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            try
            {
                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Quantity = cart.TotalItems,
                    TotalPrice = cart.TotalPrice,
                    Status = "Unprocessed",
                    UserId = cart.UserId,
                    ShoppingCartId = cart.CartId,
                    InvoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    ClientMessage = cart.PaymentMethod == "onaccount" ? "ON ACCOUNT" : "PREPAYMENT",
                    AdminMessage = "",
                    Balance = 0
                };

                // Add the order to the repository
                await _orderDataRepository.AddAsync(order);

                // Get the order ID
                int orderId = order.OrderId;

                // Create the invoice
                Invoice invoice = new Invoice()
                {
                    OrderId = orderId,
                    InvoiceDate = DateTime.Now,
                    InvoiceNumber = order.InvoiceNo,
                    CustomerId = cart.UserId,
                    CustomerName = cart.User.BillingCustomerName,
                    CustomerAddress = cart.User.BillingAddressLine,
                    CustomerPostcode = cart.User.BillingPostCode,
                    CustomerPhone = cart.User.PhoneNumber,
                    CustomerEmail = cart.User.Email,
                    Gst = gst,
                    PriceExclGst = priceExclGst,
                    Discount = discount,
                    TotalPrice = cart.TotalPrice
                };

                // Add the invoice to the repository
               // await _invoiceRepository.Add(invoice);

                // Return a success response
                return new ApiResponse
                {
                    Status = "success",
                    Message = "Order added successfully"
                };
            }
            catch (Exception ex)
            {
                // Return an error response
                return new ApiResponse
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }
      /*  public async Task<ApiResponse> AddOrder(ShoppingCart cart, double gst, double priceExclGst, double discount)
        {
            try
            {
                // Add the order to the repository
                await _orderDataRepository.AddAsync(order);

                // Get the order ID
                int orderId = order.OrderId;

                // Generate the invoice
                Invoice invoice = InvoiceGenerator.GenerateInvoice(orderId, gst, priceExclGst, discount);

                // Add the invoice to the repository
                await _invoiceRepository.Add(invoice);

                // Return a success response
                return new ApiResponse
                {
                    Status = "success",
                    Message = "Order added successfully"
                };
            }
            catch (Exception ex)
            {
                // Return an error response
                return new ApiResponse
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }
*/
        public async Task<Order> Get(int id)
        {
            var order = await _orderDataRepository.Queryable
                .Where(o => o.OrderId == id)
                .FirstOrDefaultAsync();
            return order;
        }

        public async Task<ApiResponse> DeleteOrder(int id)
        {
            try
            {
                var order = await _orderDataRepository.Queryable.Where(u => u.OrderId == id).FirstOrDefaultAsync();
                _orderDataRepository.Delete(order);
               // await _orderDataRepository.SaveChangesAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully delete order"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> UpdateOrder(Order order)
        {
            try
            {
                _orderDataRepository.Update(order);
              //  await _orderDataRepository.SaveChangesAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully update order"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }

        public async Task<List<Order>> GetOrdersByUserID(int userId, string dateFrom, string dateTo)
        {

            DateTime fromDate = string.IsNullOrEmpty(dateFrom) ? DateTime.Now.AddMonths(-1).Date : DateTime.ParseExact(dateFrom, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture).Date;
            DateTime toDate = string.IsNullOrEmpty(dateTo) ? DateTime.Now.AddDays(1).Date : DateTime.ParseExact(dateTo, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture).AddDays(1).Date; // end date always next day midnight

            var orders = await _orderDataRepository.Queryable
                .Where(x => x.UserId.Equals(userId) && DateTime.Compare(x.OrderDate, fromDate) >= 0 && DateTime.Compare(x.OrderDate, toDate) <= 0).ToListAsync();

            foreach (var order in orders)
            {
                var orderDetails = await GetOrdersWithShoppingItems(order.OrderId);
                order.ShoppingCart = orderDetails.ShoppingCart;
                order.User = orderDetails.User;
            }

            return orders;

        }

        public async Task<List<Order>> GetOrdersByDate(string dateFrom, string dateTo)
        {
            List<Order> orders = new List<Order>();

            DateTime fromDate = string.IsNullOrEmpty(dateFrom) ? DateTime.Now.AddMonths(-1).Date : DateTime.ParseExact(dateFrom, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture).Date;
            DateTime toDate = string.IsNullOrEmpty(dateTo) ? DateTime.Now.AddDays(1).Date : DateTime.ParseExact(dateTo, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture).AddDays(1).Date; // end date always next day midnight

            orders = await _orderDataRepository.Queryable
                .Where(x => DateTime.Compare(x.OrderDate, fromDate) >= 0 && DateTime.Compare(x.OrderDate, toDate) <= 0).ToListAsync();

            foreach (var order in orders)
            {
                var orderDetails = await GetOrdersWithShoppingItems(order.OrderId);
                order.ShoppingCart = orderDetails.ShoppingCart;
                order.User = orderDetails.User;
            }
            return orders;

        }

        public async Task<Order> GetOrdersWithShoppingItems(int orderId)
        {
            var order = await _orderDataRepository.Queryable.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();

            var shoppingCart = await _shoppingCartService.GetShoppingCartByID(order.ShoppingCartId, order.UserId);

            var userDetail = await _userService.GetUserByIdAsync(order.UserId);

            order.ShoppingCart = shoppingCart;
            order.User = userDetail;

            return order;

        }

        /*  public async Task<Order> GetOrdersWithShoppingItems(int orderId)
          {
              var order = await _orderDataRepository.Queryable
                  .Where(x => x.OrderId == orderId)
                  .FirstOrDefaultAsync();

              var shoppingCart = await _shoppingCartDataRepository.Queryable
                  .Where(s => s.CartId == order.ShoppingCartId)
                  .GroupJoin(
                      _shoppingItemDataRepository.Queryable, // Assuming there's a Queryable property to retrieve shopping items
              sc => sc.CartId,
              si => si.ShoppingCartId,
              (shoppingCartModel, shoppingItems) => new
              {
                  ShoppingCart = shoppingCartModel,
                  ShoppingItems = shoppingItems.ToList()
              })
                  .Select(join => new ShoppingCart
                  {
                      CartId = join.ShoppingCart.CartId,
                      TotalItems = join.ShoppingCart.TotalItems,
                      TotalPrice = join.ShoppingCart.TotalPrice,
                      ShoppingItems = join.ShoppingItems,
                      OriginalPrice = join.ShoppingCart.OriginalPrice,
                      UserId = join.ShoppingCart.UserId,
                      Status = join.ShoppingCart.Status,
                      PaymentMethod = join.ShoppingCart.PaymentMethod
                  })
                  .FirstOrDefaultAsync();

              if (shoppingCart.TotalItems > 0)
              {
                  var productIds = shoppingCart.ShoppingItems.Select(si => si.ProductId).ToList();
                  var products = new List<Product>();

                  foreach (var productId in productIds)
                  {
                      var product = await _productService.GetProductById(productId);
                      if (product != null)
                          products.Add(product);
                  }
                 // var products = await _productService.GetProductById(productIds);

                  shoppingCart.ShoppingItems = shoppingCart.ShoppingItems
                      .Join(
                          products,
                          si => si.ProductId,
                          p => p.ProductId,
                          (shoppingItem, product) => new ShoppingItem
                          {
                              ItemId = shoppingItem.ItemId,
                              Amount = shoppingItem.Amount,
                              Product = product,
                              ProductId = product.ProductId,
                              Status = shoppingItem.Status,
                              Packaging = shoppingItem.Packaging
                          })
                      .ToList();
              }

              var userDetail = await _userService.GetUserByIdAsync(order.UserId);
              order.ShoppingCart = shoppingCart;
              order.User = userDetail;

              return order;
          }
  */

        /*        public async Task<Order> GetOrdersWithShoppingItems(int orderId)
                {
                    var order = await _orderDataRepository.Queryable.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();

                    var shoppingCart = await _shoppingCartDataRepository.Queryable.Where(s => s.CartId == order.ShoppingCartId).FirstOrDefaultAsync();
        ;
                    if (shoppingCart.TotalItems > 0)
                    {
                        var productIds = shoppingCart.ShoppingItems.Select(si => si.ProductId);
                        var products = await _productService.GetProductById(productIds);
                        shoppingCart.ShoppingItems = products
                            .Select(p => new ShoppingItem
                            {
                                Id = p.Id,
                                Amount = p.Amount,
                                Product = p,
                                ProductId = p.Id,
                                Status = p.Status,
                                Packaging = p.Packaging
                            });
                    }

                    // var userDetail = await userRepository.GetUserByAccount(order.UserId);
                    var userDetail = await _userService.GetUserByIdAsync(order.UserId);
                    order.ShoppingCart = shoppingCart;
                    order.User = userDetail;
                    if (shoppingCart.TotalItems > 0)
                    {
                        shoppingCart.ShoppingItems = shoppingCart.ShoppingItems
                            .Join(Product, si => si.ProductId, p => p.Id, (shoppingItem, product) => new ShoppingItem
                            {
                                Id = shoppingItem.Id,
                                Amount = shoppingItem.Amount,
                                Product = product,
                                ProductId = product.Id,
                                Status = shoppingItem.Status,
                                Packaging = shoppingItem.Packaging
                            }).ToList();
                    }
                    return order;

                }

        */

/*        public static Invoice GenerateInvoice(int orderId, double gst, double priceExclGst, double discount)
        {
            // Get the order from the repository
            Order order = await _orderDataRepository.GetById(orderId);

            // Get the items in the cart
            List<ShoppingCartItem> items = await _shoppingCartRepository.GetItemsByCartId(order.CartId);

            // Calculate the total price
            double totalPrice = 0;
            foreach (ShoppingCartItem item in items)
            {
                totalPrice += item.Quantity * item.Price;
            }

            // Calculate the GST
            double gstAmount = totalPrice * gst / 100;

            // Calculate the discount
            double discountAmount = totalPrice * discount / 100;

            // Create the invoice
            Invoice invoice = new Invoice()
            {
                OrderId = orderId,
                InvoiceDate = DateTime.Now,
                InvoiceNumber = order.InvoiceNo,
                CustomerId = order.CustomerId,
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                CustomerPostcode = order.CustomerPostcode,
                CustomerPhone = order.CustomerPhone,
                CustomerEmail = order.CustomerEmail,
                GST = gst,
                PriceExclGst = priceExclGst,
                Discount = discount,
                Total = totalPrice - discountAmount + gstAmount
            };

            return invoice;
        }
*/
    }
}
/*    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void PlaceOrder(Order order)
        {
            // Calculate the total price.
            double totalPrice = 0.0;
            foreach (var product in order.Products)
            {
                totalPrice += product.Price * order.Quantity;
            }

            // Create an order and save it to the database.
            Order newOrder = new Order
            {
                CustomerId = order.CustomerId,
                Products = order.Products,
                TotalPrice = totalPrice
            };
            _orderRepository.Save(newOrder);
        }
    }
*/

/*public async Task<ApiResponse> PlaceOrder(int cartId, double gst, double priceExclGst, double discount)
{
    try
    {
        // Get the cart from the repository
        ShoppingCart cart = await _shoppingCartRepository.GetById(cartId);

        // Check if the cart exists
        if (cart == null)
        {
            return new ApiResponse
            {
                Status = "fail",
                Message = "Shopping cart not found"
            };
        }

        // Calculate the total price
        double totalPrice = 0;
        foreach (ShoppingCartItem item in cart.ShoppingItems)
        {
            totalPrice += item.Quantity * item.Price;
        }

        // Calculate the GST
        double gstAmount = totalPrice * gst / 100;

        // Calculate the discount
        double discountAmount = totalPrice * discount / 100;

        // Create the order
        Order order = new Order()
        {
            OrderDate = DateTime.Now,
            Quantity = cart.TotalItems,
            TotalPrice = cart.TotalPrice,
            Status = "Unprocessed",
            UserId = cart.UserId,
            ShoppingCartId = cart.CartId,
            InvoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
            ClientMessage = cart.PaymentMethod == "onaccount" ? "ON ACCOUNT" : "PREPAYMENT",
            AdminMessage = "",
            Balance = 0
        };

        // Add the order to the repository
        await _orderRepository.Add(order);

        // Get the order ID
        int orderId = order.OrderId;

        // Generate the invoice
        Invoice invoice = InvoiceGenerator.GenerateInvoice(orderId, gst, priceExclGst, discount);

        // Add the invoice to the repository
        await _invoiceRepository.Add(invoice);

        // Mark the cart as processed
        cart.Processed = true;

        // Save the cart
        await _shoppingCartRepository.SaveChangesAsync();

        // Return success
        return new ApiResponse
        {
            Status = "success",
            Message = "Order placed successfully"
        };
    }
    catch (Exception ex)
    {
        // Return error
        return new ApiResponse
        {
            Status = "fail",
            Message = ex.Message
        };
    }
}
*/