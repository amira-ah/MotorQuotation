using Microsoft.EntityFrameworkCore;

namespace SystemCars.Data.Models
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<VehicleQuotation> VehicleQuotation => Set<VehicleQuotation>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleQuotation>().HasKey(vq => vq.QuotationNumber);
            base.OnModelCreating(modelBuilder);
        }

    }
}
