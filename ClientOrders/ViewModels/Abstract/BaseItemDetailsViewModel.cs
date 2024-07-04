using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class BaseItemDetailsViewModel<T> : BaseViewModel where T : IEntity
    {
        protected readonly ICrudService CrudService;
        public BaseItemDetailsViewModel(ICrudService crudService)
        {
            CrudService = crudService;

            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            UpdateCommand = new Command(OnUpdate);
        }
        public int ItemId { get; set; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }
        public Command UpdateCommand { get; }

        public override async void OnAppearing() 
        {
            await LoadItem(ItemId);
        }

		private async void OnCancel()
            => await Shell.Current.GoToAsync("..");
        private async void OnDelete()
        {
            await CrudService.DeleteItemAsync<T>(ItemId);
            await Shell.Current.GoToAsync("..");
        }
        private async void OnUpdate()
            => await GoToUpdatePage();

        protected abstract Task GoToUpdatePage();

        public abstract Task LoadItem(int id);
    }
}