using Microsoft.AspNetCore.Components;
using PointOfSale.Model;
using PointOfSale.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Web.ComponentBaseClass
{
    public class TambahBarangBase : ComponentBase
    {
        [Inject]
        public IBarangService barangService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected Barang Barang { get; set; } = new Barang();

        protected async Task TambahBarang()
        {
            await barangService.AddBarang(Barang);

            NavigationManager.NavigateTo("/listbarang");
        }
    }
}
