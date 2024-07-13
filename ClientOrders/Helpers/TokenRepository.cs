namespace ClientOrders.Helpers;

public class TokenRepository
{
	private static TokenRepository _instance;
	public static TokenRepository Current { get => _instance ??= new(); }
	public String Token { get; set; }
}
