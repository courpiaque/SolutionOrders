using ClientOrders.ViewModels.Clients;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Clients;

public partial class ClientsPage : BaseContentPage
{
	public ClientsPage(ClientViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}