using ClientOrders.ViewModels.Orders;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Orders;

public partial class NewOrderPage : BaseContentPage
{
	public NewOrderPage(NewOrderViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}