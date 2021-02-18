using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pertemuan_4.Models
{
    public class DaftarBukuController : Controller
    {
        private List<DaftarBuku> GetBuku()
        {
            List<DaftarBuku> lDaftarBuku = new List<DaftarBuku>()
            {
                new DaftarBuku { KodeBuku = "B001", NamaBuku = "Cara Mudah Membuat Database"},
                new DaftarBuku { KodeBuku = "B002", NamaBuku = "Kisah Tragis Kehidupan Seorang Programer"},
                new DaftarBuku { KodeBuku = "B003", NamaBuku = "10 Hal Yang Membuat Anda Cepat Kaya"},
                new DaftarBuku { KodeBuku = "B004", NamaBuku = "Tips Menjadi Juara"},
                new DaftarBuku { KodeBuku = "B005", NamaBuku = "Mencari Koneksi Baru Dengan Mudah Dengan Cara Ini"}
            };

            return lDaftarBuku;
        }

        public IActionResult Index()
        {
            ViewBag.DaftarBuku = "Kumpulan Buku Yang Terdaftar Dalam Sistem";
            DaftarLaporan lDaftarLaporan = new DaftarLaporan();
            lDaftarLaporan.DaftarBuku = GetBuku();
            return View(lDaftarLaporan);
        }

        public IActionResult Pinjaman()
        {
            DaftarLaporan lDaftarLaporan = new DaftarLaporan();
            lDaftarLaporan.DaftarBuku = GetBuku();
            return View(lDaftarLaporan);
        }

        public IActionResult DaftarPinjaman()
        {
            return View(DataLaporan.AmbilData());
        }        

        [HttpPost]
        public IActionResult TambahPinjaman(DaftarLaporan Laporan)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Laporan.DaftarBuku.Count; i++)
                {
                    string[] buku = Laporan.DaftarBuku[i].KodeBuku.Split('-');
                    Laporan.DaftarBuku[i].KodeBuku = buku[0];
                    Laporan.DaftarBuku[i].NamaBuku = buku[1];
                }

                DaftarLaporan dataBaru = new DaftarLaporan
                {
                    Nama = Laporan.Nama,
                    Npm = Laporan.Npm,
                    JumlahBuku = Laporan.DaftarBuku.Count,
                    TotalHarga = Laporan.TotalHarga,
                    DaftarBuku = Laporan.DaftarBuku
                };

                DataLaporan.TambahData(dataBaru);

                return RedirectToAction("DaftarPinjaman", "DaftarBuku");
            }
            return View(Laporan);
        }
    }
}