﻿using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Web.Services
{
    public interface IBarangService
    {
        Task<IEnumerable<Barang>> GetAllBarang();
        Task<IEnumerable<Barang>> CariBarang(string namaProduk);
        Task<Barang> GetBarang(int Id);
        Task<Barang> AddBarang(Barang barang);
        Task<Barang> EditBarang(Barang barang);
        Task DeleteBarang(int Id);
    }
}
