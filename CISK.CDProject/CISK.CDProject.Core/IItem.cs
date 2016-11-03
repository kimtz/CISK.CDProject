namespace CISK.CDProject.Core
{
    public interface IItem
    {
        string GetName();
        int GetWareHouseStatus();
        double GetPrice();
        void ChangeWareHouseStatus(int count);
    }
}
