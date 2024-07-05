namespace ClientOrders.Services
{
    public abstract class BaseHttpService
    {
		protected static HttpClient CreateHttpClient()
		{
			return new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5209/api/") };
		}
	}
}