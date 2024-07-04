using ClientOrders.ViewModels.Clients;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Clients;

public partial class ClientUpdatePage : BaseContentPage
{
	public ClientUpdatePage(ClientUpdateViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}