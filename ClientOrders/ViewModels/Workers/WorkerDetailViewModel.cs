using System.Diagnostics;
using ClientOrders.Models;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;

namespace ClientOrders.ViewModels.Workers
{
    public class WorkerDetailViewModel : BaseItemDetailsViewModel<Worker>
    {
        public WorkerDetailViewModel(ICrudService crudService) : base(crudService)
        {
        }

        private string name;
        private string description;

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
                var item = await CrudService.GetItemAsync<Worker>(id);
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
