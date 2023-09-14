namespace WebApplicationAngularWebPortal.DataTransferObjects;

public class OrderDto
{
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public string CustomerName { get; set; }
	public string CustomerAddress { get; set; }
	public string? StatusName { get; set; }
	public int StatusID { get; set; }
	public decimal TotalCost { get; set; }
}