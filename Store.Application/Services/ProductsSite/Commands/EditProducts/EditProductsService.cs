using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.ProductsSite.Queries.GetEditProductsList;
using Store.Common.Constant;
using Store.Common.Constant.FileTypeManager;
using Store.Common.Dto;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.EditProducts
{
	public class EditProductsService : IEditProductsService
	{
		private readonly IDatabaseContext _context;
        public EditProductsService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(EditProductListDto editProductListDto)
		{
			try
			{
				var product = await _context.Products.FindAsync(editProductListDto.Id);
				if (product == null)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = MessageInUser.IsValidForm
					};
				}
                var brand = await _context.Brands.FindAsync(editProductListDto.BrandId);
                var category = await _context.Category.FindAsync(editProductListDto.CategoryId);
				var user = await _context.Users.FindAsync(editProductListDto.UserId);
				var slug = await _context.Products.Where(s => s.Slug == editProductListDto.Slug && s.Slug != product.Slug).ToListAsync();
                if (category == null) { return new ResultDto { IsSuccess = false, Message = "لطفا دسته بندی خود را انتخاب کنید!" }; }
				if (user == null) { return new ResultDto { IsSuccess = false, Message = "کاربری جهت ویرایش وجود ندارد!" }; }
				if (slug.Any()) { return new ResultDto { IsSuccess = false, Message = "آدرس سِو خود را تغییر دهید!" }; }
                //Edit List Products
                product.Name = editProductListDto.Name;
				product.Content = editProductListDto.Content;
				product.Description = editProductListDto.Description;
				product.IsActive = editProductListDto.IsActive;
                if (product.Price != editProductListDto.Price)
                {
                    product.LastPrice = product.Price;
                    product.Price = editProductListDto.Price;
                }
				product.Quantity = editProductListDto.Quantity;
				product.Slug = editProductListDto.Slug;
				product.MinPic = editProductListDto.MinPic;
				product.Pic = editProductListDto.Pic;
				product.PostageFee = editProductListDto.PostageFee;
				product.PostageFeeBasedQuantity = editProductListDto.PostageFeeBasedQuantity;
				product.UpdateTime = DateTime.Now;
				await _context.SaveChangesAsync();
				//Remove List ItemTag
				var listItemTagsRemove = _context.ItemTags.Where(r => r.ProductsId == editProductListDto.Id).ToList();
				_context.ItemTags.RemoveRange(listItemTagsRemove);
				await _context.SaveChangesAsync();
				//Edit Item Tag
				if (editProductListDto.TagsId != null)
				{
					List<ItemTag> itemTags = new List<ItemTag>();

					foreach (var id in editProductListDto.TagsId)
					{
						var Tags = await _context.Tags.FindAsync(id);
						itemTags.Add(new ItemTag
						{
							Id = Guid.NewGuid().ToString(),
							Products = product,
							ProductsId = product.Id,
							Tag = Tags,
							TagId = Tags.Id,
							InsertTime = DateTime.Now,
							UpdateTime = DateTime.Now
						});
					}
					//Edit Item Tag
					product.ItemTags = itemTags;
					await _context.SaveChangesAsync();
				}
				//Remove Feature List
				var FeatuerListRemove = _context.Features.Where(f => f.ProductsId == editProductListDto.Id).ToList();
				_context.Features.RemoveRange(FeatuerListRemove);
				await _context.SaveChangesAsync();
				//Edit Featuer
				if (editProductListDto.FeatureList != null)
				{
					List<Feature> feature = new List<Feature>();
					foreach (var featureItem in editProductListDto.FeatureList)
					{
						feature.Add(new Feature
						{
							Id = Guid.NewGuid().ToString(),
							ProductsId = product.Id,
							DisplayName = featureItem.Title,
							Value = featureItem.Value,
							InsertTime = DateTime.Now,
							UpdateTime = DateTime.Now
						});
					}
					product.Features = feature;
					await _context.SaveChangesAsync();
				}
				//Remove Image List
				var ImageListRemove = _context.Medias.Where(m => m.ProductsId == editProductListDto.Id).ToList();
				_context.Medias.RemoveRange(ImageListRemove);
				await _context.SaveChangesAsync();
				//Add ImagesList
				if (editProductListDto.UrlImagList != null)
				{
					List<Media> media = new List<Media>();
					foreach (var itemImageItem in editProductListDto.UrlImagList)
					{
						media.Add(new Media
						{
							Id = Guid.NewGuid().ToString(),
							ProductsId = product.Id,
							Src = itemImageItem,
							MediaType = FileTypeEnum.Image,
							InsertTime = DateTime.Now,
							UpdateTime = DateTime.Now
						});
					}
					product.Medias = media;
					await _context.SaveChangesAsync();
				}
				return new ResultDto()
				{
					IsSuccess = true,
					Message = MessageInUser.MessageUpdateProduct
				};
			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}
