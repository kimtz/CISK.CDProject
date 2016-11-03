namespace CISK.CDProject.Core.PillsAndMedicine
{
    public class Resorb : IItem
    {
        private double _price = 70;
        private string _name = "Resorb";

        public string GetName()
        {
            return _name;
        }

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
