using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;
using ClientOrders.Views.Orders;

namespace ClientOrders.ViewModels.Orders
{
	public class OrderItemsViewModel : BaseRelatedItemsViewModel<Order, OrderItem>
	{
		public OrderItemsViewModel(ICrudService crudService) : base(crudService)
		{
		}

		public override async Task GoToAddPage()
		{
			await Shell.Current.GoToAsync($"{nameof(AddOrderItemPage)}?{nameof(AddOrderItemViewModel.ItemId)}={ItemId}");
		}
	}
}
