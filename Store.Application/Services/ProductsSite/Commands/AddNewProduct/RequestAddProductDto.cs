using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.AddNewProduct
{
    public class RequestAddProductDto
    {
        public string? Name { get; set; }
        public string CategoryId { get; set; }
        public string? BrandId { get; set; }
        public string UserId { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double LastPrice { get; set; }
        public long Quantity { get; set; }
        public double PostageFee { get; set; }
        public double PostageFeeBasedQuantity { get; set; }
        public string? Slug { get; set; }
        public bool IsActive { get; set; }
        public string? Pic { get; set; }
        public string? NameTag { get; set; }
        public string? MinPic { get; set; }
        public string[]? TagsId { get; set; }
        public string[]? UrlImagList { get; set; }
        public List<FeatureListDto>? FeatureList { get; set; }
    }
    public class FeatureListDto
    {
        public string? Title { get; set; }
        public string? Value { get; set; }
    }
}
