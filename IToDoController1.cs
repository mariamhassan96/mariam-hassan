using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Model;

namespace ToDoListAPI.Controller
{
    public interface IToDoController1
    {
        IActionResult Create(ToDoItem newItem);
        IActionResult Delete(int id);
        IActionResult GetAll();
        IActionResult GetById(int id);
        IActionResult Update(int id, ToDoItem updatedItem);
    }
}