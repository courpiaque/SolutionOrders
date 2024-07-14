using ClientOrders.Views.Clients;
using ClientOrders.Views.Items;
using ClientOrders.Views.Orders;
using ClientOrders.Views.Workers;

namespace ClientOrders
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			RegisterRoutes();
		}

		private void RegisterRoutes()
		{
			// Clients
			Routing.RegisterRoute(nameof(ClientDetailPage), typeof(ClientDetailPage));
			Routing.RegisterRoute(nameof(ClientUpdatePage), typeof(ClientUpdatePage));
			Routing.RegisterRoute(nameof(NewClientPage), typeof(NewClientPage));

			// Items
			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

			// Orders
			Routing.RegisterRoute(nameof(NewOrderPage), typeof(NewOrderPage));
			Routing.RegisterRoute(nameof(OrderItemsPage), typeof(OrderItemsPage));
			Routing.RegisterRoute(nameof(AddOrderItemPage), typeof(AddOrderItemPage));
		}
    }
}
