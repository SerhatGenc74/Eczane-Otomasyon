using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    public partial class UcAdminDoctors : UserControl
    {
        private readonly IDoktorlarService _service;
        private int? _selectedId;

        public UcAdminDoctors(IDoktorlarService service)
        {
            _service = service;
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            var list = _service.GetDoktorList();
            _grid.DataSource = list.Select(d => new
            {
                d.DoktorID,
                d.Ad_Soyad,
                d.Brans,
                d.CalistigiKurum
            }).ToList();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_grid.CurrentRow == null)
            {
                return;
            }

            var idObj = _grid.CurrentRow.Cells["DoktorID"].Value;
            if (idObj == null)
            {
                return;
            }

            _selectedId = Convert.ToInt32(idObj);
            _txtAdSoyad.Text = Convert.ToString(_grid.CurrentRow.Cells["Ad_Soyad"].Value);
            _txtBrans.Text = Convert.ToString(_grid.CurrentRow.Cells["Brans"].Value);
            _txtKurum.Text = Convert.ToString(_grid.CurrentRow.Cells["CalistigiKurum"].Value);
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtAdSoyad.Text))
            {
                MessageBox.Show("Doktor adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var doktor = new Doktorlar
            {
                Ad_Soyad = _txtAdSoyad.Text.Trim(),
                Brans = _txtBrans.Text.Trim(),
                CalistigiKurum = _txtKurum.Text.Trim()
            };

            if (!_service.DoktorEkle(doktor))
            {
                MessageBox.Show("Doktor eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadDoctors();
            ClearForm();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Güncellemek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var doktor = new Doktorlar
            {
                DoktorID = _selectedId.Value,
                Ad_Soyad = _txtAdSoyad.Text.Trim(),
                Brans = _txtBrans.Text.Trim(),
                CalistigiKurum = _txtKurum.Text.Trim()
            };

            if (!_service.DoktorGuncelle(doktor))
            {
                MessageBox.Show("Doktor güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadDoctors();
            ClearForm();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Silmek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili doktor silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_service.DoktorSil(_selectedId.Value))
            {
                MessageBox.Show("Doktor silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadDoctors();
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedId = null;
            _txtAdSoyad.Clear();
            _txtBrans.Clear();
            _txtKurum.Clear();
        }
    }
}
