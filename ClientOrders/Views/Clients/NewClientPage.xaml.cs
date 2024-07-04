using ClientOrders.ViewModels.Clients;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Clients;

public partial class NewClientPage : BaseContentPage
{
	public NewClientPage(NewClientViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}