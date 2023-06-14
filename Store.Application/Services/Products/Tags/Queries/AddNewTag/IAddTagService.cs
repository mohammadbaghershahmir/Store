using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Tags.Queries.AddNewTag
{
	public interface IAddTagService
	{
		Task<ResultDto> Execute(string name);
	}
}
