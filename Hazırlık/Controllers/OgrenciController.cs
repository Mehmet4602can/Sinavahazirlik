using Hazırlık.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hazırlık.Controllers
{
    public class OgrenciController : Controller
    {
        HazirlikDBContext VeriTabanio = new HazirlikDBContext();
        public IActionResult Index()
        {
            var liste = from ogrenci in VeriTabanio.Ogrenciler
                        join sinif in VeriTabanio.Siniflar on ogrenci.SinifID
                        equals sinif.SinifID
                        select new Ogrencisinifmodel
                        {
                            OgrenciID = ogrenci.OgrenciID,
                            OgrenciAdi = ogrenci.OgrenciAdi,
                            OgrenciSoyadi = ogrenci.OgrenciSoyadi,
                            Sinifadi = sinif.SinifAdi,
                            Sinifkodu = sinif.SinifKodu
                        };
            return View(liste.ToList());
        }
        public IActionResult Ekle()
        {
            var Siniflistesi = VeriTabanio.Siniflar.ToList();
            ViewBag.Siniflistesi = new SelectList(Siniflistesi, "SinifID", "SinifAdi");
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Ogrenci ogrenci)
        {
            var siniflistsi = VeriTabanio.Siniflar.ToList();
            ViewBag.siniflistesi = new SelectList(siniflistsi, "SinifID", "SinifAdi"); 
            
            VeriTabanio.Ogrenciler.Add(ogrenci);
            VeriTabanio.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Guncelle(int id)
        {
            var sorgu = VeriTabanio.Siniflar.ToList();
            ViewBag.siniflistesi = new SelectList(sorgu, "SinifID", "SinifAdi");
            var ogrenci = VeriTabanio.Ogrenciler.Find(id);
            return View(ogrenci);
        }
        [HttpPost]
        public IActionResult Guncelle(Ogrenci ogrenci)
        {
            if(ogrenci != null) 
            {
                VeriTabanio.Entry<Ogrenci>(ogrenci).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                VeriTabanio.SaveChanges(); 
            }
            return RedirectToAction("Index");

        }
        public IActionResult sil(int id)
        {
            Ogrenci sinif = VeriTabanio.Ogrenciler.Find(id);
            VeriTabanio.Ogrenciler.Remove(sinif);
            VeriTabanio.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
