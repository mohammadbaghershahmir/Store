using Store.Application.Interfaces.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Tags.Commands.GetTagsList
{
	public class GetTagsListService : IGetTagsListService
	{
		private readonly IDatabaseContext _context;
        public GetTagsListService(IDatabaseContext context)
        {
			_context = context;
        }
        public async Task<List<TagsListDto>> Execute()
		{
			var Tags = _context.Tags.Select(t => new TagsListDto
			{
				Id=t.Id,
				Name=t.Name,
				InsertTime=t.InsertTime
			}).ToList().OrderByDescending(r=>r.InsertTime).ToList();
			return Tags;
		}
	}
}
