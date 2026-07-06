using HrProjectApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public TasksController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetTasks")]
        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            return await dbcontext.Tasks.ToListAsync();
        }
        [HttpGet]
        [Route("GetTasks/{id}")]
        public async Task<ActionResult<Tasks>> GetTaskById(int id)
        {
            var task = await dbcontext.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            return task;
        }
        [HttpPost]
        [Route("AddTasks")]
        public async Task<ActionResult<Tasks>> AddTasks(Tasks task)
        {
            dbcontext.Tasks.Add(task);
            await dbcontext.SaveChangesAsync();
            return task;
        }

        [HttpPut]
        [Route("UpdateTasks/{id}")]
        public async Task<IActionResult> UpdateTasks(int id, Tasks task)
        {
            if (id != task.TaskId)
                return BadRequest();

            dbcontext.Entry(task).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete]
        [Route("DeleteTasks/{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            var task = await dbcontext.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            dbcontext.Tasks.Remove(task);
            await dbcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}

