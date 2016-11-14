using System.Collections.Generic;

namespace CISK.CDProject.Core
{
    public class Cart
    {
        private readonly List<IItem> _itemsList = new List<IItem>();

        public void AddItem(IItem item)
        {
            _itemsList.Add(item);
        }

        public IEnumerable<IItem> GetAllItems()
        {
            return _itemsList;
        } 
    }
}
