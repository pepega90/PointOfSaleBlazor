using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Api.RepositoryInterface
{
    public interface IBarangRepository
    {
        Task<IEnumerable<Barang>> GetAllBarang();
        Task<IEnumerable<Barang>> CariBarang(string namaBarang);
        Task<Barang> GetBarang(int Id);
        Task<Barang> AddBarang(Barang barang);
        Task<Barang> EditBarang(Barang barang);
        Task<Barang> DeleteBarang(int Id);
    }
}
