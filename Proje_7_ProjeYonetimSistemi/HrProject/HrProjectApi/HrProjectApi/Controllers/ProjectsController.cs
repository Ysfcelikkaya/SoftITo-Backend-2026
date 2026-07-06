using HrProjectApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public ProjectsController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetProjects")]
        public async Task<IEnumerable<Projects>> GetProjects()
        {
            return await dbcontext.Projects.ToListAsync();
        }
        [HttpGet]
        [Route("GetProjects/{id}")]
        public async Task<ActionResult<Projects>> GetProjectById(int id)
        {
            var project = await dbcontext.Projects.FindAsync(id);

            if (project == null)
                return NotFound();

            return project;
        }

        [HttpPost]
        [Route("AddProjects")]
        public async Task<ActionResult<Projects>> AddProjects(Projects project)
        {
            dbcontext.Projects.Add(project);
            await dbcontext.SaveChangesAsync();

            return project;
        }

        [HttpPut]
        [Route("UpdateProjects/{id}")]
        public async Task<IActionResult> UpdateProjects(int id, Projects project)
        {
            if (id != project.ProjectId)
                return BadRequest();

            dbcontext.Entry(project).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteProjects/{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            var project = await dbcontext.Projects.FindAsync(id);

            if (project == null)
                return NotFound();

            dbcontext.Projects.Remove(project);
            await dbcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
