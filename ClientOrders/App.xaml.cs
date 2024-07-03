namespace ClientOrders;

public partial class App : Application
{
	public App(AppShell appShell)
	{
		App.Current.UserAppTheme = AppTheme.Light;

		InitializeComponent();

		MainPage = appShell;
	}
}
