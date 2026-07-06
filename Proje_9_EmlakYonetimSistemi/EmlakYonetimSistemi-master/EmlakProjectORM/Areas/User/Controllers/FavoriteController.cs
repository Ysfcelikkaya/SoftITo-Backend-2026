using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmlakProjectORM.Areas.User.Controllers
{
    [Area("User")]
    public class FavoriteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var favorites = _unitOfWork.Favorite.GetAll(includeProperties: "Property,AppUser");
            return View(favorites);
        }

        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_unitOfWork.AppUser.GetAll(), "Id", "FullName");
            ViewBag.Properties = new SelectList(_unitOfWork.Property.GetAll(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Favorite favorite)
        {
            _unitOfWork.Favorite.Add(favorite);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var favorite = _unitOfWork.Favorite.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Favorite.Remove(favorite);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}