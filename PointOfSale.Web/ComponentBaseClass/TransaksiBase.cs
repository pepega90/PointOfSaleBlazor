using Microsoft.AspNetCore.Components;
using PointOfSale.Model;
using PointOfSale.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Web.ComponentBaseClass
{
    public class TransaksiBase : ComponentBase
    {
        [Inject]
        public IBarangService barangService { get; set; }
        [Inject]
        public IBarangPembeliService barangPembeliService { get; set; }

        protected List<Barang> listBarang { get; set; } = new List<Barang>();

        protected List<BarangPembeli> BarangPembelis { get; set; } = new List<BarangPembeli>();

        protected int Jumlah { get; set; }

        protected int BayarPembeli { get; set; }

        protected decimal KembalianPembeli { get; set; }

        private decimal TotalHarga => BarangPembelis.Sum(e => e.Quantity * e.Barang.Harga);

        protected string DisplayTotalHarga => string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C}", TotalHarga);

        protected string DisplayKembalian => string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C}", KembalianPembeli);

        protected async override Task OnInitializedAsync()
        {
            listBarang = (await barangService.GetAllBarang()).ToList();
            BarangPembelis = (await barangPembeliService.GetBarangPembelis()).ToList();
        }

        protected async Task SearchBarang(ChangeEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    listBarang = (await barangService.CariBarang(e.Value.ToString())).ToList();
                }
                else
                {
                    await OnInitializedAsync();
                }
            }
            catch (Exception)
            {
                await OnInitializedAsync();
            }
           
        }

        protected void BayarProduk()
        {
            KembalianPembeli = BayarPembeli - TotalHarga;
            BayarPembeli = 0;
        }

        protected async Task AddBarang(int id)
        {
            var barang = await barangService.GetBarang(id);

            var dataPembeli = new BarangPembeliData
            {
                Id = id,
                NamaBarang = barang.NamaBarang,
                Harga = barang.Harga,
                Qyt = Jumlah
            };

            await barangPembeliService.BeliBarang(dataPembeli);
            await OnInitializedAsync();

            Jumlah = 0;
        }

        protected async Task HapusProduk(int id)
        {
            await barangPembeliService.HapusBarang(id);

            await OnInitializedAsync();
        }
    }
}
