using ClientOrders.Models.Abstract;

namespace ClientOrders.Services.Abstract
{
    public interface ILookupService
    {
        Task<IEnumerable<T>> GetLookupsAsync<T>() where T : ILookup;
    }
}
