using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.Views.Abstract;

public abstract class BaseContentPage : ContentPage
{
	protected override void OnAppearing()
	{
		(BindingContext as BaseViewModel).OnAppearing();

		base.OnAppearing();
	}
}
