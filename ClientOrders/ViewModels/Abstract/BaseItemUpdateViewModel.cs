using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class BaseItemUpdateViewModel<T> : BaseViewModel where T : IEntity
    {
        public int ItemId { get; set; }

        protected readonly ICrudService CrudService;
        
        public BaseItemUpdateViewModel(ICrudService crudService)
        {
            CrudService = crudService;

            SaveCommand = new Command(OnSave, ValidateSave);

            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        

		public Command SaveCommand { get; }

        public override async void OnAppearing() 
        {
            await LoadItem(ItemId);
        }

        // each class have to define its loading item method
        public abstract Task LoadItem(int id);

        // each class have to define its saving item validation
        public abstract bool ValidateSave();

        // each class have to defince its setting for item details
        public abstract T SetItem();

        // saving can be handled fully generic
        private async void OnSave()
        {
            var item = SetItem();

            await CrudService.UpdateItemAsync(item);

            await Shell.Current.GoToAsync("..");
        }
    }
}