using ClientOrders.ViewModels.Abstract;
using ClientOrders.Views.Items;

namespace ClientOrders.ViewModels.Items
{
    public class ItemsViewModel : BaseItemsViewModel<Models.Item>
    {
        public ItemsViewModel()
        {
        }
        public override async Task GoToAddPage()
            => await Shell.Current.GoToAsync(nameof(NewItemPage));
        public override async Task GoToDetailsPage(Models.Item item)
            => await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
    }
}