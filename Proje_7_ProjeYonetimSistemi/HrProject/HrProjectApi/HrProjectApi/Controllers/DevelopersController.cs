using HrProjectApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public DevelopersController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("GetDevelopers")]
        public async Task<IEnumerable<Developers>> GetDevelopers()
        {
            return await dbcontext.Developers.ToListAsync();
        }

        [HttpGet]
        [Route("GetDevelopersById/{id}")]
        public async Task<Developers> GetDevelopersById(int id)
        {
            return await dbcontext.FindAsync<Developers>(id);
        }

        [HttpPost]
        [Route("AddDevelopers")]
        public async Task<ActionResult<Developers>> AddDeveloper(Developers developers)
        {
            dbcontext.Add(developers);
            await dbcontext.SaveChangesAsync();

            return developers;
        }

        [HttpPut]
        [Route("UpdateDevelopers")]
        public async Task<ActionResult<Developers>> UpdateDevelopers(Developers developers)
        {
            dbcontext.Update(developers);
            await dbcontext.SaveChangesAsync();
            return developers;
        }

        [HttpDelete]
        [Route("DeleteDevelopers/{id}")]
        public bool DeleteDeveloper(int id)
        {
            var islem = false;
            var result = dbcontext.Developers.Find(id);
            if (result != null)
            {
                islem = true;
                dbcontext.Remove(result);
                dbcontext.SaveChanges();
            }
            else
            {
                return islem;
            }
            return islem;
        }
    }
}

