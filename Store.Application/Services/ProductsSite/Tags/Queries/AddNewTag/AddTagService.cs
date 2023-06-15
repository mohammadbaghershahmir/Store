using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Tags.Queries.AddNewTag
{
	public class AddTagService : IAddTagService
	{
		private readonly IDatabaseContext _context;
        public AddTagService(IDatabaseContext context)
        {
			_context = context;
        }
        public async Task<ResultDto> Execute(string name)
		{
			var cheackTag= _context.Tags.Where(n=>n.Name==name).FirstOrDefault();
			if(cheackTag!=null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message=MessageInUser.ExistTag
				};
			}
           Tag tag = new Tag()
		   {

			   Id= Guid.NewGuid().ToString(),
			   Name=name,
			   InsertTime= DateTime.Now,
		   };
			_context.Tags.Add(tag);
			await _context.SaveChangesAsync();
			return new ResultDto()
			{
				IsSuccess=true,
				Message="موفق"
			};	
		}
	}
}
