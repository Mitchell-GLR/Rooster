using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rooster.Models;

namespace Rooster.Data
{
    public class Database
    {
        private static SQLiteAsyncConnection _database;

        public static async Task<SQLiteAsyncConnection> GetDatabase()
        {
            if (_database == null)
            {
                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Rooster.db");
                _database = new SQLiteAsyncConnection(databasePath);

                await _database.CreateTableAsync<Vak>();
                await _database.CreateTableAsync<Docent>();
                await _database.CreateTableAsync<Dag>();
                await _database.CreateTableAsync<Lokaal>();
                await _database.CreateTableAsync<Les>();
            }
            return _database;
        }
    }

}
