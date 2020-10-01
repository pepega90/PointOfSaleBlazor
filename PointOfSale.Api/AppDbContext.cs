using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Model;

namespace PointOfSale.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Barang> Barangs { get; set; }
        public DbSet<BarangPembeli> BarangPembelis { get; set; }
    }
}
