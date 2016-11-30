using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CISK.CDProject.API.Controllers
{
    [Route("api/cart")]
    public class CartController : Controller
    {
        [HttpGet("getAllItems")]
        public IActionResult GetAllItems()
        {
            return Ok();
        }
    }
}
