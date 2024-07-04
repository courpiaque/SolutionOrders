using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;
using ClientOrders.Views.Orders;

namespace ClientOrders.ViewModels.Orders
{
    public class OrderViewModel : BaseItemsViewModel<Order>
    {
        public OrderViewModel(ICrudService crudService) : base(crudService)
        {
        }

        public override async Task GoToAddPage()
            => await Shell.Current.GoToAsync(nameof(NewOrderPage));

        public override Task GoToDetailsPage(Order item) => Task.CompletedTask;
    }
}
