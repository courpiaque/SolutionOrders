using System.Windows.Input;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Accounts
{
    public class RegisterViewModel : BaseViewModel
    {
        private string login;
        private string password;
        private string confirmPassword;
        private readonly IAuthService authService;

        public RegisterViewModel(IAuthService authService)
        {
            this.authService = authService;

            RegisterCommand = new Command(async () => await OnRegister(), CanRegister);

            PropertyChanged += (_, __) => RegisterCommand.ChangeCanExecute();

        }

        public Command RegisterCommand {get;}

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

        public string ConfirmPassword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }

        private bool CanRegister() => 
           !string.IsNullOrEmpty(Login) 
        || !string.IsNullOrEmpty(Password) 
        || !string.IsNullOrEmpty(ConfirmPassword);

        private async Task OnRegister()
        {
            if (Password != ConfirmPassword)
                await App.Current.MainPage.DisplayAlert("Invalid password", "Passwords must match", "Ok");

            var success = await authService.RegisterAsync(login, password);

            if (success)
            {

            }
        }


        public override void OnAppearing() { }
    }
}