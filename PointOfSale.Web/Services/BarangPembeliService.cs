using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace PointOfSale.Web.Services
{
    public class BarangPembeliService : IBarangPembeliService
    {
        private readonly HttpClient httpClient;

        public BarangPembeliService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<BarangPembeli> BeliBarang(BarangPembeliData barang)
        {
            return await httpClient.PostJsonAsync<BarangPembeli>("api/barangpembeli", barang);
        }

        public async Task<BarangPembeli> GetBarangPembeli(int Id)
        {
            return await httpClient.GetJsonAsync<BarangPembeli>($"api/barangpembeli/{Id}");
        }

        public async Task<IEnumerable<BarangPembeli>> GetBarangPembelis()
        {
            return await httpClient.GetJsonAsync<BarangPembeli[]>("api/barangpembeli");
        }

        public async Task HapusBarang(int Id)
        {
            await httpClient.DeleteAsync($"api/barangpembeli/{Id}");
        }
    }
}
