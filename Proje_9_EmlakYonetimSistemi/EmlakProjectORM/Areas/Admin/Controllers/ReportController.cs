using EmlakProjectORM.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmlakProjectORM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // 1. Sayfa İlk Açıldığında
        [HttpGet]
        public IActionResult Index()
        {
            // Combobox dolsun diye emlak tiplerini ekrana gönderiyoruz
            ViewBag.PropertyTypes = new SelectList(_unitOfWork.PropertyType.GetAll(), "Id", "TypeName");
            return View();
        }

        // 2. Raporla Butonuna Basıldığında (YENİ: propertyTypeId parametresi eklendi)
        [HttpPost]
        public IActionResult Index(decimal? minPrice, decimal? maxPrice, string sortOrder, int? propertyTypeId)
        {
            // Butona basılınca combobox boşalmasın diye tekrar gönderiyoruz
            ViewBag.PropertyTypes = new SelectList(_unitOfWork.PropertyType.GetAll(), "Id", "TypeName");

            var properties = _unitOfWork.Property.GetAll(includeProperties: "PropertyType");

            // --- YENİ EKLENEN EMLAK TİPİ FİLTRESİ ---
            if (propertyTypeId != null && propertyTypeId > 0)
            {
                properties = properties.Where(x => x.PropertyTypeId == propertyTypeId);
            }

            // Fiyat Filtreleri
            if (minPrice != null && minPrice > 0)
            {
                properties = properties.Where(x => x.Price >= minPrice);
            }

            if (maxPrice != null && maxPrice > 0)
            {
                properties = properties.Where(x => x.Price <= maxPrice);
            }

            // Sıralama
            if (sortOrder == "price_desc")
            {
                properties = properties.OrderByDescending(x => x.Price);
            }
            else if (sortOrder == "price_asc")
            {
                properties = properties.OrderBy(x => x.Price);
            }

            return View(properties);
        }
    }
}