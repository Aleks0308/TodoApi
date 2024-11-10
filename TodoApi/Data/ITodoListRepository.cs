using TodoApi.Models;

namespace TodoApi.Data
{
    public interface ITodoListRepository
    {
        Task<TodoItem> CreateTodoItem(TodoItem todoItem);
        void DeleteTodoItem(TodoItem todoItem);
        Task<TodoItem?> GetTodoItem(long id);
        Task<List<TodoItem>> GetTodoItems();
        bool TodoItemExists(long id);
        Task UpdateTodoItem(long id, TodoItem todoItem);
    }
}
