using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAngularWebPortal.Entities;


public class Order
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }
    
	[ForeignKey("Customer")]
	public int CustomerID { get; set; }
    
	[StringLength(500)]
	public string Comment { get; set; }

	[Column(TypeName = "decimal(18, 2)")]
	public decimal TotalCost { get; set; }
    
	public Status Status { get; set; }

	// Navigation Properties
	public virtual Customer Customer { get; set; }

	public virtual ICollection<OrderDetails> OrderDetails { get; set; }
}
