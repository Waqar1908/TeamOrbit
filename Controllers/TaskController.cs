using Microsoft.AspNetCore.Mvc;
using TeamOrbit.Models;

namespace TeamOrbit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController:ControllerBase
    {

        public static readonly List<TaskItem> Tasks = new()
        {
             new TaskItem
                {
                    id=1,
                    title="leaning c#",
                    iscompleted = true
                },
                  new TaskItem
                {
                    id=2,
                    title="one step for full stack",
                    iscompleted = true
                }

        };



        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(Tasks);

        }
        [HttpGet("(id:int)")]
        public IActionResult GetTaskById(int id)
        {
            var taskid = Tasks.FirstOrDefault(t => t.id == id);
            if (taskid ==null)
            {
                return NotFound(); 
            }
            return Ok(taskid);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            task.id = Tasks.Count + 1;
            Tasks.Add(task);

            return CreatedAtAction(
                nameof(GetTaskById),
                new { id = task.id },
                task
            );
        }

    }
}
