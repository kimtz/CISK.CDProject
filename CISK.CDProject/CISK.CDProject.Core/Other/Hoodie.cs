﻿namespace CISK.CDProject.Core.Other
{
    public class Hoodie : IItem
    {
        private double _price = 300;
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