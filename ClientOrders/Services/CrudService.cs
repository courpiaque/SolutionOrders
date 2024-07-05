using ClientOrders.Models.Abstract;
using System.Net.Http.Json;

namespace ClientOrders.Services.Abstract
{
    public class CrudService : BaseHttpService, ICrudService
    {
        public CrudService()
            : base()
        {
        }

        public virtual async Task<bool> DeleteItemAsync<T>(int id) where T : IEntity
        {
			using var client = CreateHttpClient();

			try
			{
				var response = await client.DeleteAsync($"{typeof(T).Name}/{id}");

				return true;
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

				return false;
			}
		}

        public virtual async Task<bool> UpdateItemAsync<T>(T item) where T : IEntity
        {
			using var client = CreateHttpClient();

			try
			{
				var response = await client.PutAsJsonAsync($"{typeof(T).Name}/{item.Id}", item);

				return true;
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
				
				return false;
			}
		}

        public virtual async Task<bool> AddItemAsync<T>(T item) where T : IEntity
        {
			using var client = CreateHttpClient();

			try
			{
				await client.PostAsJsonAsync($"{typeof(T).Name}", item);

				return true;
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

				return false;
			}
		}

        public virtual async Task<T> GetItemAsync<T>(int id) where T : IEntity
		{
			using var client = CreateHttpClient();

			try
			{
				var entity = await client.GetFromJsonAsync<T>($"{typeof(T).Name}/{id}");

				return entity;
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

				return default;
			}
		}

        public virtual async Task<IEnumerable<T>> GetItemsAsync<T>(bool forceRefresh = false) where T : IEntity
        {
            using var client = CreateHttpClient();

			try
			{
				var entities = await client.GetFromJsonAsync<IEnumerable<T>>($"{typeof(T).Name}");

				return entities;
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

				return new List<T>();
			}
		}
	}
}
