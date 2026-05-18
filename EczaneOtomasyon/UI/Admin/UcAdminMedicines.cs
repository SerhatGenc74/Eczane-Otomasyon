using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    public partial class UcAdminMedicines : UserControl
    {
        private readonly IIlaclarService _ilaclarService;
        private readonly IKategoriService _kategoriService;
        private readonly IReceteTurService _receteTurService;

        private int? _selectedIlacId;
        private List<Ilaclar> _lastList = new List<Ilaclar>();

        public UcAdminMedicines(
            IIlaclarService ilaclarService,
            IKategoriService kategoriService,
            IReceteTurService receteTurService)
        {
            _ilaclarService = ilaclarService;
            _kategoriService = kategoriService;
            _receteTurService = receteTurService;

            InitializeComponent();
            LoadLookups();
            LoadIlaclar();
        }

        private void LoadLookups()
        {
            var kategoriler = _kategoriService.GetAllKategori();
            _cmbKategori.DataSource = kategoriler.ToList();
            _cmbKategori.DisplayMember = "Value";
            _cmbKategori.ValueMember = "Key";

            var turler = _receteTurService.GetReceteTurleri();
            _cmbTur.DataSource = turler.ToList();
            _cmbTur.DisplayMember = "Value";
            _cmbTur.ValueMember = "Key";
        }

        private void LoadIlaclar()
        {
            _lastList = _ilaclarService.TumIlaclariGetir() ?? new List<Ilaclar>();
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
                    .Where(i =>
                        ContainsText(i.IlacAdi, text) ||
                        ContainsText(i.RafNo, text) ||
                        ContainsText(i.IlacID.ToString(), text) ||
                        ContainsText(i.KategoriID.ToString(), text) ||
                        ContainsText(i.TurID.ToString(), text) ||
                        ContainsText(i.BirimFiyat.ToString(), text) ||
                        ContainsText(i.StokAdedi.ToString(), text) ||
                        ContainsText(i.KritikSeviye.ToString(), text) ||
                        ContainsText(i.SonKullanmaTarihi.ToShortDateString(), text))
                    .ToList();

            _grid.DataSource = filtered.Select(i => new
            {
                i.IlacID,
                i.IlacAdi,
                i.KategoriID,
                i.TurID,
                i.BirimFiyat,
                i.StokAdedi,
                i.KritikSeviye,
                i.SonKullanmaTarihi,
                i.RafNo
            }).ToList();

            if (_grid.Columns.Contains("IlacID"))
            {
                _grid.Columns["IlacID"].Visible = false;
            }

            if (_grid.Rows.Count == 0)
            {
                _selectedIlacId = null;
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

            var idObj = _grid.CurrentRow.Cells["IlacID"].Value;
            if (idObj == null)
            {
                return;
            }

            _selectedIlacId = Convert.ToInt32(idObj);
            _txtIlacAdi.Text = Convert.ToString(_grid.CurrentRow.Cells["IlacAdi"].Value);

            SelectComboValue(_cmbKategori, _grid.CurrentRow.Cells["KategoriID"].Value);
            SelectComboValue(_cmbTur, _grid.CurrentRow.Cells["TurID"].Value);

            _nudBirimFiyat.Value = Convert.ToDecimal(_grid.CurrentRow.Cells["BirimFiyat"].Value);
            _nudStok.Value = Convert.ToDecimal(_grid.CurrentRow.Cells["StokAdedi"].Value);
            _nudKritik.Value = Convert.ToDecimal(_grid.CurrentRow.Cells["KritikSeviye"].Value);

            var skt = _grid.CurrentRow.Cells["SonKullanmaTarihi"].Value;
            if (skt != null && skt != DBNull.Value)
            {
                _dtSkt.Value = Convert.ToDateTime(skt);
            }

            _txtRafNo.Text = Convert.ToString(_grid.CurrentRow.Cells["RafNo"].Value);
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            var ilac = BuildIlacFromForm();
            if (ilac == null)
            {
                return;
            }

            if (!_ilaclarService.IlacEkle(ilac))
            {
                MessageBox.Show("İlaç eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadIlaclar();
            ClearForm();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedIlacId.HasValue)
            {
                MessageBox.Show("Güncellemek için bir ilaç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ilac = BuildIlacFromForm();
            if (ilac == null)
            {
                return;
            }

            ilac.IlacID = _selectedIlacId.Value;
            if (!_ilaclarService.IlacGuncelle(ilac))
            {
                MessageBox.Show("İlaç güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadIlaclar();
            ClearForm();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!_selectedIlacId.HasValue)
            {
                MessageBox.Show("Silmek için bir ilaç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili ilaç silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_ilaclarService.IlacSil(_selectedIlacId.Value))
            {
                MessageBox.Show("İlaç silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadIlaclar();
            ClearForm();
        }

        private Ilaclar BuildIlacFromForm()
        {
            if (string.IsNullOrWhiteSpace(_txtIlacAdi.Text))
            {
                MessageBox.Show("İlaç adı zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var kategoriId = GetSelectedComboIntValue(_cmbKategori);
            if (!kategoriId.HasValue)
            {
                MessageBox.Show("Kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var turId = GetSelectedComboIntValue(_cmbTur);
            if (!turId.HasValue)
            {
                MessageBox.Show("Tür seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Ilaclar
            {
                IlacAdi = _txtIlacAdi.Text.Trim(),
                KategoriID = kategoriId.Value,
                TurID = turId.Value,
                BirimFiyat = _nudBirimFiyat.Value,
                StokAdedi = (int)_nudStok.Value,
                KritikSeviye = (int)_nudKritik.Value,
                SonKullanmaTarihi = _dtSkt.Value,
                RafNo = _txtRafNo.Text?.Trim()
            };
        }

        private void ClearForm()
        {
            _selectedIlacId = null;
            _txtIlacAdi.Clear();
            if (_cmbKategori.Items.Count > 0) _cmbKategori.SelectedIndex = 0;
            if (_cmbTur.Items.Count > 0) _cmbTur.SelectedIndex = 0;
            _nudBirimFiyat.Value = 0;
            _nudStok.Value = 0;
            _nudKritik.Value = 0;
            _dtSkt.Value = DateTime.Now;
            _txtRafNo.Clear();
        }

        private static void SelectComboValue(ComboBox comboBox, object value)
        {
            if (comboBox == null || value == null || value == DBNull.Value)
            {
                return;
            }

            var numeric = GetComboKeyValue(value);
            if (numeric.HasValue)
            {
                comboBox.SelectedValue = numeric.Value;
                return;
            }

            comboBox.SelectedValue = value;
        }

        private static int? GetSelectedComboIntValue(ComboBox comboBox)
        {
            if (comboBox == null)
            {
                return null;
            }

            var selectedValue = GetComboKeyValue(comboBox.SelectedValue);
            if (selectedValue.HasValue)
            {
                return selectedValue;
            }

            return GetComboKeyValue(comboBox.SelectedItem);
        }

        private static int? GetComboKeyValue(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            if (value is int intValue)
            {
                return intValue;
            }

            if (value is KeyValuePair<int, string> pair)
            {
                return pair.Key;
            }

            var valueType = value.GetType();
            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                var keyProperty = valueType.GetProperty("Key");
                if (keyProperty != null)
                {
                    var keyValue = keyProperty.GetValue(value, null);
                    if (keyValue is int keyInt)
                    {
                        return keyInt;
                    }

                    if (keyValue != null)
                    {
                        try
                        {
                            return Convert.ToInt32(keyValue);
                        }
                        catch
                        {
                        }
                    }
                }
            }

            if (int.TryParse(Convert.ToString(value), out var parsed))
            {
                return parsed;
            }

            return null;
        }
    }
}
