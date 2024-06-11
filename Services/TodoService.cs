using MauiBlazorHybrid.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorHybrid.Services
{
    public class TodoService : ITodoService
    {
        private SQLiteAsyncConnection _connection;

        public TodoService()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "Todo_DB.db3");
            Debug.WriteLine("Database Path: " + path);
            _connection = new SQLiteAsyncConnection(path);
            SetUpTable();

        }

        private async void SetUpTable()
        {
            if(_connection != null)
            {
                await _connection.CreateTableAsync<Todo>();
            }
        }

        public async Task<List<Todo>> GetAllTodo()
        {
            try
            {
                var todoList = await _connection.Table<Todo>().ToListAsync();
                return todoList;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to fetch Todos from Database", ex);
            }
        }

        public async Task<int> AddTodo(Todo todo)
        {
            try
            {
               return await _connection.InsertAsync(todo);
            }
            catch (Exception ex) { 
                throw new ArgumentException("Failed to add Todo", ex);
            }
        }

        public async Task<int> DeleteTodo(Todo todo)
        {
            try
            {
                return await _connection.DeleteAsync(todo);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to remove Todo", ex);
            }
        }
        public async Task<int> UpdateTodo(Todo todo)
        {
            try
            {
                return await _connection.UpdateAsync(todo);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to update Todo", ex);
            }
        }

    }
}
