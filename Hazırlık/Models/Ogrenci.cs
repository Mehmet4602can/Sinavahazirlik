namespace Hazırlık.Models
{
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyadi { get; set; }

        public Sinif? Sinif {  get; set; }
        public int SinifID { get; set; }
    }
}
