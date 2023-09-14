namespace WebApplicationAngularWebPortal.Entities;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }

	[Required] [StringLength(255)] public string ProductName { get; set; }

	[StringLength(500)] public string Description { get; set; }

	public Category Category { get; set; }

	public Size ProdiceSize { get; set; }

	public int Quantity { get; set; }

	[Column(TypeName = "decimal(18, 2)")] public decimal Price { get; set; }

	public virtual ICollection<OrderDetails> OrderDetails { get; set; }
}