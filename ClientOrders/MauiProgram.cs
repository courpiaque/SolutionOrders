using ClientOrders.Services;
using ClientOrders.Services.Abstract;
using ClientOrders.ViewModels.Accounts;
using ClientOrders.ViewModels.Clients;
using ClientOrders.ViewModels.Items;
using ClientOrders.ViewModels.Orders;
using ClientOrders.ViewModels.Workers;
using ClientOrders.Views.Accounts;
using ClientOrders.Views.Clients;
using ClientOrders.Views.Items;
using ClientOrders.Views.Orders;
using ClientOrders.Views.Workers;
using Firebase.Analytics.Connector;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

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
				.RegisterFirebase()
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
			builder.Services.AddSingleton<IAuthService, AuthService>();
			builder.Services.AddSingleton<ICrudService, CrudService>();
			builder.Services.AddSingleton<ILookupService, LookupService>();
			builder.Services.AddSingleton<IAnalyticsService, AnalyticsService>();

			return builder;
		}

		private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
		{		
			// Accounts
			builder.Services.AddTransient<LoginViewModel>();
			builder.Services.AddTransient<RegisterViewModel>();

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
			builder.Services.AddTransient<OrderItemsViewModel>();
			builder.Services.AddTransient<AddOrderItemViewModel>();

			// Workers
			builder.Services.AddTransient<WorkersViewModel>();

			return builder;
		}

		private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<AppShell>();

			// Accounts
			builder.Services.AddTransient<LoginPage>();
			builder.Services.AddTransient<RegisterPage>();

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
			builder.Services.AddTransient<OrderItemsPage>();
			builder.Services.AddTransient<AddOrderItemPage>();

			// Workers
			builder.Services.AddSingleton<WorkersPage>();


			return builder;
		}

		private static MauiAppBuilder RegisterFirebase(this MauiAppBuilder builder)
		{
			builder.ConfigureLifecycleEvents(events =>
			{
				events.AddAndroid(android => android.OnCreate((activity, bundle) => {
					Firebase.FirebaseApp.InitializeApp(activity);
				}));
			});	

			return builder;
		}
	}
}
