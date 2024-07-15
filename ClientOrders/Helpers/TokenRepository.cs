namespace ClientOrders.Helpers;

// Simple singleton class to store token value
public class TokenRepository
{
	private static TokenRepository _instance;
	public static TokenRepository Current { get => _instance ??= new(); }
	public String Token { get; set; }
}
