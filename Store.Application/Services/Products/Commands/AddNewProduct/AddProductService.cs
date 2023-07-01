using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.FileTypeManager;
using Store.Common.Dto;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.AddNewProduct
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
                if (checkSlug != null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = true,
                        Message = MessageInUser.ExistSlug
                    };
                }
                long ticks = DateTime.Now.Ticks;
                Random random = new Random((int)(ticks & 0xffffffffL) | (int)(ticks >> 32));
                int codeProduct = random.Next(1000, 10000);
                //var SlugUnderLine = requestAddProductDto?.Slug?.Trim().Replace(" ", "_");
                Product products = new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = requestAddProductDto.Name,
                    Price = requestAddProductDto.Price,
                    Quantity = requestAddProductDto.Quantity,
                    CodeProduct=codeProduct,
                    LastPrice = requestAddProductDto.Price,
                    PostageFee = requestAddProductDto.PostageFee,
                    PostageFeeBasedQuantity = requestAddProductDto.PostageFeeBasedQuantity,
                    IsActive = requestAddProductDto.IsActive,
                    MinPic = requestAddProductDto.MinPic,
                    Pic = requestAddProductDto.Pic,
                    Content = requestAddProductDto.Content,
                    Description=requestAddProductDto.Description,
                    Slug = requestAddProductDto.Slug,
                    CategoryId = requestAddProductDto.CategoryId,
                    BrandId = requestAddProductDto.BrandId,
                    UserId = "1acf9c4e-4ae6-4b6c-9461-bd7f1dc04954",
                    InsertTime = DateTime.Now,
                };
                //Add Products
                _context.Products.Add(products);
                _context.SaveChanges();
                //Find Item Tag
                if (requestAddProductDto.TagsId != null)
                {
                    List<ItemTag> itemTags = new List<ItemTag>();

                    foreach (var id in requestAddProductDto.TagsId)
                    {
                        var Tags = _context.Tags.Find(id);
                        itemTags.Add(new ItemTag
                        {
                            Id = Guid.NewGuid().ToString(),
                            Product = products,
                            ProductId = products.Id,
                            Tag = Tags,
                            TagId = Tags.Id,
                            InsertTime = DateTime.Now
                        });
                    }
                    //Add Item Tag
                    products.ItemTags = itemTags;
                    _context.SaveChanges();
                }
                //Add Featuer
                if (requestAddProductDto.FeatureList != null)
                {
                    List<Feature> feature = new List<Feature>();
                    foreach (var featureItem in requestAddProductDto.FeatureList)
                    {
                        feature.Add(new Feature
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProductId = products.Id,
                            DisplayName = featureItem.Title,
                            Value = featureItem.Value,
                            InsertTime = DateTime.Now
                        });
                    }
                    products.Features = feature;
                    _context.SaveChanges();
                }
                //Add ImagesList
                if (requestAddProductDto.UrlImagList != null)
                {
                    List<Media> media = new List<Media>();
                    foreach (var itemImageItem in requestAddProductDto.UrlImagList)
                    {
                        media.Add(new Media
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProductId = products.Id,
                            Src = itemImageItem,
                            MediaType = FileTypeEnum.Image,
                            InsertTime = DateTime.Now
                        });
                    }
                    products.Medias = media;
                    _context.SaveChanges();
                }
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.InsertProduct
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
