using System.Net.Http.Json;
using ClientOrders.Services.Abstract;

namespace ClientOrders.Services
{
    public class AuthService : BaseHttpService, IAuthService
    {
        public async Task<bool> LoginAsync(string login, string password)
        {
            using var client = CreateHttpClient();

			try
			{
				var responseMessage = await client.PostAsJsonAsync($"Account/login", (login, password));

                return true;
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

                return false;
			}
        }

        public async Task<bool> RegisterAsync(string login, string password)
        {
            using var client = CreateHttpClient();

			try
			{
				var responseMessage = await client.PostAsJsonAsync($"Account/register", (login, password));

                return true;
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

                return false;
			}
        }
    }
}
