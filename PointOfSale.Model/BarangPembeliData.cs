using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Model
{
    // Class ini di buat sebagai perantara untuk menyimpan data barang dan quantity dari barang tersebut
    public class BarangPembeliData : Barang
    {
        public int Qyt { get; set; }
    }
}
