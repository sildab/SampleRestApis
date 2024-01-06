
using SampleRestApis.Data.Entities;

namespace SampleRestApis.Services;

public interface ITodoService
{
    Task<List<Todo>> GetAllAsync();
    Task<Todo> GetTodoAsync(long id);
    Task SaveAsync(Todo newTodo);
}