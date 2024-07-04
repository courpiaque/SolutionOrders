using ClientOrders.ViewModels.Items;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Items;

public partial class ItemsPage : BaseContentPage
{
	public ItemsPage(ItemsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}