using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext context;
        public TodosController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<TodosController>
        [HttpGet]
        public ActionResult<IEnumerable<TodosModel>> Get()
        {
            return Ok(context.Todos.ToList());
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public ActionResult<TodosModel?> Get(int id)
        {
            return Ok(context.Todos.FirstOrDefault(t => t.Id == id));
        }

        // POST api/<TodosController>
        [HttpPost]
        public IActionResult Post([FromBody] TodosModel todo)
        {
            List<TodosModel> todos = context.Todos.ToList();

            TodosModel? foundTodo = todos.FirstOrDefault(t => t.Title == todo.Title);

            if (foundTodo == null)
            {
                context.Todos.Add(todo);
                context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Todo already exists!");
            }
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodosModel todo)
        {
            List<TodosModel> todos = context.Todos.ToList();

            var newTodo = todos.FirstOrDefault(t => t.Id == todo.Id);
            if (newTodo == null)
            {
                return NotFound();
            }
            else
            {
                newTodo.Title = todo.Title;
                newTodo.Description = todo.Description;

                context.Update(newTodo);
                context.SaveChanges();

                return NoContent();
            }
        }

        //DELETE api/<TodosController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var todoToRemove = context.Todos.FirstOrDefault(t => t.Id == id);
        //    if (todoToRemove == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        context.Todos.ExecuteDelete(todoToRemove);

        //        return NoContent();
        //    }
        //}
    }
}
