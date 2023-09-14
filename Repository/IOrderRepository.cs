using WebApplicationAngularWebPortal.DataTransferObjects;

namespace WebApplicationAngularWebPortal.Repository;

public interface IOrderRepository
{
	List<OrderDto> GetOrders();
	public OrderDetailDto GetOrderDetail(int orderNumber);
}