using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace EczaneOtomasyon.UI
{
    public partial class UcIlacStok : UserControl
    {
        private readonly IIlaclarService _ilaclarService;
        private readonly IKategoriService _kategoriService;
        private readonly IReceteTurService _receteTurService;
        private Ilaclar _secilenIlac;

        public UcIlacStok(IIlaclarService ilaclarService, IKategoriService kategoriService, IReceteTurService receteTurService)
        {
            _ilaclarService = ilaclarService;
            _kategoriService = kategoriService;
            _receteTurService = receteTurService;
            InitializeComponent();
        }

        private object IlaclariGridIcinHazirla(List<Ilaclar> ilaclar)
        {
            var kategoriMap = _kategoriService.GetAllKategori();
            var receteTurMap = _receteTurService.GetReceteTurleri();

            return ilaclar.Select(i => new
            {
                i.IlacID,
                i.IlacAdi,
                Kategori = kategoriMap.ContainsKey(i.KategoriID) ? kategoriMap[i.KategoriID] : "-",
                ReceteTuru = receteTurMap.ContainsKey(i.TurID) ? receteTurMap[i.TurID] : "-",
                i.BirimFiyat,
                i.StokAdedi,
                i.KritikSeviye,
                i.SonKullanmaTarihi,
                i.RafNo
            }).ToList();
        }

        public void IlacStokListele()
        {
            var list = _ilaclarService.TumIlaclariGetir();
            dgw_ilaclar.DataSource = IlaclariGridIcinHazirla(list);
        }

        private void btn_ilacekle_Click(object sender, EventArgs e)
        {
            var frmIlacEkle = Program.ServiceProvider.GetRequiredService<FrmIlacEkle>();
            if (frmIlacEkle.ShowDialog() == DialogResult.OK)
            {
                IlacStokListele(); // İlaç başarıyla eklendiyse tabloyu yenile
            }
        }

        private void IlacAra()
        {
            var list = _ilaclarService.IlacAra(txt_find.Text);
            dgw_ilaclar.DataSource = IlaclariGridIcinHazirla(list);
        }

        private void UcIlacStok_Load(object sender, EventArgs e)
        {
            dgw_ilaclar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgw_ilaclar.RowHeadersVisible = false;
            dgw_ilaclar.AllowUserToAddRows = false;
            dgw_ilaclar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgw_ilaclar.MultiSelect = false;
            dgw_ilaclar.CellClick += Dgw_ilaclar_CellClick;

            IlacStokListele();
        }

        private void Dgw_ilaclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgw_ilaclar.Rows[e.RowIndex];
                int ilacID = (int)row.Cells["IlacID"].Value;
                _secilenIlac = _ilaclarService.TumIlaclariGetir().FirstOrDefault(i => i.IlacID == ilacID);

                if (_secilenIlac != null)
                {
                    lbl_ilacbilgi.Text = $"Seçilen İlaç : {_secilenIlac.IlacAdi} (Stok: {_secilenIlac.StokAdedi}, Fiyat: {_secilenIlac.BirimFiyat:C})";
                    nud_adet.Value = 0;
                }
            }
        }

        private void txt_find_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_find.Text))
            {
                IlacStokListele();
            }
            else
            {
                IlacAra();
            }
        }

        private void btn_stok_kritik_Click(object sender, EventArgs e)
        {
            var kritikilaclar = _ilaclarService.KritikStoktakiIlaclariGetir();
            dgw_ilaclar.DataSource = IlaclariGridIcinHazirla(kritikilaclar);
        }

        private void btn_sktt_Click(object sender, EventArgs e)
        {
            var yaklasilaclar = _ilaclarService.MiadiYaklasanIlaclariGetir();
            dgw_ilaclar.DataSource = IlaclariGridIcinHazirla(yaklasilaclar);
        }

        private void btn_tum_ilaclar_Click(object sender, EventArgs e)
        {
            txt_find.Text = string.Empty;
            IlacStokListele();
        }

        private void btn_update_stock_Click(object sender, EventArgs e)
        {
            if (_secilenIlac == null)
            {
                MessageBox.Show("Lütfen bir ilaç seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nud_adet.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir adet girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _secilenIlac.StokAdedi = (int)nud_adet.Value;
            bool guncellendimi = _ilaclarService.IlacGuncelle(_secilenIlac);

            if (guncellendimi)
            {
                MessageBox.Show("Stok başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IlacStokListele();
                _secilenIlac = null;
                lbl_ilacbilgi.Text = "Seçilen İlaç : ";
                nud_adet.Value = 0;
            }
            else
            {
                MessageBox.Show("Stok güncellenirken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_fiyat_guncelle_Click(object sender, EventArgs e)
        {
            if (_secilenIlac == null)
            {
                MessageBox.Show("Lütfen bir ilaç seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nud_adet.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _secilenIlac.BirimFiyat = (decimal)nud_adet.Value;
            bool guncellendimi = _ilaclarService.IlacGuncelle(_secilenIlac);

            if (guncellendimi)
            {
                MessageBox.Show("Fiyat başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IlacStokListele();
                _secilenIlac = null;
                lbl_ilacbilgi.Text = "Seçilen İlaç : ";
                nud_adet.Value = 0;
            }
            else
            {
                MessageBox.Show("Fiyat güncellenirken hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
