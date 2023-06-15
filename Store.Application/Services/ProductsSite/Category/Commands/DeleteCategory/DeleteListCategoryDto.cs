using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Category.Commands.DeleteCategory
{
    public class DeleteListCategoryDto
    {
        public bool IsRemove { get; set; }
        public DateTime? RemoveTime { get; set; }
        public string? Id { get; set; }
        public string? ParentId { get; set; }
    }
}
