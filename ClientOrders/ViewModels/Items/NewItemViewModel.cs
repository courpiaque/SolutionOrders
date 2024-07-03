using ClientOrders.ViewModels.Abstract;
using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.Models.Lookups;
using ClientOrders.Services;

namespace ClientOrders.ViewModels.Items
{
    public class NewItemViewModel : BaseNewItemViewModel<Item>
    {
        private string name;
        private string description;
        private Category selectedCategory;
        private decimal price;
        private decimal quantity;
        private string selectedPhoto;
        private UnitOfMeasurement selectedUnitOfMeasurement;
        private string code;
        private List<Category> categories;
        private List<UnitOfMeasurement> unitOfMeasurements;

        private readonly ILookupService lookupService;

        public NewItemViewModel(ILookupService lookupService)
        {
            this.lookupService = lookupService;
        }

        public override void OnAppearing()
        {
            UnitOfMeasurements = lookupService.GetLookupsAsync<UnitOfMeasurement>().GetAwaiter().GetResult().ToList();
            Categories = lookupService.GetLookupsAsync<Category>().GetAwaiter().GetResult().ToList();

            base.OnAppearing();
        }


        public override bool ValidateSave()
            => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(description);
        
        public List<Category> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        public List<UnitOfMeasurement> UnitOfMeasurements
        {
            get => unitOfMeasurements;
            set => SetProperty(ref unitOfMeasurements, value);
        }

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

        public Category SelectedCategory
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

        public UnitOfMeasurement SelectedUnitOfMeasurement
        {
            get => selectedUnitOfMeasurement;
            set => SetProperty(ref selectedUnitOfMeasurement, value);
        }

        public string Code 
        {
            get => code;
            set => SetProperty(ref code, value);
        }

        public override Item SetItem()
            => new Item()
            {
                Id = 0,
                Name = Name,
                Description = Description,
                IdCategory = SelectedCategory.Id,
                Price = Price,
                Quantity = Quantity,
                FotoUrl = SelectedPhoto,
                IdUnitOfMeasurement = SelectedUnitOfMeasurement.Id,
                Code = Code
            };
    }
}
