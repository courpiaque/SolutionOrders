using System.Diagnostics;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Workers
{
    public class WorkerDetailViewModel : BaseItemDetailsViewModel<Models.Worker>
    {
        private string name;
        private string description;

        public WorkerDetailViewModel()
        {
        }

        public int Id { get; set; }

        public string FirstName
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string LastName
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
                FirstName = item.FirstName;
                LastName = item.LastName;
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
