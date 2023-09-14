using Microsoft.EntityFrameworkCore;

namespace WebApplicationAngularWebPortal.Entities;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
		this.ChangeTracker.LazyLoadingEnabled = true;
	}

	public DbSet<Order> Orders { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Customer> Customers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Order>()
			.HasOne(o => o.Customer)
			.WithMany(c => c.Orders)
			.HasForeignKey(o => o.CustomerID);

		modelBuilder.Entity<Order>()
			.HasOne(o => o.Customer)
			.WithMany(c => c.Orders)
			.HasForeignKey(o => o.CustomerID);

		modelBuilder.Entity<OrderDetails>()
			.HasOne(od => od.Product)
			.WithMany(p => p.OrderDetails)
			.HasForeignKey(od => od.ProductID);

		modelBuilder.Entity<OrderDetails>()
			.HasOne(od => od.Order)
			.WithMany(o => o.OrderDetails)
			.HasForeignKey(od => od.OrderID);
	}
}