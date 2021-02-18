using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pertemuan_4.Models
{   
    public class DaftarLaporan
    {
        public string Nama { get; set; }
        public int Npm { get; set; }
        public int JumlahBuku { get; set; }
        public long TotalHarga { get; set; }
        public List<DaftarBuku> DaftarBuku { get; set; }
    }
}
