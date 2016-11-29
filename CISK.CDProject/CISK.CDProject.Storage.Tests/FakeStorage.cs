using System.Collections.Generic;
using System.Linq;

namespace CISK.CDProject.Storage.Tests
{
    public class FakeStorage : IStorage
    {
        private List<IDatabaseItem> _items; 
        public FakeStorage()
        {
            _items = new List<IDatabaseItem>();
        }

        public void Add(IDatabaseItem item)
        {
            _items.Add(item);
        }

        public IEnumerable<IDatabaseItem> GetAllItems()
        {
            return _items;
        }

        public IDatabaseItem GetItemByName(string name)
        {
            return _items.First(x => Equals(x.GetName(), name));
        }

        public int GetItemWareHouseStatus(string name)
        {
            return _items.First(x => Equals(x.GetName(), name)).GetWareHouseStatus();
        }

        public void ChangeItemWareHouseStatus(string name, int count)
        {
            var item = _items.First(x => Equals(x.GetName(), name));
            item.ChangeWareHouseStatus(count);
        }
    }
}
