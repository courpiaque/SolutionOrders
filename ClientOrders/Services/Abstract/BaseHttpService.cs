using ClientOrders.Helpers;

namespace ClientOrders.Services
{
    public abstract class BaseHttpService
    {
		protected static HttpClient CreateHttpClient()
		{
			var handler = new HttpClientHandler();

			var jwtToken = TokenRepository.Current.Token;

			var jwtHandler = new JwtTokenHandler(jwtToken)
			{
				InnerHandler = handler
			};

			return new HttpClient(jwtHandler) { BaseAddress = new Uri("http://10.0.2.2:5209/api/")};
		}
	}
}