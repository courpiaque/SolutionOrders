using ClientOrders.ViewModels.Abstract;
using ClientOrders.Models;

namespace ClientOrders.ViewModels.Items
{
    public class NewItemViewModel : BaseNewItemViewModel<Models.Item>
    {
        private string name;
        private string description;
        private string category;
        private decimal price;
        private decimal quantity;
        private string fotoUrl;
        private string unitOfMeasurement;
        private string code;

        public override bool ValidateSave()
            => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(description);
        
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

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
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
        public string FotoUrl
        {
            get => fotoUrl;
            set => SetProperty(ref fotoUrl, value);
        }

        public string UnitOfMeasurement
        {
            get => unitOfMeasurement;
            set => SetProperty(ref unitOfMeasurement, value);
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
                CategoryData = Category, //TODO
                Price = Price,
                Quantity = Quantity,
                FotoUrl = FotoUrl,
                UnitOfMeasurementData = UnitOfMeasurement, //TODO
                Code = Code
            };
    }
}
