
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TodoListApp.API.Data;
using TodoListApp.API.Models;

namespace TodoListApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListRepository _repo;
        private readonly IConfiguration _config;
        public TodoListController(ITodoListRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Post(int userId, TodoList todoList)
        {
            try
            {
                var newTodoList = await _repo.CreateTodoList(userId, todoList);

                if (newTodoList == null)
                    return BadRequest("User does not exist");

                return Ok(newTodoList);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}