using System;
using System.Collections.Generic;
using System.Linq;
//using CISK.CDProject.Storage;

namespace CISK.CDProject.Core
{
    public class OrderManager
    {
        //private IStorage _storage;
        public bool PlaceOrder(Dictionary<IItem, int> items)
        {
            var orderResult = new List<bool>();
            foreach (var item in items.Keys)
            {
                int count;
                var hej = items.TryGetValue(item, out count);
                if (IsInWareHouse(item, count))
                {
                    item.ChangeWareHouseStatus(count);
                    orderResult.Add(true);
                }
                orderResult.Add(false);
            }
            return orderResult.TrueForAll(x => x == true);
        }

        public void PlaceOrder(IEnumerable<IItem> items)
        {
            var sortedItemsList = items.GroupBy(item => item.GetName());
            foreach (var itemGroup in sortedItemsList)
            {
                var count = itemGroup.Count();
                if (IsInWareHouse(itemGroup.First(), count))
                {
                  //  _storage.ChangeItemWareHouseStatus(itemGroup.Key, count);
                }
            }
        }

        private bool IsInWareHouse(IItem item, int count)
        {
            return item.GetWareHouseStatus() - count >= 0;
        }
    }
}
