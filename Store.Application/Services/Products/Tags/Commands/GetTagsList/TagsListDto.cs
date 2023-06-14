using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Tags.Commands.GetTagsList
{
	public class TagsListDto
	{
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
