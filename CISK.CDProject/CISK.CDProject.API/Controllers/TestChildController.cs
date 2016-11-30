using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CISK.CDProject.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CISK.CDProject.API.Controllers
{
    [Route("api/cart")]
    public class TestChildController : Controller
    {
        [HttpGet("{testClassId}/childs")]
        public IActionResult GetChilds(int testClassId)
        {
            var testClass = DummyData.Current.testList.FirstOrDefault(t => t.Id == testClassId);
            if (testClass == null)
            {
                return NotFound();
            }
            return Ok(testClass.TestChilds);
        }

        [HttpGet("{testClassId}/child/{childId}", Name = "GetChild")]
        public IActionResult GetChild(int testClassId, int childId)
        {
            var testClass = DummyData.Current.testList.FirstOrDefault(t => t.Id == testClassId);
            if (testClass == null)
            {
                return NotFound();
            }

            var child = testClass.TestChilds.FirstOrDefault(c => c.Id == childId);
            if (child == null)
            {
                return NotFound();
            }

            return Ok(child);
        }

        [HttpPost("createChild/{testClassId}")]
        public IActionResult CreateChild(int testClassId, 
            [FromBody] TestChildForCreation testChild)
        {
            if (testChild == null)
            {
                return BadRequest();
            }

            if (testChild.Description == testChild.Name)
            {
                ModelState.AddModelError("Description", "The name and desciption can't be the same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var testClass = DummyData.Current.testList.FirstOrDefault(t => t.Id == testClassId);
            if (testClass == null)
            {
                return NotFound();
            }

            var maxTestChildId = DummyData.Current.testList.SelectMany(t => t.TestChilds).Max(c => c.Id);
            var finalTestChild = new TestChild()
            {
                Id = ++maxTestChildId,
                Description = testChild.Description
            };
            testClass.TestChilds.Add(finalTestChild);

            return CreatedAtRoute("GetChild", new
            {
                testClassId = testClassId,
                childId = finalTestChild.Id
            }, finalTestChild);
        }

        [HttpPut("updateChild/{testClassId}/child/{childId}")]
        public IActionResult UpdateTestChild(int testClassId, int childId, [FromBody] TestChildForUpdate testChild)
        {
            if (testChild == null)
            {
                return BadRequest();
            }

            if (testChild.Description == testChild.Name)
            {
                ModelState.AddModelError("Description", "The name and desciption can't be the same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var testClass = DummyData.Current.testList.FirstOrDefault(t => t.Id == testClassId);
            if (testClass == null)
            {
                return NotFound();
            }

            var testChildToUpdate = testClass.TestChilds.FirstOrDefault(c => c.Id == childId);
            if (testChildToUpdate == null)
            {
                return NotFound();
            }

            testChildToUpdate.Name = testChild.Name;
            testChildToUpdate.Description = testChild.Description;

            return NoContent();
        }
    }
}
