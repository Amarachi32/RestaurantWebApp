using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.DbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ShoopingCartService : IShoppingCartService
    {
       // private readonly ApplicationDbContext _appDbContext;
        private readonly IRepository<ShoppingItem> _shoppingItemRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public ShoopingCartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _shoppingCartRepository = unitOfWork.GetRepository<ShoppingCart>();
        }
        public async Task<ApiResponse> AddShoppingCart(string userId)
        {
            try
            {
                var shoppingCart = await _shoppingCartRepository.Queryable.Where(sc => sc.UserId.Equals(userId) && sc.Status == "0").FirstOrDefaultAsync();
                    
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
                  //  await _shoppingCartRepository.SaveChangesAsync();
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
                .Where(s => s.UserId.Equals(userId) && s.Status == "0").FirstOrDefaultAsync();
               // .GetFirstOrDefaultAsync();
            return shoppingCart;
        }

/*        public async Task<ShoppingCart> GetShoppingCartByID(int shoppingCartId, string userId)
        {
            var shoppingCart = _appDbContext.ShoppingCarts.Where(s => s.CartId == shoppingCartId)
                               .GroupJoin(_appDbContext.ShoppingItems, sc => sc.CartId, si => si.ShoppingCartId, (shoppingCartModel, shoppingItems) => new { ShoppingCart = shoppingCartModel, ShoppingItems = shoppingItems })
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
                            .Join(_appDbContext.Products, si => si.ProductId, p => p.ProductId, (shoppingItem, product) => new { ShoppingItem = shoppingItem, Product = product })
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
       */
        public async Task<ShoppingCart> GetShoppingCartByID(int shoppingCartId, string userId)
        {
            var shoppingCart = await _shoppingCartRepository.Queryable
                .Where(s => s.CartId == shoppingCartId).FirstOrDefaultAsync();

            if (shoppingCart != null)
            {
                var shoppingItems = await _shoppingItemRepository.Queryable
                    .Where(si => si.ShoppingCartId == shoppingCartId).ToListAsync();

                shoppingCart.ShoppingItems = shoppingItems;
            }

            return shoppingCart;
        }
        /*        public async Task<ShoppingCart> GetCartWithShoppingItems(string userId)
                {
                    var shoppingCart = _appDbContext.ShoppingCarts.Where(sc => sc.UserId == userId && sc.Status == "0")
                                        .GroupJoin(_appDbContext.ShoppingItems, sc => sc.CartId, si => si.ShoppingCartId, (shoppingCartModel, shoppingItems) => new { ShoppingCart = shoppingCartModel, ShoppingItems = shoppingItems })
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
                                    .Join(_appDbContext.Products, si => si.ProductId, p => p.ProductId, (shoppingItem, product) => new { ShoppingItem = shoppingItem, Product = product })
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
                }*/
        public async Task<ShoppingCart> GetCartWithShoppingItems(string userId)
        {
            var shoppingCart = await _shoppingCartRepository.Queryable
                .Where(sc => sc.UserId == userId && sc.Status == "0").FirstOrDefaultAsync();

            if (shoppingCart != null)
            {
                var shoppingItems = await _shoppingItemRepository.Queryable
                    .Where(si => si.ShoppingCartId == shoppingCart.CartId).ToListAsync();

                shoppingCart.ShoppingItems = shoppingItems;
            }

            return shoppingCart;
        }
        /*        public async Task<ShoppingCart> GetCartInIdWithShoppingItems(int shoppingCartId)
                {
                    var shoppingCart = _appDbContext.ShoppingCarts.Where(sc => sc.CartId == shoppingCartId)
                                        .GroupJoin(_appDbContext.ShoppingItems, sc => sc.CartId, si => si.ShoppingCartId, (shoppingCartModel, shoppingItems) => new { ShoppingCart = shoppingCartModel, ShoppingItems = shoppingItems })
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
                                    .Join(_appDbContext.Products, si => si.ProductId, p => p.ProductId, (shoppingItem, product) => new { ShoppingItem = shoppingItem, Product = product })
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
              */
        public async Task<ShoppingCart> GetCartInIdWithShoppingItems(int shoppingCartId)
        {
            var shoppingCart = await _shoppingCartRepository.Queryable
                .Where(sc => sc.CartId == shoppingCartId).FirstOrDefaultAsync();

            if (shoppingCart != null)
            {
                var shoppingItems = await _shoppingItemRepository.Queryable
                    .Where(si => si.ShoppingCartId == shoppingCartId).ToListAsync();

                shoppingCart.ShoppingItems = shoppingItems;
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
               // await _shoppingCartRepository.SaveChangesAsync();
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

                var user = await _userService.GetUserByIdAsync(userId);
                int shoppingItemExists = _shoppingItemRepository.Queryable.Where(si => si.ShoppingCartId == shoppingCart.CartId && si.ProductId == shoppingItem.Product.ProductId && si.Status == "0").Count();

                if (shoppingItemExists > 0)
                {
                    var shoppingItemModel = await _shoppingItemRepository.Queryable.Where(si => si.ShoppingCartId == shoppingCart.CartId && si.ProductId == shoppingItem.Product.ProductId && si.Status == "0").FirstOrDefaultAsync();
                    shoppingItemModel.Amount += shoppingItem.Amount;
                    shoppingItemModel.Packaging = shoppingItem.Packaging;
                    _shoppingItemRepository.Update(shoppingItemModel);
                   // await _shoppingItemRepository.SaveChangesAsync();
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
                  //  await _shoppingItemRepository.SaveChangesAsync();
                }

                shoppingCart.TotalItems += shoppingItem.Amount;
                updateShoppingCartPrice(shoppingCart, user, shoppingItem);
                _shoppingCartRepository.Update(shoppingCart);
               // await _shoppingCartRepository.SaveChangesAsync();
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
                //await _shoppingItemRepository.SaveChangesAsync();
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

