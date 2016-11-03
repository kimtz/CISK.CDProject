using CISK.CDProject.Core;

namespace CISK.CDProject.Storage
{
    public interface IStorage
    {
        int GetItemWareHouseStatus(IItem item);
    }
}
