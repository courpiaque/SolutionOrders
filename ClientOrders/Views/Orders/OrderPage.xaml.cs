using ClientOrders.ViewModels.Orders;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Orders;

public partial class OrderPage : BaseContentPage
{
	public OrderPage(OrderViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}