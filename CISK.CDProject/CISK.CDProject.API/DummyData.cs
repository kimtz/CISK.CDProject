using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CISK.CDProject.API.Models;

namespace CISK.CDProject.API
{
    public class DummyData
    {
        public static DummyData Current { get; } = new DummyData();
        public List<TestClass> testList { get; set; }

        public DummyData()
        {
            testList = new List<TestClass>()
            {
                new TestClass() { Id = 1, Name = "First", TestChilds = new List<TestChild>()
                {
                    new TestChild() {Description = "child1", Id = 1},
                    new TestChild() {Description = "child2", Id = 2}
                } },
                new TestClass() { Id = 2, Name = "Second", TestChilds = new List<TestChild>()
                {
                    new TestChild() {Description = "child3", Id = 3},
                    new TestChild() {Description = "child4", Id = 4}
                }}
            };
        }
    }
}
