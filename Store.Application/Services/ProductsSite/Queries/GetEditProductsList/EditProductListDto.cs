using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetEditProductsList
{
    public class EditProductListDto
    {
        [Required]
        public string Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string CategoryId { get; set; }
        public string? BrandId { get; set; }
		public string? UserId { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        [Required]
		public double Price { get; set; }
        public double LastPrice { get; set; }
		[Required]
		public long Quantity { get; set; }
		[Required]
		public double PostageFee { get; set; }
		[Required]
		public double PostageFeeBasedQuantity { get; set; }
        public string? Slug { get; set; }
		public bool IsActive { get; set; }
        public string? Pic { get; set; }
        public string? NameTag { get; set; }
        public string? MinPic { get; set; }
        public string[]? TagsId { get; set; }
        public string[]? UrlImagList { get; set; }
        public string? BaseUrl { get; set; }
        public List<FeatureListDto>? FeatureList { get; set; }
    }
    public class FeatureListDto
    {
        public string? Title { get; set; }
        public string? Value { get; set; }
    }
}
