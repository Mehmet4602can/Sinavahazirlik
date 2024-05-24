using Hazırlık.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hazırlık.Controllers
{
    public class SinifController : Controller
    {
        HazirlikDBContext VeriTabani = new HazirlikDBContext();
        public IActionResult Index()
        {
            var liste = VeriTabani.Siniflar.ToList();
            return View(liste);
        }

        public IActionResult Guncelle(int? id)
        {
            Sinif sinif = VeriTabani.Siniflar.Find(id);
            return View(sinif);
        }

        [HttpPost]
        public IActionResult Guncelle(Sinif sinif)
        {
            VeriTabani.Entry<Sinif>(sinif).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            VeriTabani.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult sil(int? id)
        {
            Sinif sinif = VeriTabani.Siniflar.Find(id);
            VeriTabani.Siniflar.Remove(sinif);
            VeriTabani.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Sinif sinif)
        {
            VeriTabani.Siniflar.Add(sinif);
            VeriTabani.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
