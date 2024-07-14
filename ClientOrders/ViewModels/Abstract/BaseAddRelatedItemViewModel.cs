using ClientOrders.Models.Abstract;
using ClientOrders.Services.Abstract;

namespace ClientOrders.ViewModels.Abstract
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public abstract class BaseAddRelatedItemViewModel<TEntity, TItem> : BaseViewModel 
		where TEntity : IEntity
		where TItem : IEntity
	{
		protected readonly ICrudService CrudService;
		public BaseAddRelatedItemViewModel(ICrudService crudService)
		{
			CrudService = crudService;

			SaveCommand = new Command(OnSave, ValidateSave);

			PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
		}

		public int ItemId { get; set; }

		public Command SaveCommand { get; }

		public override void OnAppearing() { }

		public abstract bool ValidateSave();
		public abstract TItem SetItem();
		private async void OnSave()
		{
			var item = SetItem();

			await CrudService.AddRelatedItemAsync<TEntity, TItem>(ItemId, item);

			await Shell.Current.GoToAsync("..");
		}
	}
}
