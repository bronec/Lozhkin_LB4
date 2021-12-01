using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lozhkin_LB4.Models
{
    public class TextFileDatabase
    {
        private string databasePath = "";
        public TextFileDatabase()
        {
            databasePath = Path.Combine(Directory.GetCurrentDirectory(), "UsersDatabase.txt");
        }

        private List<UsersModel> GetUsers()
        {
            var existing = new FileInfo(databasePath).Exists;
            using (var fs = new FileStream(Path.Combine(databasePath), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var strReader = new StreamReader(fs))
            {
                var jsonReader = new JsonTextReader(strReader);

                return existing
                    ? JsonSerializer.CreateDefault().Deserialize<List<UsersModel>>(jsonReader)
                    : new List<UsersModel>();
            }
        }


        public UsersModel GetUsersId(int id)
        {
            UsersModel product = null;
            ExecuteQuery(x => product = x.FirstOrDefault(x => x.Id == id),"Get product by Id");
            return product;
        }
        private void SaveUsers(List<UsersModel> products)
        {
            using (var fs = new FileStream(databasePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var strReader = new StreamWriter(fs))
            {
                var jsonWriter = new JsonTextWriter(strReader);

                JsonSerializer.CreateDefault().Serialize(jsonWriter, products);
            }
        }
        public void EditUsers(int id, UsersModel product)
        {
            ExecuteQuery(products =>
            {
                if (products.Any(x => x.Id == id))
                {
                    products.Remove(products.First(x => x.Id == id));
                    products.Add(product);
                }
            }, "Edit product");
        }
        public void AddUsers(UsersModel item)
        {
            ExecuteQuery(x => x.Add(item), "Add product");
        }
        public void RemoveUsers(int id)
        {
            ExecuteQuery(products =>
            {
                if (products.Any(x => x.Id == id))
                {
                    products.Remove(products.First(x => x.Id == id));
                }
            }, "Remove product");
        }

        private void ExecuteQuery(Action<List<UsersModel>> query, string actionName)
        {
            Console.WriteLine($"Executing operation with database. {actionName}");
            var products = GetUsers();
            query(products);
            SaveUsers(products);
        }
    }
}
