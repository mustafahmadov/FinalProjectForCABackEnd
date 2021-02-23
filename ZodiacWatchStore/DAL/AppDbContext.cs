using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Bio> Bios { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
