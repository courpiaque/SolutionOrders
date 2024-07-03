using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
    public abstract class BaseNewItemViewModel<T> : BaseViewModel where T : IEntity
    {
        public ICrudService<T> DataStore { get; } = new CrudService<T>();
        public BaseNewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);

            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        public Command SaveCommand { get; }

		public override void OnAppearing() { }

		public abstract bool ValidateSave();
        public abstract T SetItem();
        private async void OnSave()
        {
            var item = SetItem();

            await DataStore.AddItemAsync(item);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}