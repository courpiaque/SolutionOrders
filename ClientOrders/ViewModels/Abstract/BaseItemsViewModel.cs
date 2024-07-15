using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ClientOrders.ViewModels.Abstract
{
    public abstract class BaseItemsViewModel<T> : BaseViewModel where T : IEntity
    {
        #region Fields

        protected readonly ICrudService CrudService;

        #endregion
        public BaseItemsViewModel(ICrudService crudService)
        {
            CrudService = crudService;

            AddItemCommand = new Command(async () => await GoToAddPage());
		}
        #region Properties

        public Command AddItemCommand { get; }

        public ObservableCollection<T> Items { get; } = new();

        private T _selectedItem;
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                GoToDetailsPage(value);
            }
        }

		#endregion

        // each class have to define its navigation to adding page
		public abstract Task GoToAddPage();

        // each class have to define its navigation to details page
		public abstract Task GoToDetailsPage(T item);

		public override async void OnAppearing()
		{
			await LoadItems();
		}

		async Task LoadItems()
        {
            try
            {
                Items.Clear();

                var items = await CrudService.GetItemsAsync<T>();

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
