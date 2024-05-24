namespace Hazırlık.Models
{
    public class Sinif
    {
        public int SinifID { get; set; }
        public string? SinifAdi { get; set; }
        public string? SinifKodu { get; set; }

        public ICollection<Ogrenci> ogrencier { get; set; }
    }
}
