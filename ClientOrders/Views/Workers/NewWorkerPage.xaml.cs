using ClientOrders.ViewModels.Workers;
using ClientOrders.Views.Abstract;

namespace ClientOrders.Views.Workers;

public partial class NewWorkerPage : BaseContentPage
{
	public NewWorkerPage(NewWorkerViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}