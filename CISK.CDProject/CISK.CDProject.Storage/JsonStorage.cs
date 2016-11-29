using System.Collections.Generic;
using System.IO;
using System.Linq;
using Raven.Imports.Newtonsoft.Json;

namespace CISK.CDProject.Storage
{
    public class JsonStorage : IStorage
    {
        public JsonStorage()
        {
            if (!StorageExists)
                Save(new List<IDatabaseItem>());
        }

        public IEnumerable<IDatabaseItem> GetAllItems()
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<IDatabaseItem>>(File.ReadAllText(FilePath));
            return items;
        } 

        public IDatabaseItem GetItemByName(string name)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<IDatabaseItem>>(File.ReadAllText(FilePath));
            return items.First(x => Equals(x.GetName(), name));
        }

        public int GetItemWareHouseStatus(string name)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<IDatabaseItem>>(File.ReadAllText(FilePath));
            return items.First(x => Equals(x.GetName(), name)).GetWareHouseStatus();
        }

        public void ChangeItemWareHouseStatus(string name, int count)
        {
            var items = JsonConvert.DeserializeObject<List<IDatabaseItem>>(File.ReadAllText(FilePath));
            var itemToChange = items.First(x => Equals(x.GetName(), name));
            itemToChange.ChangeWareHouseStatus(count);
            items.Add(itemToChange);
            Save(items);
        }

        //public IEnumerable<Movie> GetAll()
        //{
        //    return JsonConvert.DeserializeObject<IEnumerable<Movie>>(File.ReadAllText(FilePath));
        //}

        //public void Add(Movie movie)
        //{
        //    var movies = GetAll().ToList();
        //    if (!movies.Contains(movie))
        //    {
        //        movies.Add(movie);
        //        Save(movies);
        //    }
        //}

        //public void Remove(Movie movie)
        //{
        //    var movies = GetAll().ToList();
        //    if (movies.Contains(movie))
        //    {
        //        movies.Remove(movie);
        //        Save(movies);
        //    }
        //    else
        //    {
        //        throw new System.ArgumentException("The movie does not exist");
        //    }
        //}

        private static bool StorageExists => File.Exists(FilePath);

        private static string FilePath => "C:/Users/kim.tengbom/Documents/Storage/storage.txt";

        private static void Save(IEnumerable<IDatabaseItem> items)
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(items));
        }
    }
}
