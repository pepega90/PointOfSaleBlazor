using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Model
{

    public class BarangPembeli
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BarangId { get; set; }
        public Barang Barang { get; set; }
    }
}
