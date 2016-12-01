﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CISK.CDProject.API.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPatch("partiallyUpdateChild/{testClassId}/child/{childId}")]
        public IActionResult PartiallyUpdateTestChild(int testClassId, int childId, [FromBody] JsonPatchDocument<TestChildForUpdate> patchDocument)
        {
            if (patchDocument == null)
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

            var testChildToPatch = new TestChildForUpdate()
            {
                Description = testChildToUpdate.Description,
                Name = testChildToUpdate.Name
            };

            patchDocument.ApplyTo(testChildToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (testChildToPatch.Name == testChildToPatch.Description)
            {
                ModelState.AddModelError("Description", "Description can't be the same as name");
            }

            TryValidateModel(testChildToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            testChildToUpdate.Name = testChildToPatch.Name;
            testChildToUpdate.Description = testChildToPatch.Description;

            return NoContent();
        }

        [HttpDelete("partiallyUpdateChild/{testClassId}/child/{childId}")]
        public IActionResult DeleteTestChild(int testClassId, int childId)
        {

            var testClass = DummyData.Current.testList.FirstOrDefault(t => t.Id == testClassId);
            if (testClass == null)
            {
                return NotFound();
            }

            var testChildToDelete = testClass.TestChilds.FirstOrDefault(c => c.Id == childId);
            if (testChildToDelete == null)
            {
                return NotFound();
            }

            testClass.TestChilds.Remove(testChildToDelete);

            return NoContent();
        }
    }
}
