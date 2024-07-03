using ClientOrders.Models;
using ClientOrders.ViewModels.Abstract;
using ClientOrders.Views.Orders;

namespace ClientOrders.ViewModels.Orders
{
    internal class OrderViewModel : BaseItemsViewModel<Order>
    {
        public OrderViewModel()
        {
        }
        public override async Task GoToAddPage()
            => await Shell.Current.GoToAsync(nameof(NewOrderPage));

        public override Task GoToDetailsPage(Order item) => Task.CompletedTask;
    }
}
