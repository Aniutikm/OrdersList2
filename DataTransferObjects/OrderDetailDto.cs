namespace WebApplicationAngularWebPortal.DataTransferObjects;

public class OrderDetailDto
{
	public int OrderNumber { get; set; }
	public DateTime OrderDate { get; set; }
	public int CustomerId { get; set; }
	public string CustomerName { get; set; }
	public int StatusId { get; set; }
	public string StatusName { get; set; }
	public decimal TotalCost { get; set; }
	public List<ProductDetailDto> Products { get; set; }
}