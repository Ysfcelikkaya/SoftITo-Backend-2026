using DbFirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFirstProject.Controllers
{
    public class SearchController : Controller
    {
            private readonly AppDbContext db;

            public SearchController(AppDbContext db)
            {
                this.db = db;
            }

            public IActionResult Index(string q)
            {
                if (string.IsNullOrEmpty(q))
                    return View();

                var hastas = db.Hastas
                    .Where(x => x.Ad.Contains(q) || x.Soyad.Contains(q))
                    .ToList();

                var doktors = db.Doktors
                    .Where(x => x.Ad.Contains(q) || x.Soyad.Contains(q))
                    .ToList();

                var randevus = db.Randevus
                    .Include(x => x.Hasta)
                    .Include(x => x.Doktor)
                    .Where(x => x.Hasta.Ad.Contains(q)
                             || x.Doktor.Ad.Contains(q))
                    .ToList();

                var model = new SearchView
                {
                    Hastas = hastas,
                    Doktors = doktors,
                    Randevus = randevus,
                    Query = q
                };

                return View(model);
            }
        }
    }
