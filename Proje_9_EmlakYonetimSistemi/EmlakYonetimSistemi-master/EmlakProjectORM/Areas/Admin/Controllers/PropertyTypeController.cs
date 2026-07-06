using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmlakProjectORM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<PropertyType> types = _unitOfWork.PropertyType.GetAll();
            return View(types);
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public IActionResult Create(PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PropertyType.Add(propertyType);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(propertyType);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0) { return NotFound(); }
            var type = _unitOfWork.PropertyType.GetFirstOrDefault(x => x.Id == id);
            return View(type);
        }

        [HttpPost]
        public IActionResult Edit(PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PropertyType.Update(propertyType);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(propertyType);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0) { return NotFound(); }
            var type = _unitOfWork.PropertyType.GetFirstOrDefault(x => x.Id == id);
            _unitOfWork.PropertyType.Remove(type);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}