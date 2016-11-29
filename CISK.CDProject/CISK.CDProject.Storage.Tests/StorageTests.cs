using System.Linq;
using NUnit.Framework;

namespace CISK.CDProject.Storage.Tests
{
    [TestFixture]
    public class StorageTests
    {
        private FakeStorage _storage = new FakeStorage();
        [SetUp]
        public void SetUp()
        {
            _storage.Add(new DatabaseItem("Pizza", 5));
            _storage.Add(new DatabaseItem("Cheese", 10));
        }

        [TearDown]
        public void TearDown()
        {
            _storage = new FakeStorage();
        }

        [Test]
        public void GetAllItems_Should_Return_List_Of_Items_With_Count_Two()
        {
            var result = _storage.GetAllItems();
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetItemByName_Should_Return_Correct_Item()
        {
            var desiredResult = new DatabaseItem("Pizza", 5);
            var result = _storage.GetItemByName("Pizza");
            Assert.AreEqual(desiredResult.GetName(), result.GetName());
        }

        [Test]
        public void GetItemWareHouseStatus_Should_Return_Ten()
        {
            var result = _storage.GetItemWareHouseStatus("Cheese");
            Assert.AreEqual(10, result);
        }

        [Test]
        public void ChangeItemWareHouseStatus_Should_Change_Correct()
        {
            var orderCount = 3;
            _storage.ChangeItemWareHouseStatus("Cheese", orderCount);
            var result = _storage.GetItemWareHouseStatus("Cheese");
            Assert.AreEqual(7, result);
        }
    }
}
