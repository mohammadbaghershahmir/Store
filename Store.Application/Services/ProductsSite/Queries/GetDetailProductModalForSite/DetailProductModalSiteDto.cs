using Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite;
using Store.Common.Constant.Settings;

namespace Store.Application.Services.ProductsSite.Queries.GetDetailProductModalForSite
{
    public class DetailProductModalSiteDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long CodeProduct { get; set; }
        public string? Brand { get; set; }
        public int Star { get; set; }
        public double Price { get; set; }
        public double LastPrice { get; set; }
        public float Discount { get; set; }
        public string? Description { get; set; }
        public string Unit { get; set; }
        public bool NewProduct { get; set; }
        public List<TagsListDto>? Tags { get; set; }
        public List<ImagesListDto>? UrlImagList { get; set; }

    }
}
