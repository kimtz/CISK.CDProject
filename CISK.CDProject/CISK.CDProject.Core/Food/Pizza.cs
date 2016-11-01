namespace CISK.CDProject.Core.Food
{
    public class Pizza : IItem
    {
        private double _price = 100;
        public int GetWareHouseStatus()
        {
            throw new System.NotImplementedException();
        }

        public double GetPrice()
        {
            return _price;
        }

        public void ChangeWareHouseStatus(int count)
        {
            throw new System.NotImplementedException();
        }
    }
}
