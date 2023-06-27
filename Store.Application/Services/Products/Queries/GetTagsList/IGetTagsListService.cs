using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetTagsList
{
    public interface IGetTagsListService
    {
        Task<List<TagsListDto>> Execute();
    }
}
