using Microsoft.EntityFrameworkCore;

namespace Lab09_v2.Models
{
    public partial class nthDbContext : DbContext
    {
        public nthDbContext(DbContextOptions<nthDbContext> options) : base(options)
        {
        }
        public DbSet<nthSanPham> nthSanPhams { get; set; }
        public DbSet<nthLoaiSanPham> nthLoaiSanPhams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<nthLoaiSanPham>(entity =>
            {
                entity.HasMany(lsp => lsp.SanPhams)
                      .WithOne(sp => sp.LoaiSanPham)
                      .HasForeignKey(sp => sp.nthLoaiId);
            });
        }
    }
}