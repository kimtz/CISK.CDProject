namespace CISK.CDProject.Storage
{
    public interface IDatabaseItem
    {
        string GetName();
        int GetWareHouseStatus();
        void ChangeWareHouseStatus(int orderCount);
    }
}
