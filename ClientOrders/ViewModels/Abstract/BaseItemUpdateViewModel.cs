using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class BaseItemUpdateViewModel<T> : BaseViewModel where T : IEntity
    {
        protected readonly ICrudService CrudService;
        
        public BaseItemUpdateViewModel(ICrudService crudService)
        {
            CrudService = crudService;

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public abstract bool ValidateSave();
        public int ItemId { get; set; }

        public override async void OnAppearing() 
        {
            await LoadItem(ItemId);
        }

		public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        private async void OnCancel()
            => await Shell.Current.GoToAsync("..");
        public abstract T SetItem();
        public abstract Task LoadItem(int id);
        private async void OnSave()
        {
            var item = SetItem();

            await CrudService.UpdateItemAsync(item);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}