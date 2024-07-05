using ClientOrders.ViewModels.Accounts;

namespace ClientOrders.Views.Accounts;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}