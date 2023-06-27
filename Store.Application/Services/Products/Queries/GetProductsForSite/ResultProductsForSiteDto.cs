namespace Store.Application.Services.ProductsSite.Queries.GetProductsForSite
{
	public class ResultProductsForSiteDto
    {
       public List<ProductsForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }
}
