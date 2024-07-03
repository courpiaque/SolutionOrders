using ClientOrders.Models.Abstract;
using System.Net.Http.Json;

namespace ClientOrders.Services.Abstract
{
    public class CrudService<T> : ICrudService<T> where T : IEntity
    {
        public List<T> items;
        public CrudService()
            : base()
        {
        }
        public virtual async Task Refresh()
        {
			using var client = CreateHttpClient();

			try
			{
				var entities = await client.GetFromJsonAsync<IEnumerable<T>>($"{typeof(T).Name}");

				items = entities.ToList();
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
			}
		}

        public virtual async Task<bool> DeleteItemFromService(int id)
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

        public virtual async Task<bool> UpdateItemInService(T item)
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

        public virtual async Task<bool> AddItemToService(T item)
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

        public virtual async Task<bool> AddItemAsync(T item)
        {
            await AddItemToService(item);
            await Refresh();
            return await Task.FromResult(true);
        }

        public virtual async Task<T> Find(int id)
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

        public virtual async Task<bool> UpdateItemAsync(T item)
        {
            await UpdateItemInService(item);
            await Refresh();
            return await Task.FromResult(true);
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            await DeleteItemFromService(id);
            await Refresh();
            return await Task.FromResult(true);
        }

        public virtual async Task<T> GetItemAsync(int id)
            => await Find(id);

        public virtual async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await Refresh();
            return await Task.FromResult(items);
        }

		private static HttpClient CreateHttpClient()
		{
			return new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5209/api/") };
		}
	}
}
