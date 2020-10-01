using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Components
{
    public class KonfirmasiHapusBase : ComponentBase
    {
        protected bool ShowModal { get; set; }

        [Parameter]
        public string PesanKonfirmasiTitle { get; set; } = "Konfirmasi Hapus";
        [Parameter]
        public string PesanKonfirmasi { get; set; } = "Anda yakin ingin menghapus barang ini?";

        [Parameter]
        public EventCallback<bool> ConfirmDelete { get; set; }

        public void Tampil()
        {
            ShowModal = true;
            StateHasChanged();
        }

        protected async Task OnConfirmDelete(bool value)
        {
            ShowModal = false;
            await ConfirmDelete.InvokeAsync(value);
        }

    }
}
