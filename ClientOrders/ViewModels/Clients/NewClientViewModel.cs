using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Clients
{
    public class NewClientViewModel : BaseNewItemViewModel<Models.Client>
    {
        #region Fields
        private int id;
        private string name;
        private string address;
        private string phoneNumber;

        #endregion

        public NewClientViewModel(ICrudService crudService) : base(crudService)
        {
        }

        #region Properties
        public int Id
		{
			get => id;
			set => SetProperty(ref id, value);
		}
		public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        #endregion
        public override bool ValidateSave() => !string.IsNullOrWhiteSpace(Name);
        public override Client SetItem() 
        {
            return new Client()
            {
                Id = Id,
                Name = Name,
                Address = address,
                PhoneNumber = PhoneNumber
            };
        }
    }
}
