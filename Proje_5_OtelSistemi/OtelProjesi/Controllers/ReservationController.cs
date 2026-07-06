using Microsoft.AspNetCore.Mvc;
using OtelProjesi.Data;
using OtelProjesi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OtelProjesi.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReservationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReservationList()
        {
            var data = context.Reservations
                .Include(r => r.Room)
                .Include(r => r.User)
                .Select(r => new
                {
                    id = r.Id,
                    roomNumber = r.Room != null ? r.Room.RoomNumber : 0,
                    userFullName = r.User != null ? r.User.FullName : "Bilinmeyen Müşteri",
                    checkInDate = r.CheckInDate.ToString("yyyy-MM-dd"),
                    checkOutDate = r.CheckOutDate.ToString("yyyy-MM-dd"),
                    totalPrice = r.TotalPrice
                }).ToList();

            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddReservation(Reservation reservation)
        {
            var room = context.Rooms.Find(reservation.RoomId);
            if (room != null)
            {
                int days = (reservation.CheckOutDate - reservation.CheckInDate).Days;
                if (days <= 0) days = 1;
                reservation.TotalPrice = room.Price * days;
                room.IsAvailable = false;
            }

            context.Reservations.Add(reservation);
            context.SaveChanges();
            return new JsonResult("Rezervasyon başarıyla oluşturuldu.");
        }
        public JsonResult Edit(int id)
        {
            var data = context.Reservations.Where(m => m.Id == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Reservation reservation)
        {
            context.Reservations.Update(reservation);
            context.SaveChanges();
            return new JsonResult("Rezervasyon güncellendi.");
        }

        public JsonResult Delete(int id)
        {
            var data = context.Reservations.Find(id);
            if (data != null)
            {
                var room = context.Rooms.Find(data.RoomId);
                if (room != null) { room.IsAvailable = true; }

                context.Reservations.Remove(data);
                context.SaveChanges();
                return new JsonResult("Rezervasyon silindi.");
            }
            return new JsonResult("Kayıt bulunamadı.");
        }
    }
}