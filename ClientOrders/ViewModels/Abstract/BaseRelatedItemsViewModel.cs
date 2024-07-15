using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ClientOrders.ViewModels.Abstract
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public abstract class BaseRelatedItemsViewModel<TEntity, TItem> : BaseViewModel
		where TEntity : IEntity
		where TItem : IEntity
	{
		public int ItemId { get; set; }

		protected readonly ICrudService CrudService;

		public BaseRelatedItemsViewModel(ICrudService crudService)
		{
			CrudService = crudService;

			Items = new ObservableCollection<TItem>();

			AddItemCommand = new Command(async () => await GoToAddPage());
		}

        public ObservableCollection<TItem> Items { get; } = new();

		public Command AddItemCommand { get; }

		public override async void OnAppearing()
		{
			await LoadItems();
		}

		// each class have to define its method for navigation to adding page
		public abstract Task GoToAddPage();

		private async Task LoadItems()
		{
			try
			{
				Items.Clear();

				var items = await CrudService.GetRelatedItemsAsync<TEntity, TItem>(ItemId);

				foreach (var item in items)
					Items.Add(item);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}
	}
}
