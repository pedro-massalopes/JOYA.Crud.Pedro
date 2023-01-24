using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.Data
{
    public class SistemaDbContext:DbContext
    {
        public SistemaDbContext (DbContextOptions<SistemaDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<ProductModel> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
