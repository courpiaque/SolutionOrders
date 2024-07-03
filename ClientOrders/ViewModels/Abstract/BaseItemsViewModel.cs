﻿using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ClientOrders.ViewModels.Abstract
{
    public abstract class BaseItemsViewModel<T> : BaseViewModel where T : IEntity
    {
        #region Fields
        public ICrudService<T> DataStore { get; } = new CrudService<T>();
        private T _selectedItem;
        #endregion
        public BaseItemsViewModel()
        {
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
		}
        #region Properties
        public ObservableCollection<T> Items { get; } = new();
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<T> ItemTapped { get; }
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        #endregion
        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);

                if (items?.Count() > 0)
					foreach (var item in items)
					{
						Items.Add(item);
					}
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
        public abstract Task GoToDetailsPage(T item);

        async void OnItemSelected(T item)
        {
            if (item == null)
                return;
            await GoToDetailsPage(item);
        }
    }
}
