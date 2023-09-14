using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAngularWebPortal.Entities;

public class OrderDetails
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }
	public int Quantity { get; set; }
	public string Comment { get; set; }
	public int OrderID { get; set; }
	public Order Order { get; set; }
	public int ProductID { get; set; }
	public Product Product { get; set; }
}