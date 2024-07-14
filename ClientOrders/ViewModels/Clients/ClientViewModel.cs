using ClientOrders.Views.Clients;
using ClientOrders.ViewModels.Abstract;
using ClientOrders.Services.Abstract;
using ClientOrders.Models;

namespace ClientOrders.ViewModels.Clients
{
    public class ClientViewModel : BaseItemsViewModel<Client>
    {
        public ClientViewModel(ICrudService crudService) : base(crudService)
        {
        }

        public override async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewClientPage));
		}

        public override async Task GoToDetailsPage(Client client)
        {
			await Shell.Current.GoToAsync($"{nameof(ClientDetailPage)}?{nameof(ClientDetailsViewModel.ItemId)}={client.Id}");
		}
    }
}