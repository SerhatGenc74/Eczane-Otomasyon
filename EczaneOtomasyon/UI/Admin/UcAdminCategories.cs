using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    public partial class UcAdminCategories : UserControl
    {
        private readonly IKategoriService _kategoriService;
        private readonly IReceteTurService _receteTurService;
        private int? _selectedKategoriId;
        private int? _selectedReceteTurId;
      
        public UcAdminCategories(IKategoriService kategoriService, IReceteTurService receteTurService)
        {
            _kategoriService = kategoriService;
            _receteTurService = receteTurService;

            InitializeComponent();

            LoadKategoriler();
            LoadReceteTurleri();
        }

        private void LoadKategoriler()
        {
            var list = _kategoriService.GetKategoriList();
            _gridKategori.DataSource = list.Select(k => new
            {
                k.KategoriID,
                k.KategoriAdi
            }).ToList();
        }

        private void LoadReceteTurleri()
        {
            var list = _receteTurService.GetReceteTurList();
            _gridReceteTur.DataSource = list.Select(t => new
            {
                t.TurID,
                t.TurAdi
            }).ToList();
        }

        private void GridKategori_SelectionChanged(object sender, EventArgs e)
        {
            if (_gridKategori.CurrentRow == null)
            {
                return;
            }

            var idObj = _gridKategori.CurrentRow.Cells["KategoriID"].Value;
            if (idObj == null)
            {
                return;
            }

            _selectedKategoriId = Convert.ToInt32(idObj);
            _txtKategoriAdi.Text = Convert.ToString(_gridKategori.CurrentRow.Cells["KategoriAdi"].Value);
        }

        private void GridReceteTur_SelectionChanged(object sender, EventArgs e)
        {
            if (_gridReceteTur.CurrentRow == null)
            {
                return;
            }

            var idObj = _gridReceteTur.CurrentRow.Cells["TurID"].Value;
            if (idObj == null)
            {
                return;
            }

            _selectedReceteTurId = Convert.ToInt32(idObj);
            _txtReceteTurAdi.Text = Convert.ToString(_gridReceteTur.CurrentRow.Cells["TurAdi"].Value);
        }

        private void BtnKategoriEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtKategoriAdi.Text))
            {
                MessageBox.Show("Kategori adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kategori = new Kategoriler { KategoriAdi = _txtKategoriAdi.Text.Trim() };
            if (!_kategoriService.KategoriEkle(kategori))
            {
                MessageBox.Show("Kategori eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadKategoriler();
            ClearKategoriForm();
        }

        private void BtnKategoriGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedKategoriId.HasValue)
            {
                MessageBox.Show("Güncellemek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kategori = new Kategoriler
            {
                KategoriID = _selectedKategoriId.Value,
                KategoriAdi = _txtKategoriAdi.Text.Trim()
            };

            if (!_kategoriService.KategoriGuncelle(kategori))
            {
                MessageBox.Show("Kategori güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadKategoriler();
            ClearKategoriForm();
        }

        private void BtnKategoriSil_Click(object sender, EventArgs e)
        {
            if (!_selectedKategoriId.HasValue)
            {
                MessageBox.Show("Silmek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili kategori silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_kategoriService.KategoriSil(_selectedKategoriId.Value))
            {
                MessageBox.Show("Kategori silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadKategoriler();
            ClearKategoriForm();
        }

        private void BtnReceteTurEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtReceteTurAdi.Text))
            {
                MessageBox.Show("Tür adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tur = new ReceteTurleri { TurAdi = _txtReceteTurAdi.Text.Trim() };
            if (!_receteTurService.ReceteTurEkle(tur))
            {
                MessageBox.Show("Reçete türü eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadReceteTurleri();
            ClearReceteTurForm();
        }

        private void BtnReceteTurGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedReceteTurId.HasValue)
            {
                MessageBox.Show("Güncellemek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tur = new ReceteTurleri
            {
                TurID = _selectedReceteTurId.Value,
                TurAdi = _txtReceteTurAdi.Text.Trim()
            };

            if (!_receteTurService.ReceteTurGuncelle(tur))
            {
                MessageBox.Show("Reçete türü güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadReceteTurleri();
            ClearReceteTurForm();
        }

        private void BtnReceteTurSil_Click(object sender, EventArgs e)
        {
            if (!_selectedReceteTurId.HasValue)
            {
                MessageBox.Show("Silmek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili reçete türü silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_receteTurService.ReceteTurSil(_selectedReceteTurId.Value))
            {
                MessageBox.Show("Reçete türü silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadReceteTurleri();
            ClearReceteTurForm();
        }

        private void ClearKategoriForm()
        {
            _selectedKategoriId = null;
            _txtKategoriAdi.Clear();
        }

        private void ClearReceteTurForm()
        {
            _selectedReceteTurId = null;
            _txtReceteTurAdi.Clear();
        }
    }
}
