using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity_framework_core_demo.DAL;
using entity_framework_core_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace entity_framework_core_demo.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private TodoContext context { get; set; }

        public TodoController(TodoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            return Ok(this.context.Todos
                .Include(t => t.Status)
                // TODO: this isn't working
                /*.Include(t => t.TodoTags).ThenInclude(t => t.Tag) */
                );
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] Todo newTodo)
        {
            newTodo.Status = this.context.Statuses.First(s => s.Title == "New");

            this.context.Todos.Add(newTodo);
            this.context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost, Route("{todoId}/tag")]
        public IActionResult AddTag(int todoId,[FromBody] string tagTitle)
        {
            var todo = this.context.Todos.First(t => t.Id == todoId);
            var tag = this.context.Tags.FirstOrDefault(t => t.Title == tagTitle);
            
            if (tag == null)
            {
                tag = new Tag { Title = tagTitle };
                this.context.Tags.Add(tag);
            }

            var todoTag = new TodoTag { Todo = todo, Tag = tag };
            this.context.TodoTags.Add(todoTag);

            this.context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost, Route("{todoId}/status")]
        public IActionResult UpdateStatus(int todoId,[FromBody] string statusTitle)
        {
            var todo = this.context.Todos.First(t => t.Id == todoId);
            var status = this.context.Statuses.First(s => s.Title == statusTitle);

            todo.Status = status;

            this.context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete, Route("{todoId}")]
        public IActionResult DeleteTodo(int todoId)
        {
            var todo = this.context.Todos.First(t => t.Id == todoId);
            this.context.Todos.Remove(todo);
            this.context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete, Route("finished")]
        public IActionResult DeleteFinishedTodos()
        {
            var todos = this.context.Todos.Where(t => t.Status.Title == "Finished");
            this.context.Todos.RemoveRange(todos);
            this.context.SaveChangesAsync();

            return Ok();
        }
    }
}
