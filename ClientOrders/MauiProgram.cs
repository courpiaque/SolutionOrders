using ClientOrders.Services;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Clients;
using ClientOrders.ViewModels.Items;
using ClientOrders.ViewModels.Orders;
using ClientOrders.ViewModels.Workers;
using ClientOrders.Views.Clients;
using ClientOrders.Views.Items;
using ClientOrders.Views.Orders;
using ClientOrders.Views.Workers;
using Microsoft.Extensions.Logging;

namespace ClientOrders
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.RegisterServices()
				.RegisterViewModels()
				.RegisterViews()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}

		private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
		{		
			builder.Services.AddSingleton<ILookupService, LookupService>();

			return builder;
		}

		private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
		{		
			// Clients
			builder.Services.AddTransient<ClientDetailsViewModel>();
			builder.Services.AddTransient<ClientUpdateViewModel>();
			builder.Services.AddTransient<ClientViewModel>();
			builder.Services.AddTransient<NewClientViewModel>();

			// Items
			builder.Services.AddTransient<ItemDetailViewModel>();
			builder.Services.AddTransient<ItemsViewModel>();
			builder.Services.AddTransient<NewItemViewModel>();

			// Orders
			builder.Services.AddTransient<OrderViewModel>();
			builder.Services.AddTransient<NewOrderViewModel>();

			// Workers
			builder.Services.AddTransient<WorkerDetailViewModel>();
			builder.Services.AddTransient<WorkersViewModel>();
			builder.Services.AddTransient<NewWorkerViewModel>();

			return builder;
		}

		private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<AppShell>();

			// Clients
			builder.Services.AddTransient<ClientDetailPage>();
			builder.Services.AddTransient<ClientUpdatePage>();
			builder.Services.AddSingleton<ClientsPage>();
			builder.Services.AddTransient<NewClientPage>();

			// Items
			builder.Services.AddTransient<ItemDetailPage>();
			builder.Services.AddSingleton<ItemsPage>();
			builder.Services.AddTransient<NewItemPage>();

			// Orders
			builder.Services.AddSingleton<OrderPage>();
			builder.Services.AddTransient<NewOrderPage>();

			// Workers
			builder.Services.AddSingleton<WorkersPage>();
			builder.Services.AddTransient<NewWorkerPage>();

			return builder;
		}
	}
}
