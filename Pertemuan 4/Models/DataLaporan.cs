using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pertemuan_4.Models
{
    public class DataLaporan
    {
        private static List<DaftarLaporan> lDaftarLaporan = new List<DaftarLaporan>();

        public static void TambahData(DaftarLaporan Laporan)
        {
            lDaftarLaporan.Add(new DaftarLaporan()
            {
                Nama = Laporan.Nama,
                Npm = Laporan.Npm,
                JumlahBuku = Laporan.JumlahBuku,
                TotalHarga = Laporan.JumlahBuku * 1000,
                DaftarBuku = Laporan.DaftarBuku
            });
        }

        public static List<DaftarLaporan> AmbilData()
        {
            return lDaftarLaporan;
        }
    }
}
