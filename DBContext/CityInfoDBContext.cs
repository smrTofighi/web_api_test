using CityInfoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoApi.DBContext
{
    public class CityInfoDBContext : DbContext
    {
        
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointOfInterests  { get; set; } = null!;


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite();
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
