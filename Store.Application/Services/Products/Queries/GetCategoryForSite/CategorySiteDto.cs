namespace Store.Application.Services.ProductsSite.Queries.GetCategoryForSite
{
    public class CategorySiteDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public List<SubCategorySitDto> Child { get; set; }
    }
}
