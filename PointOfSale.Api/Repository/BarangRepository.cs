using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.RepositoryInterface;
using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Api.Repository
{
    public class BarangRepository : IBarangRepository
    {
        private readonly AppDbContext context;

        public BarangRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Barang> AddBarang(Barang barang)
        {
            var createdBarang = await context.Barangs.AddAsync(barang);
            await context.SaveChangesAsync();
            return createdBarang.Entity;
        }

         public async Task<IEnumerable<Barang>> CariBarang(string search)
        {
            IQueryable<Barang> query = context.Barangs;

            if(!string.IsNullOrEmpty(search))
            {
                query = context.Barangs.Where(x => x.NamaBarang.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<Barang> DeleteBarang(int Id)
        {
            var deletedBarang = await context.Barangs.FirstOrDefaultAsync(e => e.Id == Id);
            if(deletedBarang != null)
            {
                context.Barangs.Remove(deletedBarang);

                await context.SaveChangesAsync();

                return deletedBarang;
            }

            return null;

        }

        public async Task<Barang> EditBarang(Barang barang)
        {
            var editedBarang = await context.Barangs.FirstOrDefaultAsync(e => e.Id == barang.Id);

            if(editedBarang != null)
            {
                editedBarang.NamaBarang = barang.NamaBarang;
                editedBarang.Harga = barang.Harga;

                await context.SaveChangesAsync();

                return editedBarang;
            }

            return null;
        }

        public async Task<IEnumerable<Barang>> GetAllBarang()
        {
            return await context.Barangs.ToListAsync();
        }

        public async Task<Barang> GetBarang(int Id)
        {
            return await context.Barangs.FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}
