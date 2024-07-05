using ClientOrders.ViewModels.Accounts;

namespace ClientOrders.Views.Accounts;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}