using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Api.RepositoryInterface
{
    public interface IBarangPembeliRepository
    {
        Task<IEnumerable<BarangPembeli>> GetBarangPembelis();

        Task<BarangPembeli> GetBarangPembeli(int Id);

        Task<BarangPembeli> BeliBarang(Barang barang, int qyt);
        Task<BarangPembeli> HapusBarang(int Id);
    }
}
