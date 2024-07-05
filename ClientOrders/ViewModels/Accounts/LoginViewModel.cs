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

        //private readonly AppShell appShell;

        public LoginViewModel(IAuthService authService, RegisterPage registerPage, IServiceProvider serviceProvider)//, AppShell appShell)
        {
            this.authService = authService;
            this.serviceProvider = serviceProvider;
            //this.appShell= appShell;

            LoginCommand = new Command(async () => await OnLogin());//, CanLogin);
            GoToRegisterCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(registerPage));

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
            var success = true; //await authService.LoginAsync(Login, Password);

            if (success)
            {
                App.Current.MainPage = serviceProvider.GetService<AppShell>();
            }
        }

        public override void OnAppearing() { }
    }
}