namespace CISK.CDProject.Core.Food
{
    public class Pizza : IItem
    {
        private double _price = 100;
        private string _name = "Pizza";

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
