using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI
{
    public partial class UcHastaRecete : UserControl
    {
        private readonly IHastalarService _hastalarService;
        private readonly IRecetelerService _recetelerService;
        private readonly IDoktorlarService _doktorlarService;
        private readonly IReceteTurService _receteTurService;
        private readonly IIlaclarService _ilaclarService;

        private int? _selectedHastaId;
        private int? _selectedReceteId;
        private int? _selectedDetayId;

        public UcHastaRecete(
            IHastalarService hastalarService,
            IRecetelerService recetelerService,
            IDoktorlarService doktorlarService,
            IReceteTurService receteTurService,
            IIlaclarService ilaclarService)
        {
            _hastalarService = hastalarService;
            _recetelerService = recetelerService;
            _doktorlarService = doktorlarService;
            _receteTurService = receteTurService;
            _ilaclarService = ilaclarService;

            InitializeComponent();
        }

        private void UcHastaRecete_Load(object sender, EventArgs e)
        {
            _txtReceteKodu.Text = GenerateReceteKodu();
            _dtTarih.Value = DateTime.Now;
            RefreshLookupData();
            RefreshHastaData();
            RefreshReceteData();
            RefreshDetayData();
        }

        private void BtnHastaKaydet_Click(object sender, EventArgs e)
        {
            var hasta = BuildHastaFromForm();
            if (hasta == null)
            {
                return;
            }

            if (!_hastalarService.HastaEkle(hasta))
            {
                MessageBox.Show("Hasta kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearHastaForm();
            RefreshLookupData();
            RefreshHastaData();
        }

        private void BtnHastaGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedHastaId.HasValue)
            {
                MessageBox.Show("Güncellemek için bir hasta seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hasta = BuildHastaFromForm();
            if (hasta == null)
            {
                return;
            }

            hasta.HastaID = _selectedHastaId.Value;
            if (!_hastalarService.HastaGuncelle(hasta))
            {
                MessageBox.Show("Hasta güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RefreshLookupData();
            RefreshHastaData();
            RefreshReceteData();
        }

        private void BtnHastaSil_Click(object sender, EventArgs e)
        {
            if (!_selectedHastaId.HasValue)
            {
                MessageBox.Show("Silmek için bir hasta seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili hasta silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_hastalarService.HastaSil(_selectedHastaId.Value))
            {
                MessageBox.Show("Hasta silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selectedHastaId = null;
            ClearHastaForm();
            RefreshLookupData();
            RefreshHastaData();
            RefreshReceteData();
        }

        private void BtnHastaAra_Click(object sender, EventArgs e)
        {
            BindHastaGrid(_hastalarService.HastaAra(_txtHastaAra.Text));
        }

        private void BtnReceteKaydet_Click(object sender, EventArgs e)
        {
            var recete = BuildReceteFromForm();
            if (recete == null)
            {
                return;
            }

            if (!_recetelerService.ReceteEkle(recete))
            {
                MessageBox.Show("Reçete kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selectedReceteId = FindReceteIdByCode(recete.ReceteKodu);
            RefreshReceteData();
            RefreshDetayData();
        }

        private void BtnReceteGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedReceteId.HasValue)
            {
                MessageBox.Show("Güncellemek için bir reçete seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var recete = BuildReceteFromForm();
            if (recete == null)
            {
                return;
            }

            recete.ReceteID = _selectedReceteId.Value;
            if (!_recetelerService.ReceteGuncelle(recete))
            {
                MessageBox.Show("Reçete güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RefreshReceteData();
            RefreshDetayData();
        }

        private void BtnReceteSil_Click(object sender, EventArgs e)
        {
            if (!_selectedReceteId.HasValue)
            {
                MessageBox.Show("Silmek için bir reçete seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili reçete silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_recetelerService.ReceteSil(_selectedReceteId.Value))
            {
                MessageBox.Show("Reçete silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selectedReceteId = null;
            _selectedDetayId = null;
            ClearReceteForm();
            ClearDetayForm();
            RefreshReceteData();
            RefreshDetayData();
        }

        private void BtnDetayEkle_Click(object sender, EventArgs e)
        {
            if (!_selectedReceteId.HasValue)
            {
                MessageBox.Show("Önce bir reçete seçin veya kaydedin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ilacId = GetSelectedComboIntValue(_cmbIlac);
            if (!ilacId.HasValue)
            {
                MessageBox.Show("Lütfen ilaç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detay = new ReceteDetay
            {
                ReceteID = _selectedReceteId,
                IlacID = ilacId.Value,
                KullanimSekli = _txtKullanimSekli.Text.Trim(),
                Adet = (int)_nudAdet.Value
            };

            if (!_recetelerService.ReceteDetayEkle(detay))
            {
                MessageBox.Show("Detay kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearDetayForm();
            RefreshDetayData();
        }

        private void BtnDetaySil_Click(object sender, EventArgs e)
        {
            if (!_selectedDetayId.HasValue)
            {
                MessageBox.Show("Silmek için bir detay satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili detay silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_recetelerService.ReceteDetaySil(_selectedDetayId.Value))
            {
                MessageBox.Show("Detay silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selectedDetayId = null;
            ClearDetayForm();
            RefreshDetayData();
        }

        private void DgwHastalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _dgwHastalar.Rows[e.RowIndex];
            _selectedHastaId = Convert.ToInt32(row.Cells["HastaID"].Value);
            _txtTc.Text = Convert.ToString(row.Cells["TCKimlikNo"].Value);
            _txtAd.Text = Convert.ToString(row.Cells["Ad"].Value);
            _txtSoyad.Text = Convert.ToString(row.Cells["Soyad"].Value);
            _txtTelefon.Text = Convert.ToString(row.Cells["Telefon"].Value);
            SelectComboValue(_cmbCinsiyet, row.Cells["Cinsiyet"].Value);
            SelectComboValue(_cmbKanGrubu, row.Cells["KanGrubu"].Value);
            _txtAlerji.Text = Convert.ToString(row.Cells["AlerjiBilgisi"].Value);
        }

        private void DgwReceteler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _dgwReceteler.Rows[e.RowIndex];
            _selectedReceteId = Convert.ToInt32(row.Cells["ReceteID"].Value);
            _txtReceteKodu.Text = Convert.ToString(row.Cells["ReceteKodu"].Value);
            SelectComboValue(_cmbHasta, row.Cells["HastaID"].Value);
            SelectComboValue(_cmbDoktor, row.Cells["DoktorID"].Value);
            SelectComboValue(_cmbReceteTuru, row.Cells["ReceteTipiID"].Value);

            var tarih = row.Cells["Tarih"].Value;
            if (tarih != null && tarih != DBNull.Value)
            {
                _dtTarih.Value = Convert.ToDateTime(tarih);
            }

            _chkDurum.Checked = string.Equals(Convert.ToString(row.Cells["Durum"].Value), "Aktif", StringComparison.OrdinalIgnoreCase);
            RefreshDetayData();
        }

        private void DgwDetaylar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _dgwDetaylar.Rows[e.RowIndex];
            _selectedDetayId = Convert.ToInt32(row.Cells["DetayID"].Value);
            SelectComboValue(_cmbIlac, row.Cells["IlacID"].Value);
            _nudAdet.Value = Convert.ToDecimal(row.Cells["Adet"].Value);
            _txtKullanimSekli.Text = Convert.ToString(row.Cells["KullanimSekli"].Value);
        }

        private void RefreshLookupData()
        {
            var hastalar = _hastalarService.GetAllHastalar();
            _cmbHasta.DataSource = hastalar.Select(h => new KeyValuePair<int, string>(h.HastaID, string.Format("{0} {1}", h.Ad, h.Soyad).Trim())).ToList();
            _cmbHasta.DisplayMember = "Value";
            _cmbHasta.ValueMember = "Key";

            var doktorlar = _doktorlarService.GetDoktorlar();
            _cmbDoktor.DataSource = doktorlar.ToList();
            _cmbDoktor.DisplayMember = "Value";
            _cmbDoktor.ValueMember = "Key";

            var turler = _receteTurService.GetReceteTurleri();
            _cmbReceteTuru.DataSource = turler.ToList();
            _cmbReceteTuru.DisplayMember = "Value";
            _cmbReceteTuru.ValueMember = "Key";

            var ilaclar = _ilaclarService.TumIlaclariGetir();
            _cmbIlac.DataSource = ilaclar.Select(i => new KeyValuePair<int, string>(i.IlacID, i.IlacAdi)).ToList();
            _cmbIlac.DisplayMember = "Value";
            _cmbIlac.ValueMember = "Key";
        }

        private void RefreshHastaData()
        {
            BindHastaGrid(_hastalarService.GetAllHastalar());
        }

        private void BindHastaGrid(IEnumerable<Hastalar> hastalar)
        {
            _dgwHastalar.DataSource = hastalar.Select(h => new
            {
                h.HastaID,
                h.TCKimlikNo,
                HastaAdiSoyadi = string.Format("{0} {1}", h.Ad, h.Soyad).Trim(),
                h.Ad,
                h.Soyad,
                h.Telefon,
                h.Cinsiyet,
                h.KanGrubu,
                h.AlerjiBilgisi
            }).ToList();

            HideColumns(_dgwHastalar, "HastaID", "Ad", "Soyad", "AlerjiBilgisi");
        }

        private void RefreshReceteData()
        {
            var receteler = _recetelerService.GetAllReceteler();
            var hastalar = _hastalarService.GetAllHastalar().ToDictionary(x => x.HastaID, x => string.Format("{0} {1}", x.Ad, x.Soyad).Trim());
            var doktorlar = _doktorlarService.GetDoktorlar();
            var turler = _receteTurService.GetReceteTurleri();

            _dgwReceteler.DataSource = receteler.Select(r => new
            {
                r.ReceteID,
                r.ReceteKodu,
                r.HastaID,
                HastaAdiSoyadi = hastalar.ContainsKey(r.HastaID ?? 0) ? hastalar[r.HastaID ?? 0] : "-",
                r.DoktorID,
                DoktorAdi = doktorlar.ContainsKey(r.DoktorID ?? 0) ? doktorlar[r.DoktorID ?? 0] : "-",
                r.ReceteTipiID,
                ReceteTuru = turler.ContainsKey(r.ReceteTipiID ?? 0) ? turler[r.ReceteTipiID ?? 0] : "-",
                r.Tarih,
                Durum = r.Durum ? "Aktif" : "Pasif"
            }).ToList();

            HideColumns(_dgwReceteler, "ReceteID", "HastaID", "DoktorID", "ReceteTipiID");
        }

        private void RefreshDetayData()
        {
            if (!_selectedReceteId.HasValue)
            {
                _dgwDetaylar.DataSource = null;
                return;
            }

            var detaylar = _recetelerService.GetReceteDetaylari(_selectedReceteId.Value);
            var ilaclar = _ilaclarService.TumIlaclariGetir().ToDictionary(x => x.IlacID, x => x.IlacAdi);

            _dgwDetaylar.DataSource = detaylar.Select(d => new
            {
                d.DetayID,
                d.ReceteID,
                d.IlacID,
                IlacAdi = ilaclar.ContainsKey(d.IlacID ?? 0) ? ilaclar[d.IlacID ?? 0] : "-",
                d.KullanimSekli,
                d.Adet
            }).ToList();

            HideColumns(_dgwDetaylar, "DetayID", "ReceteID", "IlacID");
        }

        private Hastalar BuildHastaFromForm()
        {
            if (string.IsNullOrWhiteSpace(_txtAd.Text) || string.IsNullOrWhiteSpace(_txtSoyad.Text))
            {
                MessageBox.Show("Hasta adı ve soyadı zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Hastalar
            {
                TCKimlikNo = _txtTc.Text?.Trim(),
                Ad = _txtAd.Text?.Trim(),
                Soyad = _txtSoyad.Text?.Trim(),
                Telefon = _txtTelefon.Text?.Trim(),
                Cinsiyet = _cmbCinsiyet.Text,
                KanGrubu = _cmbKanGrubu.Text,
                AlerjiBilgisi = _txtAlerji.Text?.Trim()
            };
        }

        private Receteler BuildReceteFromForm()
        {
            var hastaId = GetSelectedComboIntValue(_cmbHasta);
            if (!hastaId.HasValue)
            {
                MessageBox.Show("Lütfen bir hasta seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Receteler
            {
                ReceteKodu = string.IsNullOrWhiteSpace(_txtReceteKodu.Text) ? GenerateReceteKodu() : _txtReceteKodu.Text.Trim(),
                HastaID = hastaId.Value,
                DoktorID = GetSelectedComboIntValue(_cmbDoktor),
                ReceteTipiID = GetSelectedComboIntValue(_cmbReceteTuru),
                Tarih = _dtTarih.Value,
                Durum = _chkDurum.Checked
            };
        }

        private int? FindReceteIdByCode(string receteKodu)
        {
            var recete = _recetelerService.GetAllReceteler().FirstOrDefault(x => x.ReceteKodu == receteKodu);
            return recete == null ? (int?)null : recete.ReceteID;
        }

        private void ClearHastaForm()
        {
            _selectedHastaId = null;
            _txtTc.Clear();
            _txtAd.Clear();
            _txtSoyad.Clear();
            _txtTelefon.Clear();
            _cmbCinsiyet.SelectedIndex = 0;
            _cmbKanGrubu.SelectedIndex = 0;
            _txtAlerji.Clear();
        }

        private void ClearReceteForm()
        {
            _selectedReceteId = null;
            _txtReceteKodu.Text = GenerateReceteKodu();
            if (_cmbHasta.Items.Count > 0) _cmbHasta.SelectedIndex = 0;
            if (_cmbDoktor.Items.Count > 0) _cmbDoktor.SelectedIndex = 0;
            if (_cmbReceteTuru.Items.Count > 0) _cmbReceteTuru.SelectedIndex = 0;
            _dtTarih.Value = DateTime.Now;
            _chkDurum.Checked = true;
        }

        private void ClearDetayForm()
        {
            _selectedDetayId = null;
            if (_cmbIlac.Items.Count > 0) _cmbIlac.SelectedIndex = 0;
            _nudAdet.Value = 1;
            _txtKullanimSekli.Clear();
        }

        private void SelectComboValue(ComboBox comboBox, object value)
        {
            if (comboBox == null || value == null || value == DBNull.Value)
            {
                return;
            }

            if (comboBox.DataSource != null)
            {
                var keyValue = GetComboKeyValue(value);
                if (keyValue.HasValue)
                {
                    comboBox.SelectedValue = keyValue.Value;
                    return;
                }

                comboBox.SelectedValue = value;
                return;
            }

            var targetText = Convert.ToString(value);
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (string.Equals(Convert.ToString(comboBox.Items[i]), targetText, StringComparison.OrdinalIgnoreCase))
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
        }

        private static void HideColumns(DataGridView grid, params string[] columns)
        {
            foreach (var column in columns)
            {
                if (grid.Columns.Contains(column))
                {
                    grid.Columns[column].Visible = false;
                }
            }
        }

        private static string GenerateReceteKodu()
        {
            return "RCT-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
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

        private static string GetComboDisplayText(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return string.Empty;
            }

            if (value is KeyValuePair<int, string> pair)
            {
                return pair.Value;
            }

            var valueType = value.GetType();
            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                var valueProperty = valueType.GetProperty("Value");
                if (valueProperty != null)
                {
                    var displayValue = valueProperty.GetValue(value, null);
                    if (displayValue != null)
                    {
                        return Convert.ToString(displayValue);
                    }
                }
            }

            return Convert.ToString(value);
        }
    }
}