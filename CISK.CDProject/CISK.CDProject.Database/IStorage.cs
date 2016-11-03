using CISK.CDProject.Core;

namespace CISK.CDProject.Database
{
    public interface IStorage
    {
        int GetItemWareHouseStatus(IItem item);
    }
}
