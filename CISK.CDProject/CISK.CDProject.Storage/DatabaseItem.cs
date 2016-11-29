namespace CISK.CDProject.Storage
{
    public class DatabaseItem : IDatabaseItem
    {
        private readonly string _name;
        private int _wareHouseStatus;

        public DatabaseItem(string name, int wareHouseStatus)
        {
            _name = name;
            _wareHouseStatus = wareHouseStatus;
        }
        public string GetName()
        {
            return _name;
        }

        public int GetWareHouseStatus()
        {
            return _wareHouseStatus;
        }

        public void ChangeWareHouseStatus(int orderCount)
        {
            _wareHouseStatus = _wareHouseStatus - orderCount;
        }
    }
}
