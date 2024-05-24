using Microsoft.EntityFrameworkCore;

namespace Hazırlık.Models
{
    public class HazirlikDBContext : DbContext
    {
        string baglantiCumlesi = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HazırlıkDb;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(baglantiCumlesi);
        }
        public DbSet<Ogrenci> Ogrenciler {  get; set; }
        public DbSet<Sinif> Siniflar {  get; set; }

    }
}
