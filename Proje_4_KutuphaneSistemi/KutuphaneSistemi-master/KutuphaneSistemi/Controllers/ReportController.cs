using Kutuphane.Data.Data;
using Kutuphane.Model;
using Kutuphane.Model.viewModel;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneSistemi.Controllers
{
    public class ReportController : Controller
    {
        public readonly ApplicationDbContext dbcontext;
        public ReportController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var result = (from kit in dbcontext.Kitaps
                          join kat in dbcontext.Kategoris
                on kit.KategoriNo equals kat.KategoriNo
                          select new kitkatlistview
                          {
                              KitapAdi = kit.KitapAdi,
                              KitapSayisi = kit.KitapSayisi,
                              KategoriAdi = kat.KategoriAdi
                          }).ToList();

            return View(result); 
        }
        public IActionResult RaporInnerJoin()
        {
            var result = (from kit in dbcontext.Kitaps
                          join kat in dbcontext.Kategoris on kit.KategoriNo equals kat.KategoriNo
                          join yaz in dbcontext.Yazars on kit.YazarNo equals yaz.YazarNo

                          select new kitkatlistview
                          {
                              KitapAdi = kit.KitapAdi,
                              KitapSayisi = kit.KitapSayisi,
                              KategoriAdi = kat.KategoriAdi,
                              YazarAdi = yaz.YazarAdi
                          }).ToList();

            return View(result);
        }
        public IActionResult RaporLeftJoin()
        {
            var result = (from kit in dbcontext.Kitaps

                          join kat in dbcontext.Kategoris on kit.KategoriNo equals kat.KategoriNo into katGrup
                          from katun in katGrup.DefaultIfEmpty()

                          join yaz in dbcontext.Yazars on kit.YazarNo equals yaz.YazarNo into yazGrup
                          from yazan in yazGrup.DefaultIfEmpty()

                          select new kitkatlistview
                          {
                              KitapAdi = kit.KitapAdi,
                              KategoriAdi = katun != null ? katun.KategoriAdi : "Kategori Tanımsız",
                              YazarAdi = yazan != null ? yazan.YazarAdi : "Bilinmeyen Yazar",
                          }).ToList();

            return View(result);
        }
        public IActionResult RaporGroupBy()
        {
            var result = (from kit in dbcontext.Kitaps
                          join kat in dbcontext.Kategoris on kit.KategoriNo equals kat.KategoriNo
                          group kit by kat.KategoriAdi into grup
                          select new kitkatlistview
                          {
                              KategoriAdi = grup.Key,

                              KitapAdi = grup.Count().ToString() + " Farklı Kitap Türü",

                              KitapSayisi = grup.Sum(x => x.KitapSayisi)
                          }).ToList();

            return View(result);
        }
        public IActionResult RaporFullJoin()
        {
            var leftJoin = from kit in dbcontext.Kitaps
                           join kat in dbcontext.Kategoris on kit.KategoriNo equals kat.KategoriNo into katGrup
                           from katun in katGrup.DefaultIfEmpty()
                           select new kitkatlistview
                           {
                               KitapAdi = kit.KitapAdi,
                               KitapSayisi = kit.KitapSayisi,
                               KategoriAdi = katun != null ? katun.KategoriAdi : "Kategori Atanmamış Kitap"
                           };
            var rightJoin = from kat in dbcontext.Kategoris
                            join kit in dbcontext.Kitaps on kat.KategoriNo equals kit.KategoriNo into kitGrup
                            from kitin in kitGrup.DefaultIfEmpty()
                            select new kitkatlistview
                            {
                                KitapAdi = kitin != null ? kitin.KitapAdi : "Bu Kategoride Henüz Kitap Yok",
                                KitapSayisi = kitin != null ? kitin.KitapSayisi : 0,
                                KategoriAdi = kat.KategoriAdi
                            };
            var result = leftJoin.Union(rightJoin).ToList();

            return View(result);
        }
        public IActionResult RaporAyniKitapSayisi()
        {
            var ayniSayidakiGruplar = dbcontext.Kitaps
                .GroupBy(k => k.KitapSayisi)
                .Where(grup => grup.Count() > 1)
                .Select(grup => grup.Key)
                .ToList();

            var result = (from kit in dbcontext.Kitaps
                          join kat in dbcontext.Kategoris on kit.KategoriNo equals kat.KategoriNo into katGrup
                          from katun in katGrup.DefaultIfEmpty()
                          join yaz in dbcontext.Yazars on kit.YazarNo equals yaz.YazarNo into yazGrup
                          from yazan in yazGrup.DefaultIfEmpty()
                          where ayniSayidakiGruplar.Contains(kit.KitapSayisi)
                          orderby kit.KitapSayisi descending
                          select new kitkatlistview
                          {
                              KitapAdi = kit.KitapAdi,
                              KitapSayisi = kit.KitapSayisi,
                              KategoriAdi = katun != null ? katun.KategoriAdi : "Kategori Yok",
                              YazarAdi = yazan != null ? yazan.YazarAdi : "Yazar Yok"
                          }).ToList();

            return View(result);
        }

    }
}
