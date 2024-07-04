using ClientOrders.ViewModels.Workers;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Workers;

public partial class WorkersPage : BaseContentPage
{
	public WorkersPage(WorkersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}