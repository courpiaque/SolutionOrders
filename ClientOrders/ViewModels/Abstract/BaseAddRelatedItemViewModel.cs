using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public abstract class BaseAddRelatedItemViewModel<TEntity, TItem> : BaseViewModel 
		where TEntity : IEntity
		where TItem : IEntity
	{
		public int ItemId { get; set; }

		protected readonly ICrudService CrudService;

		public BaseAddRelatedItemViewModel(ICrudService crudService)
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
		public abstract TItem SetItem();

		// saving can be handled fully generic
		private async void OnSave()
		{
			var item = SetItem();

			await CrudService.AddRelatedItemAsync<TEntity, TItem>(ItemId, item);

			await Shell.Current.GoToAsync("..");
		}
	}
}
