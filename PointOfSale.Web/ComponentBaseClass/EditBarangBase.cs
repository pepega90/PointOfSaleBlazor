using Microsoft.AspNetCore.Components;
using PointOfSale.Model;
using PointOfSale.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Web.ComponentBaseClass
{
    public class EditBarangBase : ComponentBase
    {
        [Inject]
        public IBarangService barangService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Barang EditedBarang { get; set; } = new Barang();

        protected async override Task OnInitializedAsync()
        {
            EditedBarang = await barangService.GetBarang(int.Parse(Id));
        }

        protected async Task Edit()
        {
            await barangService.EditBarang(EditedBarang);

            NavigationManager.NavigateTo("/listbarang");
        }
    }
}
