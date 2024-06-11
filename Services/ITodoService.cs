using MauiBlazorHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorHybrid.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTodo();
        Task<int> AddTodo(Todo todo);
        Task<int> UpdateTodo(Todo todo);
        Task<int> DeleteTodo(Todo todo);
    }
}
