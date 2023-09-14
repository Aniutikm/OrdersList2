using Microsoft.AspNetCore.Mvc;
using WebApplicationAngularWebPortal.DataTransferObjects;
using WebApplicationAngularWebPortal.Entities;
using WebApplicationAngularWebPortal.Repository;

namespace WebApplicationAngularWebPortal.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderRepository _repository;

		public OrdersController(IOrderRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("GetOrders")]
		public ActionResult<List<Order>> GetOrders()
		{
			return Ok(_repository.GetOrders());
		}

		[HttpGet("{orderNumber}")]
		public ActionResult<OrderDetailDto> GetOrderDetail(int orderNumber)
		{
			var orderDetail = _repository.GetOrderDetail(orderNumber);

			if (orderDetail == null)
			{
				return NotFound();
			}

			return Ok(orderDetail);
		}
	}
}