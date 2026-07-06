using EmlakProjectORM.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjectORM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var propertyList = _unitOfWork.Property.GetAll(includeProperties: "PropertyType");
            return View(propertyList);
        }
    }
}