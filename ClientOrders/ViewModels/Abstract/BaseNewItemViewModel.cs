using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
    public abstract class BaseNewItemViewModel<T> : BaseViewModel where T : IEntity
    {
        protected readonly ICrudService CrudService;

        public BaseNewItemViewModel(ICrudService crudService)
        {
            CrudService = crudService;

            SaveCommand = new Command(OnSave, ValidateSave);

            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        public Command SaveCommand { get; }

		public override void OnAppearing() { }

        // each class have to define its saving item validation
        public abstract bool ValidateSave();

        // each class have to defince its setting for item details
		public abstract T SetItem();

        // saving can be handled fully generic
		private async void OnSave()
        {
            var item = SetItem();

            await CrudService.AddItemAsync(item);

            await Shell.Current.GoToAsync("..");
        }
	}
}