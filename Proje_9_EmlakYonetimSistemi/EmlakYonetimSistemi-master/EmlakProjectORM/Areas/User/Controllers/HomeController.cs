using EmlakProjectORM.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjectORM.Areas.User.Controllers
{
    [Area("User")]
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
        [HttpGet]
        public IActionResult GenerateQr(int id)
        {
            string ilanUrl = $"{Request.Scheme}://{Request.Host}/User/Home/Details/{id}";

            using (QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator())
            {
                QRCoder.QRCodeData qrCodeData = qrGenerator.CreateQrCode(ilanUrl, QRCoder.QRCodeGenerator.ECCLevel.Q);
                using (QRCoder.PngByteQRCode qrCode = new QRCoder.PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeImage = qrCode.GetGraphic(20);
                    return Content("data:image/png;base64," + Convert.ToBase64String(qrCodeImage));
                }
            }
        }
    }
}