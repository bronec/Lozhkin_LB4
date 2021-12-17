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
            databasePath = Path.Combine(Directory.GetCurrentDirectory(), "UserDatabase.txt");
        }

        public void AddUser(UserModel item)
        {
            ExecuteQuery(x => x.Add(item), "Add user");
        }

        public UserModel GetUserById(int id)
        {
            UserModel user = null;
            ExecuteQuery(x => user = x.FirstOrDefault(x => x.Id == id), "Get user by Id");
            return user;
        }

        public void EditUser(int id, UserModel user)
        {
            ExecuteQuery(users =>
            {
                if (users.Any(x => x.Id == id))
                {
                    users.Remove(users.First(x => x.Id == id));
                    users.Add(user);
                }
            }, "Edit user");
        }

        public void RemoveUser(int id)
        {
            ExecuteQuery(users =>
            {
                if (users.Any(x => x.Id == id))
                {
                    users.Remove(users.First(x => x.Id == id));
                }
            }, "Remove user");
        }

        private void ExecuteQuery(Action<List<UserModel>> query, string actionName)
        {
            Console.WriteLine($"Executing operation with database. {actionName}");
            var users = GetUsers();
            query(users);
            SaveUsers(users);
        }

        private void SaveUsers(List<UserModel> users)
        {
            using (var fs = new FileStream(databasePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var strReader = new StreamWriter(fs))
            {
                var jsonWriter = new JsonTextWriter(strReader);

                JsonSerializer.CreateDefault().Serialize(jsonWriter, users);
            }
        }

        private List<UserModel> GetUsers()
        {
            var existing = new FileInfo(databasePath).Exists;
            using (var fs = new FileStream(Path.Combine(databasePath), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var strReader = new StreamReader(fs))
            {
                var jsonReader = new JsonTextReader(strReader);

                return existing
                    ? JsonSerializer.CreateDefault().Deserialize<List<UserModel>>(jsonReader)
                    : new List<UserModel>();
            }
        }
    }
}
