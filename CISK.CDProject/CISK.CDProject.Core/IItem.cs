namespace CISK.CDProject.Core
{
    public interface IItem
    {
        int GetWareHouseStatus();
        double GetPrice();
        void ChangeWareHouseStatus(int count);
    }
}
