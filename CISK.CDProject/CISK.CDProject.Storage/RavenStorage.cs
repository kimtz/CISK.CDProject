using CISK.CDProject.Core;
using Raven.Client.Document;

namespace CISK.CDProject.Storage
{
    public class RavenStorage
    {

        private DocumentStore documentStore = new DocumentStore
        {
            Url = "http://localhost:8080",
            DefaultDatabase = "HangoverShop"
        };

        public void InitializeDatabase()
        {
            documentStore.Initialize();
        }

        public void SaveNewWareHouseStatus(IItem item, int count)
        {
            using (var session = documentStore.OpenSession())
            {

                session.Store(item);
                session.SaveChanges();
            }
        }
    }
}
