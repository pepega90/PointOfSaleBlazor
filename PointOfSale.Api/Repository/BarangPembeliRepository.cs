using PointOfSale.Api.RepositoryInterface;
using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PointOfSale.Api.Repository
{
    public class BarangPembeliRepository : IBarangPembeliRepository
    {
        private readonly AppDbContext context;

        public BarangPembeliRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<BarangPembeli> BeliBarang(Barang barang, int qyt)
        {
            var beliBarang = await context.BarangPembelis
                .FirstOrDefaultAsync(e => e.BarangId == barang.Id);

            if (beliBarang == null)
            {
                beliBarang = new BarangPembeli
                {
                    Barang = barang,
                    BarangId = barang.Id,
                    Quantity = qyt
                };

                await context.BarangPembelis.AddAsync(beliBarang);
            }
            else
            {
                beliBarang.Quantity++;
            }

            await context.SaveChangesAsync();

            return beliBarang;
        }

        public async Task<BarangPembeli> GetBarangPembeli(int Id)
        {
            return await context.BarangPembelis.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<BarangPembeli>> GetBarangPembelis()
        {
            return await context.BarangPembelis.Include(e => e.Barang).ToListAsync();
        }

        public async Task<BarangPembeli> HapusBarang(int Id)
        {
            var deletedBarangPembeli = await context.BarangPembelis.FirstOrDefaultAsync(e => e.Id == Id);

            if (deletedBarangPembeli != null)
            {
                context.BarangPembelis.Remove(deletedBarangPembeli);

                await context.SaveChangesAsync();

                return deletedBarangPembeli;
            }
            return null;
        }
    }
}
