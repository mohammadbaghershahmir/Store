namespace Store.Application.Services.ProductsSite.Queries.GetProductsForSite
{
	public class ProductsForSiteDto
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string Unit { get; set; }
        public double	 Price { get; set; }
        public double LastPrice { get; set; }
        public float Discount { get; set; }
        public bool NewProduct { get; set; }
        public int Star { get; set; }
    }
}
