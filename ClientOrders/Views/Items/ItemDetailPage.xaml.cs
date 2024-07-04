using ClientOrders.ViewModels.Items;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Items;

public partial class ItemDetailPage : BaseContentPage
{
	public ItemDetailPage(ItemDetailViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}