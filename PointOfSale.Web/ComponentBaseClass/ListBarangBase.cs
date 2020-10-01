using Microsoft.AspNetCore.Components;
using PointOfSale.Model;
using PointOfSale.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Web.ComponentBaseClass
{
    public class ListBarangBase : ComponentBase
    {
        [Inject]
        public IBarangService barangService { get; set; }

        protected Components.KonfirmasiHapus ConfirmRef { get; set; }

        protected int noUrut { get; set; }

        protected List<Barang> Barangs { get; set; } = new List<Barang>();

        protected async override Task OnInitializedAsync()
        {
            Barangs = (await barangService.GetAllBarang()).ToList();
        }

        public int IdBarang { get; set; }

        protected void ShowModalHapusBarang(int id)
        {
            IdBarang = id;
            ConfirmRef.Tampil();
        }

        protected async Task HapusKonfirmasiBarang(bool konfirmHapus)
        {
            if(konfirmHapus)
            {
                await barangService.DeleteBarang(IdBarang);

                await OnInitializedAsync();
            }
        }
    }
}
