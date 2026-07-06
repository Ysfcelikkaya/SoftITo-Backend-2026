using Microsoft.AspNetCore.Mvc;
using OtelProjesi.Data;
using OtelProjesi.Models;

namespace OtelProjesi.Controllers
{
    public class UserController : Controller
    {
 
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult UserList()
        {
            var data = context.Users.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddUser(User user)
        {
            var newUser = new User()
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            context.Users.Add(newUser);
            context.SaveChanges();
            return new JsonResult("Kullanıcı başarıyla kaydedildi.");
        }

        public JsonResult Edit(int id)
        {
            var data = context.Users.Where(m => m.Id == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(User user)
        {
            context.Update(user);
            context.SaveChanges();
            return new JsonResult("Kullanıcı bilgileri güncellendi.");
        }

        public JsonResult Delete(int id)
        {
            var data = context.Users.Where(m => m.Id == id).SingleOrDefault();
            if (data != null)
            {
                context.Users.Remove(data);
                context.SaveChanges();
                return new JsonResult("Kullanıcı silindi.");
            }
            return new JsonResult("Kullanıcı bulunamadı.");
        }
    }
}