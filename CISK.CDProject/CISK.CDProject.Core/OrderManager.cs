using System.Collections.Generic;

namespace CISK.CDProject.Core
{
    public class OrderManager
    {
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

        private bool IsInWareHouse(IItem item, int count)
        {
            return item.GetWareHouseStatus() - count >= 0;
        }
    }
}
