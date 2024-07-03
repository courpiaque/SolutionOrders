using System.Diagnostics;
using ClientOrders.ViewModels.Abstract;
using ClientOrders.Views.Clients;

namespace ClientOrders.ViewModels.Clients
{
    internal class ClientDetailsViewModel : BaseItemDetailsViewModel<Models.Client>
    {
        #region Fields
        private int id;
        private string name;
        private string address;
        private string phoneNumber;
        #endregion
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
        public ClientDetailsViewModel()
        {
        }

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item == null)
                    return;
                Id = id;
                Address = item.Address;
                PhoneNumber = item.PhoneNumber;
                Name = item.Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(ClientUpdatePage)}?{nameof(ClientDetailsViewModel.ItemId)}={ItemId}");
    }
}
