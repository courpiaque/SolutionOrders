using ClientOrders.ViewModels.Items;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Items;

public partial class NewItemPage : BaseContentPage
{
	public NewItemPage(NewItemViewModel newItemViewModel)
	{
		InitializeComponent();

		BindingContext = newItemViewModel;
	}
}