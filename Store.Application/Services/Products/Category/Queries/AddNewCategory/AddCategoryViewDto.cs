using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Store.Application.Services.Products.Category.Queries.AddNewCategory
{
    public class AddCategoryViewDto
    {
        public string?  ParentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public string?  Description { get; set; }
        [Required]
        [MaxLength(10)]
        public string? Slug { get; set; }
        public string? Icon { get; set; }
        public string? CssClass { get; set; }
        public int Sort { get; set; } = 0;
        public bool IsActive { get; set; }
    }
}
