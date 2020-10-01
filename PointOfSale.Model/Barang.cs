using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Model
{
    public class Barang
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nama barang tidak boleh kosong!")]
        public string NamaBarang { get; set; }
        [Required(ErrorMessage = "Harga barang tidak boleh kosong!")]
        public decimal Harga { get; set; }
    }
}
