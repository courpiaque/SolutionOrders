using System.Net.Http.Json;
using ClientOrders.Helpers;
using ClientOrders.Services.Abstract;

namespace ClientOrders.Services
{
    public class AuthService : BaseHttpService, IAuthService
    {
		private record User(string Login, string Password);
		private record TokenResponse(string Token);

        public async Task<bool> LoginAsync(string login, string password)
        {
            using var client = CreateHttpClient();

			try
			{
				var responseMessage = await client.PostAsJsonAsync($"Auth/login", new User(login, password));

				var tokenResponse = await responseMessage.Content.ReadFromJsonAsync<TokenResponse>();

				TokenRepository.Current.Token = tokenResponse.Token;

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
				await client.PostAsJsonAsync($"Auth/register", new User(login, password));

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
