using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bio> Bios { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Guarantee> Guarantees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Mechanism> Mechanisms { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CaseThick> CaseThicks { get; set; }
        public DbSet<BandType> BandTypes { get; set; }
        public DbSet<WaterProtection> WaterProtections { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts {get;set;}
        public DbSet<PaymentType> PaymentTypes { get; set; }
    }
}
