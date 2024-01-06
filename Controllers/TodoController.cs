using SampleRestApis.Data.Entities;
using SampleRestApis.Services;
using Microsoft.AspNetCore.Mvc;

namespace SampleRestApis.Controllers;


[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly ILogger _logger;
    public TodoController(ITodoService todoService, ILogger<TodoController> logger)
    {
        _todoService = todoService;
        _logger = logger;
    }
    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {

        _logger.LogInformation("/GetAllAsync called at {DT}",
            DateTime.UtcNow.ToLongTimeString());
        var result = await _todoService.GetAllAsync();
        //throw new Exception("Text Exception!!");
        if (result.Count == 0)
        {
            return NoContent();
        }
        return Ok(result);

    }

    [Route("get-by-id")]
    [HttpGet]
    public async Task<IActionResult> GetAsync(int id) 
    {
        try
        {
            var result = await _todoService.GetTodoAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"/GetById - Something went wrong: {ex}");
            return StatusCode(500, "Internal Server Error");
        }
       
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> SaveAsync(Todo newTodo)
    {
        _logger.LogInformation("/SaveAsync called at {DT}",
            DateTime.UtcNow.ToLongTimeString());
        await _todoService.SaveAsync(newTodo);
        return Ok();

    }
}
