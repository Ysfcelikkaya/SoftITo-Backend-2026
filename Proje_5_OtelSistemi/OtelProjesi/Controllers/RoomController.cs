using Microsoft.AspNetCore.Mvc;
using OtelProjesi.Data;
using OtelProjesi.Models;

namespace OtelProjesi.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext context;

        public RoomController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult RoomList()
        {
            var data = context.Rooms.ToList();
            return new JsonResult(data);
        }
        [HttpPost]
        public JsonResult AddRoom(Room room)
        {
            var newRoom = new Room()
            {
                RoomNumber = room.RoomNumber,
                Type = room.Type,
                Price = room.Price,
                IsAvailable = room.IsAvailable
            };
            context.Rooms.Add(newRoom);
            context.SaveChanges();
            return new JsonResult("Oda başarıyla kaydedildi.");
        }

        public JsonResult Edit(int id)
        {
            var data = context.Rooms.Where(m => m.Id == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
            return new JsonResult("Oda güncellendi.");
        }
        public JsonResult Delete(int id)
        {
            var data = context.Rooms.Where(m => m.Id == id).SingleOrDefault();
            if (data != null)
            {
                context.Rooms.Remove(data);
                context.SaveChanges();
                return new JsonResult("Oda silindi.");
            }
            return new JsonResult("Oda bulunamadı.");
        }
    }
}