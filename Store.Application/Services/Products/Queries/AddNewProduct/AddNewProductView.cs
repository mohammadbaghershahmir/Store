using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Queries.AddNewProduct
{
    public class AddNewProductView
    {
        public string Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string BrandId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        [Required]
        public double? Price { get; set; }
        public double LastPrice { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public double? PostageFee { get; set; }
		[Required]
		public double? PostageFeeBasedQuantity { get; set; }
        public string? Slug { get; set; }
        public bool IsActive { get; set; }
        public string Pic { get; set; }
        [Required]
        public string? NameTag { get; set; }
        public string? MinPic { get; set; }
        public string[]?   TagsId { get; set; }

    }
}
