using ClientOrders.Services.Abstract;
using Firebase.Analytics;

namespace ClientOrders.Services;

public class AnalyticsService : IAnalyticsService
{
	public void Log(string eventName)
	{
		var firebaseAnalytics = FirebaseAnalytics.GetInstance(Platform.CurrentActivity);
		firebaseAnalytics.LogEvent(eventName, null);
	}
}
