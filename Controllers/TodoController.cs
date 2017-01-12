using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity_framework_core_demo.DAL;
using entity_framework_core_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace entity_framework_core_demo.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private TodoContext context { get; set; }

        public TodoController()
        {
            this.context = new TodoContext();
        }

        [HttpGet]
        public IEnumerable<Todo> GetAllTodos()
        {
            return this.context.Todos;
        }

        [HttpPost]
        public void AddTodo(Todo newTodo)
        {
            this.context.Todos.Add(newTodo);
            this.context.SaveChangesAsync();
        }

        [HttpPost, Route("{todoId}/tag")]
        public void AddTag(int todoId, string tagTitle)
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
        }

        [HttpPost, Route("{todoId}/status")]
        public void UpdateStatus(int todoId, string statusTitle)
        {
            var todo = this.context.Todos.First(t => t.Id == todoId);
            var status = this.context.Statuses.First(s => s.Title == statusTitle);

            todo.Status = status;

            this.context.SaveChangesAsync();
        }

        [HttpDelete, Route("{todoId}")]
        public void DeleteTodo(int todoId)
        {
            var todo = this.context.Todos.First(t => t.Id == todoId);
            this.context.Todos.Remove(todo);
            this.context.SaveChangesAsync();
        }

        [HttpDelete, Route("finished")]
        public void DeleteFinishedTodos()
        {
            var todos = this.context.Todos.Where(t => t.Status.Title == "Finished");
            this.context.Todos.RemoveRange(todos);
            this.context.SaveChangesAsync();
        }
    }
}
