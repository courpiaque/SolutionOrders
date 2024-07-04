using ClientOrders.ViewModels.Clients;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Clients;

public partial class ClientDetailPage : BaseContentPage
{
	public ClientDetailPage(ClientDetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}