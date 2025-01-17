using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using IncomeExpenseTracker.Models;

namespace IncomeExpenseTracker.Data
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LoginModel>().Wait();
            _database.CreateTableAsync<TransRecord>().Wait();
        }
        public Task<int> AddTransactionAsync(TransRecord item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> ClearDebtAsync(TransRecord item)
        {
            item.IsDebtCleared = true;
            return _database.UpdateAsync(item);
        }
        public Task<List<TransRecord>> GetAllTransactionAsync()
        {
            return _database.Table<TransRecord>().ToListAsync();
        }
        public Task<int> AddUserAsync(LoginModel item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> LoginUserAsync()
        {
            LoginModel item = GetUserAsync().Result;
            item.IsLoggedIn = true;
            return _database.UpdateAsync(item);
        }
        public Task<int> LogoutUserAsync()
        {
            LoginModel item = GetUserAsync().Result;
            item.IsLoggedIn = false;
            return _database.UpdateAsync(item);
        }
        public Task<LoginModel> GetUserAsync()
        {
            return _database.Table<LoginModel>().FirstOrDefaultAsync();
        }
    }
}
