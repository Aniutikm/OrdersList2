using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAngularWebPortal.Entities;

public class Customer
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }

	[Required]
	public DateTime CreatedDate { get; set; }

	[Required]
	[StringLength(255)]
	public string CustomerName { get; set; }

	[StringLength(500)]
	public string Address { get; set; }

	public virtual ICollection<Order> Orders { get; set; }
}