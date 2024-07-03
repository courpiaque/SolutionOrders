using ClientOrders.ViewModels.Items;

namespace ClientOrders.Views.Items;

public partial class NewItemPage : ContentPage
{
	public NewItemPage(NewItemViewModel newItemViewModel)
	{
		InitializeComponent();

		BindingContext = newItemViewModel;
	}
}