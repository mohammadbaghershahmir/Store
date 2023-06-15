using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Store.Application.Services.ProductsSite.Queries.AddNewProduct
{
    public class AddNewProductView
    {
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string BrandId { get; set; }
        public string? UserId { get; set; }
        public string? Content { get; set; }
        [Required]
		[Range(0, double.MaxValue)]
		public double Price { get; set; }
        public double LastPrice { get; set; }
        [Required]
		[Range(0, double.MaxValue)]
		public long Quantity { get; set; }
        [Required]
		[Range(0, double.MaxValue)]
		public double PostageFee { get; set; }
		[Required]
		[Range(0, double.MaxValue)]
		public double PostageFeeBasedQuantity { get; set; }
        public string? Slug { get; set; }
        public bool IsActive { get; set; }
        public string Pic { get; set; }
        public string? MinPic { get; set; }
        public string[]?   TagsId { get; set; }
		public List<FeatureListDto>? FeatureList { get; set; }
	}
}
