using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Abstract;
using ClientOrders.Views.Workers;

namespace ClientOrders.ViewModels.Workers
{
    public class WorkersViewModel : BaseItemsViewModel<Models.Worker>
    {
        public WorkersViewModel(ICrudService crudService) : base(crudService)
        {
        }

        public override async Task GoToAddPage() { return; }
        public override async Task GoToDetailsPage(Models.Worker worker) { return; }
    }
}