using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmlakProjectORM.Areas.User.Controllers
{
    [Area("User")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IUnitOfWork unitOfWork, ILogger<AppointmentController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var appointments = _unitOfWork.Appointment.GetAll(includeProperties: "Property,AppUser");
            return View(appointments);
        }

        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_unitOfWork.AppUser.GetAll(), "Id", "FullName");
            ViewBag.Properties = new SelectList(_unitOfWork.Property.GetAll(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            _unitOfWork.Appointment.Add(appointment);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var appointment = _unitOfWork.Appointment.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Appointment.Remove(appointment);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}