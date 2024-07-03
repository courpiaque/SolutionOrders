using System.Diagnostics;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Items
{
    public class ItemDetailViewModel : BaseItemDetailsViewModel<Models.Item>
    {
        private string name;
        private string description;

        public ItemDetailViewModel()
        {
        }

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

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        protected override Task GoToUpdatePage()
        {
            throw new NotImplementedException();
        }
    }
}
