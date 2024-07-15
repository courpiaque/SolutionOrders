using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;
using System.Net.Http.Json;

namespace ClientOrders.Services
{
	// Service to fetch lookups
    public class LookupService : BaseHttpService, ILookupService
    {
        public virtual async Task<IEnumerable<T>> GetLookupsAsync<T>() where T : ILookup
        {
            using var client = CreateHttpClient();

			try
			{
				var entities = await client.GetFromJsonAsync<IEnumerable<T>>($"{typeof(T).Name}");

				return entities.ToList();
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

                return new List<T>();
			}
        }
	}
}
