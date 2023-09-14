namespace WebApplicationAngularWebPortal.DataTransferObjects;

public class ProductDetailDto
{
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public int ProductCategoryId { get; set; }
	public string ProductCategoryName { get; set; }
	public int ProductSizeId { get; set; }
	public string ProductSizeName { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public string Comment { get; set; }
}