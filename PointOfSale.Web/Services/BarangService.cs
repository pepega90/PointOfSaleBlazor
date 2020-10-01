using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace PointOfSale.Web.Services
{
    public class BarangService : IBarangService
    {
        private readonly HttpClient httpClient;

        public BarangService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Barang> AddBarang(Barang barang)
        {
            return await httpClient.PostJsonAsync<Barang>("api/barang", barang);
        }

        public async Task<IEnumerable<Barang>> CariBarang(string namaProduk)
        {
            return await httpClient.GetJsonAsync<Barang[]>($"api/barang/search?namaProduk={namaProduk}");
        }

        public async Task DeleteBarang(int Id)
        {
            await httpClient.DeleteAsync($"api/barang/{Id}");
        }

        public async Task<Barang> EditBarang(Barang barang)
        {
            return await httpClient.PutJsonAsync<Barang>("api/barang", barang);
        }

        public async Task<IEnumerable<Barang>> GetAllBarang()
        {
            return await httpClient.GetJsonAsync<Barang[]>("api/barang");
        }

        public async Task<Barang> GetBarang(int Id)
        {
            return await httpClient.GetJsonAsync<Barang>($"api/barang/{Id}");
        }
    }
}
