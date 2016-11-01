namespace CISK.CDProject.Core.PillsAndMedicine
{
    public class Alvedon : IItem
    {
        private double _price = 50;
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
