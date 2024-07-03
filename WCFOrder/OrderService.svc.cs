using System.Collections.Generic;
using System.Linq;
using WCFOrder.Model.Entities;

namespace WCFOrder
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderService.svc or OrderService.svc.cs at the Solution Explorer and start debugging.
    public class OrderService : IOrderService
    {
        public List<ItemForView> GetItems()
        {
            var db = new ModelOrder();
            var query = from item in db.Item select item;

            return query.ToList()
                .Select(item => new ItemForView(item))
                .ToList();
        }

        public List<ItemForView> GetItemSortByName()
        {
            var db = new ModelOrder();
            var query = from item in db.Item select item;
            query = query.OrderBy(item => item.Name);

            return query.ToList()
                .Select(item => new ItemForView(item))
                .ToList();
        }
    }
}

