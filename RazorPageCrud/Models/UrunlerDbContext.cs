using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageCrud.Models
{
    public class UrunlerDbContext : DbContext
    {
        public UrunlerDbContext(DbContextOptions<UrunlerDbContext> options) : base(options)
        {

        }
        public DbSet<Urun> Urunler { get; set; }
    }
}
