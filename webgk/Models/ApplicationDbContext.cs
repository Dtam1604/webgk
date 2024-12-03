using Microsoft.EntityFrameworkCore;

namespace webgk.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<sanpham> SanPhams { get; set; }
        public DbSet<Khach> KhachHangs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
