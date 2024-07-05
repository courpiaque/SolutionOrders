using ClientOrders.Views.Accounts;

namespace ClientOrders;

public partial class App : Application
{
	public App(LoginPage loginPage)
	{
		App.Current.UserAppTheme = AppTheme.Light;

		InitializeComponent();

		MainPage =  new NavigationPage(loginPage);
	}
}
