using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class BaseItemDetailsViewModel<T> : BaseViewModel where T : IEntity
    {
        public int ItemId { get; set; }

        protected readonly ICrudService CrudService;

        public BaseItemDetailsViewModel(ICrudService crudService)
        {
            CrudService = crudService;

            DeleteCommand = new Command(OnDelete);
            UpdateCommand = new Command(async () => await GoToUpdatePage());
        }

        public Command DeleteCommand { get; }
        public Command UpdateCommand { get; }

        public override async void OnAppearing() 
        {
            await LoadItem(ItemId);
        }

        // each class have to define its loading item method
        public abstract Task LoadItem(int id);

        // each class have to define its navigation to detail page
        protected abstract Task GoToUpdatePage();

        private async void OnDelete()
        {
            await CrudService.DeleteItemAsync<T>(ItemId);
            await Shell.Current.GoToAsync("..");
        }
    }
}