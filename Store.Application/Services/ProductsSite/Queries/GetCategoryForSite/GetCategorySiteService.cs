using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;

namespace Store.Application.Services.ProductsSite.Queries.GetCategoryForSite
{
    public class GetCategorySiteService : IGetCategorySiteService
    {
        private readonly IDatabaseContext _context;
        public GetCategorySiteService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<CategorySiteDto>> Execute()
        {
            var ParentListQuery = _context.Category.Include(s => s.SubCategories).Where(r => r.ParentCategoryId == null).AsQueryable();
            var ParentList = ParentListQuery.Select(
                e => new CategorySiteDto
                {
                    Name = e.Name,
                    Id = e.Id,
                    Child=e.SubCategories.ToList().Select(w=>new SubCategorySitDto{NameChild=w.Name,ParenId=w.ParentCategoryId }).ToList()
                }
                );
            return ParentList.ToList();
        }
    }
}
