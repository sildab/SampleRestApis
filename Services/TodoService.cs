using SampleRestApis.Data;
using SampleRestApis.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SampleRestApis.Services;

public class TodoService : ITodoService
{
    private readonly MyDbContext _context;
    private readonly ILogger _logger;
    public TodoService(MyDbContext context, ILogger<TodoService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        _logger.LogInformation("Getting To-do list from In-memory database at {DT}",
            DateTime.UtcNow.ToLongTimeString());
        return await _context.Todo.ToListAsync();
    }

    public async Task<Todo> GetTodoAsync(long id)
    {
        var item = await _context.Todo.Where(x=>x.Id == id).FirstOrDefaultAsync();
       
        return item;
    }
    public async Task SaveAsync(Todo newTodo)
    {
        _logger.LogInformation("Adding To-do to In-memory database at {DT}",
           DateTime.UtcNow.ToLongTimeString());
        _context.Todo.Add(newTodo);
        await _context.SaveChangesAsync();
    }
}
