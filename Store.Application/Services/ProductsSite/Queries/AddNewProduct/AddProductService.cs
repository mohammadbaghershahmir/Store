using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Product;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.AddNewProduct
{
	public class AddProductService : IAddProductService
	{
		private readonly IDatabaseContext _context;
        public AddProductService(IDatabaseContext context)
        {
			_context = context;
        }
        public async Task<ResultDto> Execute(RequestAddProductDto requestAddProductDto)
		{
			try
			{
				var checkSlug = _context.Products.Where(r => r.Slug == requestAddProductDto.Slug).FirstOrDefault();
				if(checkSlug!=null)
				{
					return new ResultDto()
					{
						IsSuccess = true,
						Message = MessageInUser.ExistSlug
					};
				}
				//var SlugUnderLine = requestAddProductDto?.Slug?.Trim().Replace(" ", "_");
				Products products = new Products()
				{
					Id = Guid.NewGuid().ToString(),
					Name = requestAddProductDto.Name,
					Price = requestAddProductDto.Price,
					Quantity = requestAddProductDto.Quantity,
					LastPrice = requestAddProductDto.Price,
					PostageFee = requestAddProductDto.PostageFee,
					PostageFeeBasedQuantity =requestAddProductDto.PostageFeeBasedQuantity,
					IsActive = requestAddProductDto.IsActive,
					MinPic = requestAddProductDto.MinPic,
					Pic = requestAddProductDto.Pic,
					Content=requestAddProductDto.Content,
					Slug = requestAddProductDto.Slug,
					CategoryId = requestAddProductDto.CategoryId,
					BrandsId = requestAddProductDto.BrandId,
					UserId = "4c6ba01e-9282-434c-a7aa-c35565de1e7f",
					InsertTime = DateTime.Now,
				};
				//Add Products
				_context.Products.Add(products);
				_context.SaveChanges();
				//Find Item Tag
				List<ItemTag> itemTags = new List<ItemTag>();

				foreach (var id in requestAddProductDto.TagsId)
				{
					var Tags = _context.Tags.Find(id);
					itemTags.Add(new ItemTag
					{
						Id = Guid.NewGuid().ToString(),
						Products = products,
						ProductsId = products.Id,
						Tag = Tags,
						TagId = Tags.Id,
						InsertTime = DateTime.Now
					});
				}
				//Add Item Tag
				products.ItemTags = itemTags;
				_context.SaveChanges();
				//Add Featuer
				List<Feature> feature = new List<Feature>();

				foreach (var item in requestAddProductDto.FeatureList)
				{
					feature.Add(new Feature
					{
						Id = Guid.NewGuid().ToString(),
						ProductsId=products.Id,
						DisplayName=item.Title,
						Value=item.Value,
						InsertTime=DateTime.Now
					});
				}
				products.Features = feature;
				_context.SaveChanges();
				return new ResultDto(){ 
					IsSuccess = true,
					Message=MessageInUser.InsertProduct
				};
			}
			catch (Exception)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.MessageInvalidOperation
				};
			}
        }
		public class TagsDto
		{

            public string IdTag { get; set; }
            public string UserId { get; set; }
        }
	}
}
