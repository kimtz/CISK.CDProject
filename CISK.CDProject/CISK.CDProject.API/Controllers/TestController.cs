using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CISK.CDProject.API.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(DummyData.Current.testList);
        }

        [HttpGet("{Id}")]
        public IActionResult GetOne(int id)
        {
            var item = DummyData.Current.testList.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
