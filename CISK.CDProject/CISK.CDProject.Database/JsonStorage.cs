using System.Collections.Generic;
using System.IO;
using System.Linq;
using CISK.CDProject.Core;
using Raven.Imports.Newtonsoft.Json;

namespace CISK.CDProject.Database
{
    public class JsonStorage : IStorage
    {
        public JsonStorage()
        {
            if (!StorageExists)
                Save(new List<IItem>());
        }

        public IItem GetItem(IItem item)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<IItem>>(File.ReadAllText(FilePath));
            return items.First(x => Equals(x.GetName(), item.GetName()));
        }

        public int GetItemWareHouseStatus(IItem item)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<IItem>>(File.ReadAllText(FilePath));
            return items.First(x => Equals(x.GetName(), item.GetName())).GetWareHouseStatus();
        }

        public void ChangeItemWareHouseStatus(IItem item, int count)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<IItem>>(File.ReadAllText(FilePath));
            var newWareHouseStatus = items.First(x => Equals(x.GetName(), item.GetName())).GetWareHouseStatus() - count;
            item.ChangeWareHouseStatus(newWareHouseStatus);
            //Save(newItem);
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

        private static void Save(IEnumerable<IItem> movies)
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(movies));
        }
    }
}
