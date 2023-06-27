using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.NoImage;
using Store.Common.Constant.Settings;
using Store.Common.Dto;
using Store.Domain.Entities.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Carts
{
    public interface ICartService
    {
        Task<ResultDto> AddToCard(string ProductId, Guid BrowserId);
        Task<ResultDto> RemoveFromCard(string ProductId, Guid BrowserId);
        Task<ResultDto<CartDto>> GetMyCart(Guid BrowserId,string? UserId, bool? Forpay = false);
        Task<ResultDto> AddCount(Guid Id);
        Task<ResultDto> MinCount(Guid Id);
        Task<ResultDto> Remove(Guid Id);
    }
    public class CartService : ICartService
    {
        private readonly IDatabaseContext _context;
        public CartService(IDatabaseContext context)
        {
            _context= context;
        }

        public async Task<ResultDto> AddCount(Guid Id)
        {
            var result = await _context.CartItems.FindAsync(Id);
            if (result == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };

            }

            result.Count++;
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageAddCartItem
            };
        }

        public async Task<ResultDto> AddToCard(string ProductId, Guid BrowserId)
        {
            var card =await _context.Carts.Where(c => c.BrowserId == BrowserId && !c.Finished).FirstOrDefaultAsync();
            if(card == null)
            {
                Cart newCart = new Cart()
                {
                    Finished=false,
                    BrowserId= BrowserId,
                };
                _context.Carts.Add(newCart);
               await _context.SaveChangesAsync();
                card = newCart;
            }
            var product = _context.Products.Find(ProductId);
            var cardItem =await _context.CartItems.Where(p => p.ProductId == ProductId && p.CartId == card.Id).FirstOrDefaultAsync();
            if(cardItem != null)
            {
                cardItem.Count++;
            }
            else
            {
                CartItem cartItem = new CartItem()
                {
                    Cart = card,
                    Count = 1,
                    Price = product.Price,
                    Product = product,
                };
                _context.CartItems.Add(cardItem);
               await _context.SaveChangesAsync();
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message=$"محصول{product.Name} با موفقیت به سبد خرید اضافه شد"

            };
        }

        public async Task<ResultDto<CartDto>> GetMyCart(Guid BrowserId, string? UserId, bool? Forpay = false)
        {
            var cart = await _context.Carts
               .Include(p => p.CartItems)
               .ThenInclude(p => p.Product)
               .Where(p => p.BrowserId == BrowserId && p.Finished == false)
               .OrderByDescending(p => p.Id)
               .FirstOrDefaultAsync();

            if (UserId != null && cart != null && Forpay == false)
            {
                var user = await _context.Users.FindAsync(UserId);
                cart.User = user;
                await _context.SaveChangesAsync();
            }
            if (cart != null)
            {
                return new ResultDto<CartDto>()
                {
                    Data = new CartDto()
                    {
                        ProductCount = cart.CartItems.Count(),
                        SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                        CartId = cart.Id,
                        CartItems = cart.CartItems.Select(p => new CartItemDto
                        {
                            Id = p.Id,
                            ProductId = p.ProductId,
                            Count = p.Count,
                            Price = p.Price = p.Product.Price,
                            ProductName = p.Product.Name,
                            ImageSrc = string.IsNullOrEmpty(p.Product.MinPic) ? ImageProductConst.NoImage : ImageProductConst.FtpUrl + p.Product.MinPic,
                        }).ToList(),
                    },
                    IsSuccess = true,
                };
            }
            else
            {
                return new ResultDto<CartDto>()
                {
                    Data = new CartDto()
                    {
                        ProductCount = 0,
                        SumAmount = 0,
                    },
                    IsSuccess = false,
                };
            }
        }

        public async Task<ResultDto> MinCount(Guid Id)
        {
            var result = await _context.CartItems.FindAsync(Id);
            if (result.Count <= 1)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageInvalidCart
                };
            }
            if (result == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFoundCart
                };

            }

            result.Count--;
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageDecreasedCart
            };
        }

        public async Task<ResultDto> Remove(Guid Id)
        {
            var result = await _context.CartItems.FindAsync(Id);
            if (result == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFoundCart
                };
            }
            result.IsRemoved = true;
            result.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.RemoveCard
            };
        }

        public async Task<ResultDto> RemoveFromCard(string ProductId, Guid BrowserId)
        {
            var cartitem = await _context.CartItems.Where(p => p.Cart.BrowserId == BrowserId).FirstOrDefaultAsync();
            if (cartitem != null)
            {
                cartitem.IsRemoved = true;
                cartitem.RemoveTime = DateTime.Now;
               await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.RemoveCard
                };
            }
            else
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message =MessageInUser.RemoveInvalidCard
                };
            }
        }
    }
    public class CartDto
    {
        public string CartId { get; set; }
        public int ProductCount { get; set; }
        public double SumAmount { get; set; }
        public List<CartItemDto>  CartItems {  get; set; }
    }
    public class CartItemDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageSrc { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
