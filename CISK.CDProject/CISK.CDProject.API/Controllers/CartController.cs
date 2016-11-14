using System.Collections.Generic;
using CISK.CDProject.Core;

namespace CISK.CDProject.API.Controllers
{
    public class CartController
    {
        private readonly Cart _cart = new Cart();

        public void Post(IItem item)
        {
            _cart.AddItem(item);   
        }

        public IEnumerable<IItem> Get()
        {
            return _cart.GetAllItems();
        }
    }
}
