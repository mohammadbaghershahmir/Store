using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite
{
    public interface IGetDetailProductSiteService
    {
        Task<DetailProductSiteDto> Execute(string idProduct);
    }
    public class FeatureListDto
    {
        public string? Title { get; set; }
        public string? Value { get; set; }
    }
    public class TagsListDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
    public class ImagesListDto
    {
        public string? Url { get; set; }
    }
}
