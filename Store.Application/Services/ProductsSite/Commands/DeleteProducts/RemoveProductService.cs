using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.DeleteProducts
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDatabaseContext _context;
        public RemoveProductService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string idProduct)
        {
            try
            {
                var deleteProduct = await _context.Products.FindAsync(idProduct);
                if (deleteProduct == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = MessageInUser.MessageInvalidOperation
                    };
                }
                //Item Tags
                var Tags = await _context.ItemTags.Where(t => t.ProductsId == idProduct).ToListAsync();
                if (Tags.Any())
                {
                    _context.ItemTags.RemoveRange(Tags);
                    await _context.SaveChangesAsync();
                }
                //Featuer
                var Featuer = await _context.Features.Where(f => f.ProductsId == idProduct).ToListAsync();
                if (Featuer.Any())
                {
                    _context.Features.RemoveRange(Featuer);
                    await _context.SaveChangesAsync();
                }
                //Media
                var Media = await _context.Medias.Where(f => f.ProductsId == idProduct).ToListAsync();
                if (Media.Any())
                {
                    _context.Medias.RemoveRange(Media);
                    await _context.SaveChangesAsync();
                }
                //Comments
                var Comments = await _context.Comments.Where(f => f.ProductsId == idProduct).ToListAsync();
                if (Comments.Any())
                {
                    _context.Comments.RemoveRange(Comments);
                    await _context.SaveChangesAsync();
                }
                //Rate
                var Rate = await _context.Rates.Where(f => f.ProductsId == idProduct).ToListAsync();
                if (Rate.Any())
                {
                    _context.Rates.RemoveRange(Rate);
                    await _context.SaveChangesAsync();
                }
                //Remove Logical
                deleteProduct.RemoveTime = DateTime.Now;
                deleteProduct.IsRemoved = true;
                await _context.SaveChangesAsync();
                //Show Result
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.RemoveProduct
                };
            }
            catch (Exception)
            {
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageInvalidOperation
                };

            }

        }
    }
}
