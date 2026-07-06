using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace EmlakProjectORM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, ILogger<PropertyController> logger)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var propertyList = _unitOfWork.Property.GetAll(includeProperties: "PropertyType");

            _logger.LogInformation("Toplam {Count} adet İLAN veri tabanından listelendi.", propertyList.Count());

            return View(propertyList);
        }

        public IActionResult Crup(int? id = 0)
        {
            PropertyVM propertyVM = new()
            {
                Property = new(),
                PropertyTypeList = _unitOfWork.PropertyType.GetAll().Select(x => new SelectListItem
                {
                    Text = x.TypeName,
                    Value = x.Id.ToString()
                })
            };

            if (id == null || id <= 0) { return View(propertyVM); }

            propertyVM.Property = _unitOfWork.Property.GetFirstOrDefault(x => x.Id == id);
            if (propertyVM.Property == null) { return View(propertyVM); }

            return View(propertyVM);
        }

        [HttpPost]
        public IActionResult Crup(PropertyVM propertyVM, IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\properties");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot)) { Directory.CreateDirectory(uploadRoot); }

                if (propertyVM.Property.Photo != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath, propertyVM.Property.Photo.TrimStart('\\'));
                    if (System.IO.File.Exists(oldPicPath)) { System.IO.File.Delete(oldPicPath); }
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                propertyVM.Property.Photo = @"\img\properties\" + fileName + extension;
            }

            if (propertyVM.Property.Id <= 0) { _unitOfWork.Property.Add(propertyVM.Property); }
            else { _unitOfWork.Property.Update(propertyVM.Property); }

            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0) { return NotFound(); }
            var property = _unitOfWork.Property.GetFirstOrDefault(x => x.Id == id);
            _unitOfWork.Property.Remove(property);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}