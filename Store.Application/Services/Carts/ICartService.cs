using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.NoImage;
using Store.Common.Constant.Settings;
using Store.Common.Dto;
using Store.Domain.Entities.Carts;

namespace Store.Application.Services.Carts
{
    public interface ICartService
    {
        Task<ResultDto> AddToCard(string ProductId, Guid BrowserId, int? count);
        Task<ResultDto> RemoveFromCard(string ProductId, Guid BrowserId);
        Task<ResultDto<CartDto>> GetMyCart(Guid BrowserId,string? UserId, bool? Forpay = false);
        Task<ResultDto<BacketDto>> GetBacket(Guid BrowserId, string? UserId, bool? Forpay = false);
        Task<ResultDto> AddCount(string Id);
        Task<ResultDto> MinCount(string Id);
        Task<ResultDto> Remove(string Id);
    }
    public class CartService : ICartService
    {
        private readonly IDatabaseContext _context;
        public CartService(IDatabaseContext context)
        {
            _context= context;
        }

        public async Task<ResultDto> AddCount(string Id)
        {
            var result =  _context.CartItems.Find(Id);
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

        public async Task<ResultDto> AddToCard(string ProductId, Guid BrowserId, int? count)
        {
            try
            {
                var cart =  _context.Carts
                      .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                      .FirstOrDefault();
                if (cart == null)
                {
                    Cart newCart = new Cart()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Finished = false,
                        BrowserId = BrowserId,
                        InsertTime = DateTime.Now,
                        IsRemoved = false
                    };
                    await _context.Carts.AddAsync(newCart);
                    await _context.SaveChangesAsync();
                    cart = newCart;
                }
                var product =  _context.Products.Find(ProductId);
                var cartItem =  _context.CartItems
                    .Where(p => p.ProductId == ProductId.ToString() && p.CartId == cart.Id)
                    .FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.Count++;
                }
                else
                {
                    CartItem newCartItem = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Cart = cart,
                        Count = count.HasValue ? count.Value : 1,
                        Price = product.Price,
                        Product = product,
                        InsertTime = DateTime.Now,
                    };
                    await _context.CartItems.AddAsync(newCartItem);
                }
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = $"محصول {product.Name} با موفقیت به سبد خرید اضافه شد"
                };
            }
            catch (Exception ex)
            {
                var ee = ex.Message;
                return new ResultDto() { IsSuccess = false };
            }
        }

        public async Task<ResultDto<BacketDto>> GetBacket(Guid BrowserId, string? UserId, bool? Forpay = false)
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
                return new ResultDto<BacketDto>()
                {
                    Data = new BacketDto()
                    {
                        ProductCount = cart.CartItems.Count(),
                        SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                        CartId = cart.Id,
                        Unit=Settings.UnitText
                    },
                    IsSuccess = true,
                };
            }
            else
            {
                return new ResultDto<BacketDto>()
                {
                    Data = new BacketDto()
                    {
                        ProductCount = 0,
                        SumAmount = 0,
                    },
                    IsSuccess = false,
                };
            }
        }

        public async Task<ResultDto<CartDto>> GetMyCart(Guid BrowserId, string? UserId, bool? Forpay = false)
        {
            var cart = await _context.Carts
               .Include(p => p.CartItems)
               .ThenInclude(p => p.Product).ThenInclude(b=>b.Brand)
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
                        Unit = Settings.UnitText,
                        CartItems = cart.CartItems.Select(p => new CartItemDto
                        {
                            Id = p.Id,
                            ProductId = p.ProductId,
                            ProductCode=p.Product.CodeProduct,
                            Count = p.Count,
                            Price = p.Price = p.Product.Price,
                            CountPerPrice=p.Price*p.Count,
                            ProductName = p.Product.Name,
                            BrandName=p.Product.Brand==null?"بدون برند":p.Product.Brand.Name,
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

        public async Task<ResultDto> MinCount(string Id)
        {
            var result =  _context.CartItems.Find(Id);
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

        public async Task<ResultDto> Remove(string Id)
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
    public class BacketDto
    {
        public string CartId { get; set; }
        public int ProductCount { get; set; }
        public double SumAmount { get; set; }
        public string Unit { get; set; }
    }
    public class CartDto
    {
        public string CartId { get; set; }
        public int ProductCount { get; set; }
        public double SumAmount { get; set; }
        public string Unit { get; set; }
        public List<CartItemDto>  CartItems {  get; set; }
    }
    public class CartItemDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ImageSrc { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double CountPerPrice { get; set; }
        public string BrandName { get; set; }
    }
}
