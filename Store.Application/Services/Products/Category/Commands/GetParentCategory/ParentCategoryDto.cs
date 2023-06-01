using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Category.Commands.GetParentCategory
{
    public class ParentCategoryDto
    {
        public string? Id   { get; set; }
        public  string? Name { get; set; }
        public string? ParentId { get; set; }
        public string? ParentName { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
