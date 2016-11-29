using System.Collections.Generic;

namespace CISK.CDProject.Storage
{
    public interface IStorage
    {
        IEnumerable<IDatabaseItem> GetAllItems();
        IDatabaseItem GetItemByName(string name);
        int GetItemWareHouseStatus(string name);
        void ChangeItemWareHouseStatus(string name, int count);
    }
}
