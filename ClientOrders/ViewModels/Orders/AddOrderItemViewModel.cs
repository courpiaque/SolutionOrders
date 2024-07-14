using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;
using System.Collections.ObjectModel;

namespace ClientOrders.ViewModels.Orders
{
	public class AddOrderItemViewModel : BaseAddRelatedItemViewModel<Order, OrderItem>
	{
		public AddOrderItemViewModel(ICrudService crudService) : base(crudService)
		{

		}

		private int identifier;
		public int Identifier
		{
			get => identifier;
			set => SetProperty(ref identifier, value);
		}

		public ObservableCollection<Item> Items { get; } = new();

		private Item selectedItem;
		public Item SelectedItem
		{
			get => selectedItem;
			set => SetProperty(ref selectedItem, value);	
		}

		private int quantity;

		public int Quantity
		{
			get => quantity;
			set => SetProperty(ref quantity, value);
		}


		public override async void OnAppearing()
		{
			var items = await CrudService.GetItemsAsync<Item>();

			foreach (var item in items) 
				Items.Add(item);

			base.OnAppearing();
		}

		public override OrderItem SetItem()
		{
			return new OrderItem
			{
				Id = Identifier,
				IdItem = SelectedItem.Id,
				Quantity = Quantity,
			};
		}

		public override bool ValidateSave()
		{
			return Identifier != 0 && SelectedItem?.Id != 0 && Quantity != 0;
		}
	}
}