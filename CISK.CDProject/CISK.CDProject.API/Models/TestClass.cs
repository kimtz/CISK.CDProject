using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CISK.CDProject.API.Models
{
    public class TestClass
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int NbrChilds => TestChilds.Count();

        public ICollection<TestChild> TestChilds { get; set; } = new List<TestChild>();
    }
}
