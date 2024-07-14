using ClientOrders.ViewModels.Orders;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Orders;

public partial class AddOrderItemPage : BaseContentPage
{
	public AddOrderItemPage(AddOrderItemViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}