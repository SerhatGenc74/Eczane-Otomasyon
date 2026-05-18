using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    public partial class UcAdminPatients : UserControl
    {
        private readonly IHastalarService _service;
        private int? _selectedId;
        private List<Hastalar> _lastList = new List<Hastalar>();

        public UcAdminPatients(IHastalarService service)
        {
            _service = service;
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            _lastList = _service.GetAllHastalar() ?? new List<Hastalar>();
            ApplyFilter();
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (_grid == null)
            {
                return;
            }

            var text = _txtFilter?.Text?.Trim();

            var filtered = string.IsNullOrWhiteSpace(text)
                ? _lastList
                : _lastList
                    .Where(h =>
                        ContainsText(h.TCKimlikNo, text) ||
                        ContainsText(h.Ad, text) ||
                        ContainsText(h.Soyad, text) ||
                        ContainsText(h.Telefon, text) ||
                        ContainsText(h.Cinsiyet, text) ||
                        ContainsText(h.KanGrubu, text) ||
                        ContainsText(h.AlerjiBilgisi, text) ||
                        ContainsText(h.HastaID.ToString(), text))
                    .ToList();

            _grid.DataSource = filtered.Select(h => new
            {
                h.HastaID,
                h.TCKimlikNo,
                h.Ad,
                h.Soyad,
                h.Telefon,
                h.Cinsiyet,
                h.KanGrubu,
                h.AlerjiBilgisi
            }).ToList();

            if (_grid.Rows.Count == 0)
            {
                _selectedId = null;
            }
        }

        private static bool ContainsText(string value, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return value.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_grid.CurrentRow == null)
            {
                return;
            }

            var idObj = _grid.CurrentRow.Cells["HastaID"].Value;
            if (idObj == null)
            {
                return;
            }

            _selectedId = Convert.ToInt32(idObj);
            _txtTc.Text = Convert.ToString(_grid.CurrentRow.Cells["TCKimlikNo"].Value);
            _txtAd.Text = Convert.ToString(_grid.CurrentRow.Cells["Ad"].Value);
            _txtSoyad.Text = Convert.ToString(_grid.CurrentRow.Cells["Soyad"].Value);
            _txtTelefon.Text = Convert.ToString(_grid.CurrentRow.Cells["Telefon"].Value);
            SetCombo(_cmbCinsiyet, Convert.ToString(_grid.CurrentRow.Cells["Cinsiyet"].Value));
            SetCombo(_cmbKanGrubu, Convert.ToString(_grid.CurrentRow.Cells["KanGrubu"].Value));
            _txtAlerji.Text = Convert.ToString(_grid.CurrentRow.Cells["AlerjiBilgisi"].Value);
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtTc.Text) || string.IsNullOrWhiteSpace(_txtAd.Text) || string.IsNullOrWhiteSpace(_txtSoyad.Text))
            {
                MessageBox.Show("Zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hasta = new Hastalar
            {
                TCKimlikNo = _txtTc.Text.Trim(),
                Ad = _txtAd.Text.Trim(),
                Soyad = _txtSoyad.Text.Trim(),
                Telefon = _txtTelefon.Text.Trim(),
                Cinsiyet = _cmbCinsiyet.Text,
                KanGrubu = _cmbKanGrubu.Text,
                AlerjiBilgisi = _txtAlerji.Text.Trim()
            };

            if (!_service.HastaEkle(hasta))
            {
                MessageBox.Show("Hasta eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPatients();
            ClearForm();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Güncellemek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hasta = new Hastalar
            {
                HastaID = _selectedId.Value,
                TCKimlikNo = _txtTc.Text.Trim(),
                Ad = _txtAd.Text.Trim(),
                Soyad = _txtSoyad.Text.Trim(),
                Telefon = _txtTelefon.Text.Trim(),
                Cinsiyet = _cmbCinsiyet.Text,
                KanGrubu = _cmbKanGrubu.Text,
                AlerjiBilgisi = _txtAlerji.Text.Trim()
            };

            if (!_service.HastaGuncelle(hasta))
            {
                MessageBox.Show("Hasta güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPatients();
            ClearForm();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Silmek için kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili hasta silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_service.HastaSil(_selectedId.Value))
            {
                MessageBox.Show("Hasta silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPatients();
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedId = null;
            _txtTc.Clear();
            _txtAd.Clear();
            _txtSoyad.Clear();
            _txtTelefon.Clear();
            if (_cmbCinsiyet.Items.Count > 0) _cmbCinsiyet.SelectedIndex = 0;
            if (_cmbKanGrubu.Items.Count > 0) _cmbKanGrubu.SelectedIndex = 0;
            _txtAlerji.Clear();
        }

        private void SetCombo(ComboBox combo, string value)
        {
            if (combo == null)
            {
                return;
            }

            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (string.Equals(Convert.ToString(combo.Items[i]), value, StringComparison.OrdinalIgnoreCase))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }
    }
}
