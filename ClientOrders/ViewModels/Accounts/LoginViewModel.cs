using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;
using ClientOrders.Views.Accounts;

namespace ClientOrders.ViewModels.Accounts
{
    public class LoginViewModel : BaseViewModel
    {
        private string login;
        private string password;
        private readonly IAuthService authService;
        private readonly IServiceProvider serviceProvider;
		private readonly IAnalyticsService analyticsService;

		//private readonly AppShell appShell;

		public LoginViewModel(IAuthService authService, IServiceProvider serviceProvider, IAnalyticsService analyticsService)
        {
            this.authService = authService;
            this.serviceProvider = serviceProvider;
			this.analyticsService = analyticsService;

			LoginCommand = new Command(async () => await OnLogin(), CanLogin);
            GoToRegisterCommand = new Command(async () => await OnGoToRegister());

            PropertyChanged += (_, __) => LoginCommand.ChangeCanExecute();
        }

        public Command LoginCommand { get; }
        public Command GoToRegisterCommand { get; }

        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private bool CanLogin() => 
           !string.IsNullOrEmpty(Login) 
        && !string.IsNullOrEmpty(Password);

        private async Task OnLogin()
        {
            var success = await authService.LoginAsync(Login, Password);

            if (success)
            {
                analyticsService.Log("User logged");
                App.Current.MainPage = serviceProvider.GetService<AppShell>();
            }
        }
		private async Task OnGoToRegister()
		{
			var registerPage = serviceProvider.GetService<RegisterPage>();
			await App.Current.MainPage.Navigation.PushAsync(registerPage);
		}

		public override void OnAppearing() { }
    }
}