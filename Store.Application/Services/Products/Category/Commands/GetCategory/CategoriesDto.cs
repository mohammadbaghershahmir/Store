using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Category.Commands.GetCategory
{
    public class CategoriesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool HasChild  { get; set; }
        public ParentCategoryDto  Parent { get; set; }
    }
}
