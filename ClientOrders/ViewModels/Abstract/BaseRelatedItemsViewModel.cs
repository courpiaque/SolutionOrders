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
		#region Fields

		protected readonly ICrudService CrudService;

		#endregion
		public BaseRelatedItemsViewModel(ICrudService crudService)
		{
			CrudService = crudService;

			Items = new ObservableCollection<TItem>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			AddItemCommand = new Command(OnAddItem);
		}
        #region Properties
        
		public int ItemId { get; set; }
        public ObservableCollection<TItem> Items { get; } = new();
		public Command LoadItemsCommand { get; }
		public Command AddItemCommand { get; }

		#endregion
		async Task ExecuteLoadItemsCommand()
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
		public override void OnAppearing()
		{
			_ = ExecuteLoadItemsCommand();
		}

		private async void OnAddItem(object obj)
			=> await GoToAddPage();

		public abstract Task GoToAddPage();
	}
}
