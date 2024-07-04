using System.Collections.Generic;
using System.Threading.Tasks;
using ClientOrders.Models.Abstract;

namespace ClientOrders.Services.Abstract
{
    /// <summary>
    /// Represent object for handling cache and CRUD operations with using service connection.
    /// </summary>
    /// <typeparam name="T">type of your model.</typeparam>
    public interface ICrudService
    {
        /// <summary>
        /// Managing adding item to the service and handling cache.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> AddItemAsync<T>(T item) where T : IEntity;
        /// <summary>
        /// Managing updating item to the service and handling cache.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync<T>(T item) where T : IEntity;
        /// <summary>
        /// Managing deleting item to the service and handling cache.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync<T>(int id) where T : IEntity;
        /// <summary>
        /// Managing getting item from cache.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<T> GetItemAsync<T>(int id) where T : IEntity;
        /// <summary>
        /// Invoking refresh with force refresh flag
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync<T>(bool forceRefresh = false) where T : IEntity;
    }
}
