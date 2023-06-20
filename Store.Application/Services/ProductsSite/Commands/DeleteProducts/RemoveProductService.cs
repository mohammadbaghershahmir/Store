using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
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
            var deleteProduct = await _context.Products.FindAsync(idProduct);
            if (deleteProduct==null)
            {
                return new ResultDto() {
                IsSuccess=false,
                Message=MessageInUser.MessageInvalidOperation
                };
            }
           else
            {
                //Remove Logical
                deleteProduct.RemoveTime= DateTime.Now;
                deleteProduct.IsRemoved = true;
             await _context.SaveChangesAsync();
                //Show Result
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.RemoveProduct
                };
            }
        }
    }
}
