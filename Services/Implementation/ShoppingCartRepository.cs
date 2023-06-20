/*using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.DbContext;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ShoppingCartRepository: IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;
       // private readonly IUserService _userService;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<ShoppingItem> _shoppingItemRepository;
       // private readonly IRepository<User> _userRepository;
        private UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingCartRepository(
            ApplicationDbContext context,
            UserManager<User> userManager,
            IRepository<ShoppingCart> shoppingCartRepository,
            IRepository<ShoppingItem> shoppingItemRepository)
        {
            _context = context;
            _userManager = userManager;
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingItemRepository = shoppingItemRepository;
        }

        public async Task<ApiResponse> AddShoppingCart(string userId)
        {
            try
            {
                var shoppingCart = await _shoppingCartRepository.Queryable.Where(sc => sc.UserId == userId && sc.Status == "0").FirstOrDefaultAsync();
                if (shoppingCart == null)
                {
                    ShoppingCart sc = new ShoppingCart()
                    {
                        TotalItems = 0,
                        OriginalPrice = 0,
                        TotalPrice = 0,
                        UserId = userId,
                        Note = "",
                        Status = "0",
                        PaymentMethod = "onaccount"
                    };

                    _shoppingCartRepository.Add(sc);
                    await _shoppingCartRepository.SaveAsync();//.SaveChangesAsync();
                    return new ApiResponse()
                    {
                        Status = "success",
                        Message = "Successfully add shopping cart"
                    };
                }
                else
                {
                    return new ApiResponse()
                    {
                        Status = "fail",
                        Message = "Shopping cart already exists"
                    };
                }
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

        public async Task<ShoppingCart> GetCart(string userId)
        {
            var shoppingCart = await _shoppingCartRepository.Queryable
                .Where(s => s.UserId == userId && s.Status == "0")
                .FirstOrDefaultAsync();
            return shoppingCart;
        }

        public async Task<ShoppingCart> GetShoppingCartByID(int shoppingCartId, string userId)
        {
            var shoppingCart = _context.ShoppingCarts.Where(s => s.CartId == shoppingCartId)
                               .GroupJoin(_context.ShoppingItems, sc => sc.CartId, si => si.ShoppingCartId, (shoppingCartModel, shoppingItems) => new { ShoppingCart = shoppingCartModel, ShoppingItems = shoppingItems })
                               .Select(join => new ShoppingCart()
                               {
                                   CartId = join.ShoppingCart.CartId,
                                   TotalItems = join.ShoppingCart.TotalItems,
                                   TotalPrice = join.ShoppingCart.TotalPrice,
                                   ShoppingItems = join.ShoppingItems.ToList(),
                                   OriginalPrice = join.ShoppingCart.OriginalPrice,
                                   UserId = userId,
                                   Status = join.ShoppingCart.Status,
                                   PaymentMethod = join.ShoppingCart.PaymentMethod
                               }).FirstOrDefault();

            if (shoppingCart.TotalItems > 0)
            {
                shoppingCart.ShoppingItems = shoppingCart.ShoppingItems
                            .Join(_context.Products, si => si.ProductId, p => p.ProductId, (shoppingItem, product) => new { ShoppingItem = shoppingItem, Product = product })
                            .Select(join => new ShoppingItem
                            {
                                ItemId = join.ShoppingItem.ItemId,
                                Amount = join.ShoppingItem.Amount,
                                Product = join.Product,
                                ProductId = join.Product.ProductId,
                                Status = join.ShoppingItem.Status,
                                Packaging = join.ShoppingItem.Packaging
                            }).ToList();
            }

            return shoppingCart;
        }

        public async Task<ShoppingCart> GetCartWithShoppingItems(string userId)
        {
            var shoppingCart = _context.ShoppingCarts.Where(sc => sc.UserId == userId && sc.Status == "0")
                                .GroupJoin(_context.ShoppingItems, sc => sc.CartId, si => si.ShoppingCartId, (shoppingCartModel, shoppingItems) => new { ShoppingCart = shoppingCartModel, ShoppingItems = shoppingItems })
                                .Select(join => new ShoppingCart()
                                {
                                    CartId = join.ShoppingCart.CartId,
                                    TotalItems = join.ShoppingCart.TotalItems,
                                    TotalPrice = join.ShoppingCart.TotalPrice,
                                    ShoppingItems = join.ShoppingItems.ToList(),
                                    OriginalPrice = join.ShoppingCart.OriginalPrice,
                                    UserId = userId,
                                    Status = join.ShoppingCart.Status,
                                    PaymentMethod = join.ShoppingCart.PaymentMethod
                                }).FirstOrDefault();


            if (shoppingCart.TotalItems > 0)
            {
                shoppingCart.ShoppingItems = shoppingCart.ShoppingItems
                            .Join(_context.Products, si => si.ProductId, p => p.ProductId, (shoppingItem, product) => new { ShoppingItem = shoppingItem, Product = product })
                            .Select(join => new ShoppingItem
                            {
                                ItemId = join.ShoppingItem.ItemId,
                                Amount = join.ShoppingItem.Amount,
                                Product = join.Product,
                                ProductId = join.Product.ProductId,
                                Status = join.ShoppingItem.Status,
                                Packaging = join.ShoppingItem.Packaging
                            }).ToList();
            }


            return shoppingCart;
        }

        public async Task<ShoppingCart> GetCartInIdWithShoppingItems(int shoppingCartId)
        {
            var shoppingCart = _context.ShoppingCarts.Where(sc => sc.CartId == shoppingCartId)
                                .GroupJoin(_context.ShoppingItems, sc => sc.CartId, si => si.ShoppingCartId, (shoppingCartModel, shoppingItems) => new { ShoppingCart = shoppingCartModel, ShoppingItems = shoppingItems })
                                .Select(join => new ShoppingCart()
                                {
                                    CartId = join.ShoppingCart.CartId,
                                    TotalItems = join.ShoppingCart.TotalItems,
                                    TotalPrice = join.ShoppingCart.TotalPrice,
                                    ShoppingItems = join.ShoppingItems.ToList(),
                                    OriginalPrice = join.ShoppingCart.OriginalPrice,
                                    UserId = join.ShoppingCart.UserId,
                                    Status = join.ShoppingCart.Status,
                                    PaymentMethod = join.ShoppingCart.PaymentMethod
                                }).FirstOrDefault();


            if (shoppingCart.TotalItems > 0)
            {
                shoppingCart.ShoppingItems = shoppingCart.ShoppingItems
                            .Join(_context.Products, si => si.ProductId, p => p.ProductId, (shoppingItem, product) => new { ShoppingItem = shoppingItem, Product = product })
                            .Select(join => new ShoppingItem
                            {
                                ItemId = join.ShoppingItem.ItemId,
                                Amount = join.ShoppingItem.Amount,
                                Product = join.Product,
                                ProductId = join.Product.ProductId,
                                Status = join.ShoppingItem.Status,
                                Packaging = join.ShoppingItem.Packaging
                            }).ToList();
            }


            return shoppingCart;
        }

        public async Task<ApiResponse> UpdateShoppingCartPaymentMethod(string userId, string selectedPayment)
        {
            try
            {
                var shoppingCart = await GetCart(userId);
                if (!string.IsNullOrEmpty(selectedPayment))
                {
                    shoppingCart.PaymentMethod = selectedPayment;
                }
                _shoppingCartRepository.Update(shoppingCart);
                await _shoppingCartRepository.SaveAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully Update Shopping Cart Payment Method"
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

        public async Task<ApiResponse> UpdateShoppingCart(string userId, ShoppingItem shoppingItem)
        {
            try
            {
                var shoppingCart = await GetCart(userId);

                //var user = await _userRepository.GetUserByAccount(userId);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                int shoppingItemExists = _shoppingItemRepository.Queryable.Where(si => si.ShoppingCartId == shoppingCart.CartId && si.ProductId == shoppingItem.Product.ProductId && si.Status == "0").Count();

                if (shoppingItemExists > 0)
                {
                    var shoppingItemModel = await _shoppingItemRepository.Queryable.Where(si => si.ShoppingCartId == shoppingCart.CartId && si.ProductId == shoppingItem.Product.ProductId && si.Status == "0").FirstOrDefaultAsync();
                    shoppingItemModel.Amount += shoppingItem.Amount;
                    shoppingItemModel.Packaging = shoppingItem.Packaging;
                    _shoppingItemRepository.Update(shoppingItemModel);
                    await _shoppingItemRepository.SaveAsync();
                }
                else
                {
                    ShoppingItem si = new ShoppingItem()
                    {
                        Amount = shoppingItem.Amount,
                        ProductId = shoppingItem.Product.ProductId,
                        ShoppingCartId = shoppingCart.CartId,
                        Status = "0",
                        Packaging = shoppingItem.Packaging
                    };
                    _shoppingItemRepository.Add(si);
                    await _shoppingItemRepository.SaveAsync();
                }

                shoppingCart.TotalItems += shoppingItem.Amount;
                updateShoppingCartPrice(shoppingCart, user, shoppingItem);
                _shoppingCartRepository.Update(shoppingCart);
                await _shoppingCartRepository.SaveAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully add " + shoppingItem.Product.Name + " to shopping cart"
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

        public async Task<ApiResponse> deleteShoppingItem(int shoppingItemId)
        {
            try
            {
                var shoppingItem = _shoppingItemRepository.Queryable
                                    .Where(s => s.ItemId == shoppingItemId)
                                    .FirstOrDefault();
                _shoppingItemRepository.Delete(shoppingItem);
                await _shoppingItemRepository.SaveAsync();
                return new ApiResponse()
                {
                    Status = "success"
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

        private void updateShoppingCartPrice(ShoppingCart shoppingCart, User user, ShoppingItem shoppingItem)
        {
            shoppingCart.OriginalPrice += ((shoppingItem.Amount + 0.1) * shoppingItem.Product.OriginalPrice);
            if (user.Role.ToLower() == "agent")
            {
                shoppingCart.TotalPrice += ((shoppingItem.Amount + 0.1) * shoppingItem.Product.AgentPrice);
            }
            else if (user.Role.ToLower() == "wholesaler")
            {
                shoppingCart.TotalPrice += ((shoppingItem.Amount + 0.1) * shoppingItem.Product.WholesalerPrice);
            }
        }
    }
}

*/