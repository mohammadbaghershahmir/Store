using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Products
{
    public class Categories : BaseEntity
    {
        public virtual Categories ParentCategory { get; set; }
        public string? ParentCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? CssClass { get; set; }
        public bool IsActive { get; set; } = true;
        public int? Sort { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        //برای نمایش زیر دسته های هر گروه
        public virtual ICollection<Categories> SubCategories { get; set; }
    }
}
