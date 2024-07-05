namespace ClientOrders.Services.Abstract
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string login, string password);

        Task<bool> RegisterAsync(string login, string password);
    }
}
