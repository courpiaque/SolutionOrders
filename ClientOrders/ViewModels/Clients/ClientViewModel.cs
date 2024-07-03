using ClientOrders.Views.Clients;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Clients
{
    public class ClientViewModel : BaseItemsViewModel<Models.Client>
    {
        public ClientViewModel()
        {
        }
        public override async Task GoToAddPage()
            => await Shell.Current.GoToAsync(nameof(NewClientPage));

        public override async Task GoToDetailsPage(Models.Client client)
            => await Shell.Current.GoToAsync($"{nameof(ClientDetailPage)}?{nameof(ClientDetailsViewModel.ItemId)}={client.Id}");
    }
}