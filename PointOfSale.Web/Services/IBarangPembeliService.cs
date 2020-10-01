using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Web.Services
{
    public interface IBarangPembeliService
    {
        Task<IEnumerable<BarangPembeli>> GetBarangPembelis();

        Task<BarangPembeli> GetBarangPembeli(int Id);

        Task<BarangPembeli> BeliBarang(BarangPembeliData barang);
        Task HapusBarang(int Id);
    }
}
