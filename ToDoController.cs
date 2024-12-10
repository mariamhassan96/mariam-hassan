using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Model;

namespace ToDoListAPI.Controller
{
    

    
        [ApiController]
        [Route("api/[controller]")]
    public class ToDoController : ControllerBase, IToDoController, IToDoController1
        {
            private static List<ToDoItem> ToDoItems = new List<ToDoItem>
    {
        new ToDoItem { Id = 1, Title = "Learn ASP.NET Core", IsCompleted = false },
        new ToDoItem { Id = 2, Title = "Prepare for Interview", IsCompleted = true }
    };

            // Get All To-Do Items
            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(ToDoItems);
            }

            // Get a Single To-Do Item
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var item = ToDoItems.FirstOrDefault(x => x.Id == id);
                if (item == null) return NotFound(new { message = "Item not found" });
                return Ok(item);
            }

            // Add a New To-Do Item
            [HttpPost]
            public IActionResult Create(ToDoItem newItem)
            {
                newItem.Id = ToDoItems.Count + 1;
                ToDoItems.Add(newItem);
                return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
            }

            // Update an Existing To-Do Item
            [HttpPut("{id}")]
            public IActionResult Update(int id, ToDoItem updatedItem)
            {
                var item = ToDoItems.FirstOrDefault(x => x.Id == id);
                if (item == null) return NotFound(new { message = "Item not found" });

                item.Title = updatedItem.Title;
                item.IsCompleted = updatedItem.IsCompleted;
                return NoContent();
            }

            // Delete a To-Do Item
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var item = ToDoItems.FirstOrDefault(x => x.Id == id);
                if (item == null) return NotFound(new { message = "Item not found" });

                ToDoItems.Remove(item);
                return NoContent();

            }
    }

