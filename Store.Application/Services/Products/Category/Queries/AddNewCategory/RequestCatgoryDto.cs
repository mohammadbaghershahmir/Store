using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Category.Queries.AddNewCategory
{
    public class RequestCatgoryDto
    {
        public string? ParentId { get; set;}
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? CssClass { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public int? Sort { get; set; }
        public bool IsActive { get; set; }
    }
}
