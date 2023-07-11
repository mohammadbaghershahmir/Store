using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetBrandsList
{
    public class BrandsListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public string? Pic { get; set; }
        public string? Url { get; set; }
        public string? CssClass { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
