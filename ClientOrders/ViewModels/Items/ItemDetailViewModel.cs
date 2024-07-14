using System.Diagnostics;
using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Items
{
    public class ItemDetailViewModel : BaseItemDetailsViewModel<Item>
    {
        public ItemDetailViewModel(ICrudService crudService) : base(crudService)
        {
        }

		private int id;
		private string name;
		private string description;
		private string selectedCategory;
		private decimal price;
		private decimal quantity;
		private string selectedPhoto;
		private string selectedUnitOfMeasurement;
		private string code;

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

		public string SelectedCategory
		{
			get => selectedCategory;
			set => SetProperty(ref selectedCategory, value);
		}
		public decimal Price
		{
			get => price;
			set => SetProperty(ref price, value);
		}

		public decimal Quantity
		{
			get => quantity;
			set => SetProperty(ref quantity, value);
		}
		public string SelectedPhoto
		{
			get => selectedPhoto;
			set => SetProperty(ref selectedPhoto, value);
		}

		public string SelectedUnitOfMeasurement
		{
			get => selectedUnitOfMeasurement;
			set => SetProperty(ref selectedUnitOfMeasurement, value);
		}

		public string Code
		{
			get => code;
			set => SetProperty(ref code, value);
		}

		public override async Task LoadItem(int id)
        {
            try
            {
                var item = await CrudService.GetItemAsync<Item>(id);

				if (item == null)
					return;

                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
				SelectedCategory = item.CategoryData;
				SelectedUnitOfMeasurement = item.UnitOfMeasurementData;
				Price = item.Price.GetValueOrDefault();
				Quantity = item.Quantity.GetValueOrDefault();
				SelectedPhoto = item.FotoUrl;
				Code = item.Code;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        protected override Task GoToUpdatePage() { return Task.CompletedTask; }
    }
}
