using ClientOrders.ViewModels.Orders;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Orders;

public partial class OrderItemsPage : BaseContentPage
{
	public OrderItemsPage(OrderItemsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}