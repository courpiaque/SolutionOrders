namespace ClientOrders.Helpers;

public class TokenKeeper
{
	private static readonly TokenKeeper _instance = new();
	public static TokenKeeper Current { get => _instance; }
	public String Token { get; set; }
}
