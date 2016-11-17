using System.Collections.Generic;
using CISK.CDProject.Core;
using Newtonsoft.Json;

namespace CISK.CDProject.API.Controllers
{
    public class CartController
    {
        private readonly Cart _cart = new Cart();

        public void Post(string item)
        {
            _cart.AddItem(JsonConvert.DeserializeObject<IItem>(item));   
        }

        public string Get()
        {
            return JsonConvert.SerializeObject(_cart.GetAllItems());
        }
    }
}
