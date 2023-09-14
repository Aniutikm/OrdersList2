using Microsoft.EntityFrameworkCore;
using WebApplicationAngularWebPortal.DataTransferObjects;
using WebApplicationAngularWebPortal.Entities;

namespace WebApplicationAngularWebPortal.Repository;

public class OrderRepository : IOrderRepository
{
	private readonly AppDbContext _context;

	public OrderRepository(AppDbContext context)
	{
		_context = context;
	}

	public List<OrderDto> GetOrders()
	{
		var orders = _context.Orders.Include(o => o.Customer).ToList();
		var result = orders.Select(ConvertToDto).ToList();
		return result;
	}

	public OrderDetailDto GetOrderDetail(int orderNumber)
	{
		var order = _context.Orders
			.Include(o => o.Customer)
			.Include(o => o.OrderDetails) // Include the OrderDetails
			.ThenInclude(od => od.Product) // Then include the Product within each OrderDetail
			.FirstOrDefault(o => o.ID == orderNumber); // Adjusted OrderNumber to ID based on your table schema

		if (order == null)
		{
			return null;
		}

		return ConvertToOrderDetailDto(order);
	}

	private OrderDto ConvertToDto(Order order)
	{
		return new OrderDto
		{
			Id = order.ID,
			CustomerId = order.CustomerID,
			CustomerName = order.Customer.CustomerName,
			CustomerAddress = order.Customer.Address,
			StatusName = Enum.GetName(typeof(Status), order.Status),
			TotalCost = order.TotalCost,
			StatusID = (int) order.Status
		};
	}

	private OrderDetailDto ConvertToOrderDetailDto(Order order)
	{
		var orderDetail = new OrderDetailDto
		{
			OrderNumber = order.ID,
			OrderDate = DateTime.Now.AddDays(-1),
			CustomerId = order.CustomerID,
			CustomerName = order.Customer?.CustomerName, // Make it null safe
			StatusId = (int) order.Status,
			StatusName = Enum.GetName(typeof(Status), order.Status),
			TotalCost = order.TotalCost,
			Products = order.OrderDetails?.Select(od => new ProductDetailDto // Make it null safe
			{
				ProductId = od.Product.ID,
				ProductName = od.Product.ProductName,
				ProductCategoryId = (int) od.Product.Category,
				ProductCategoryName = Enum.GetName(typeof(Category), od.Product.Category),
				ProductSizeId = (int) od.Product.ProdiceSize,
				ProductSizeName = Enum.GetName(typeof(Size), od.Product.ProdiceSize),
				Quantity = od.Quantity,
				Price = od.Product.Price,
				Comment = od.Comment
			}).ToList()
		};

		return orderDetail;
	}
}