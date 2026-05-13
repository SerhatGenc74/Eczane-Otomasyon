using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI
{
    public partial class UcSatisFatura : UserControl
    {
        private readonly ISatislarService _satislarService;
        private readonly IIlaclarService _ilaclarService;
        private readonly IRecetelerService _recetelerService;
        private readonly IKullanicilarService _kullanicilarService;
        private readonly EczaneOtomasyon.Bussines.Services.Interfaces.IAuthService _authService;
        private readonly IHastalarService _hastalarService;

        private readonly List<SatisDetay> _geciciDetaylar = new List<SatisDetay>();
        private int _geciciKalemId = -1;

        private int? _currentKullaniciId;
        private int? _selectedSatisId;
        private int? _selectedKalemId;

        public UcSatisFatura(ISatislarService satislarService, IIlaclarService ilaclarService, IRecetelerService recetelerService, IKullanicilarService kullanicilarService, IHastalarService hastalarService, EczaneOtomasyon.Bussines.Services.Interfaces.IAuthService authService)
        {
            _satislarService = satislarService;
            _ilaclarService = ilaclarService;
            _recetelerService = recetelerService;
            _kullanicilarService = kullanicilarService;
            _authService = authService;
            _hastalarService = hastalarService;

            InitializeComponent();
        }

        private void UcSatisFatura_Load(object sender, EventArgs e)
        {
            _txtFaturaNo.Text = GenerateFaturaNo();
            _dtTarih.Value = DateTime.Now;
            RefreshLookups();
            _rbRecetesiz.Checked = true;
            OnSatisTuruChanged();
            RefreshSalesGrid();
            RefreshDraftGrid();
            RefreshSaleDetailsGrid();
            UpdateTotals();
        }

        private void RefreshLookups()
        {
            // Recete lookup will be entered via search textbox; no combobox data-source.
            var current = _authService?.GetCurrentUser();
            if (current != null)
            {
                _currentKullaniciId = current.KullaniciID;
                _lblKullanici.Text = "Kasiyer: " + current.AdSoyad;
            }
            else
            {
                var users = _kullanicilarService.GetAllUsers();
                var firstUser = users.FirstOrDefault();
                if (firstUser != null)
                {
                    _currentKullaniciId = firstUser.KullaniciID;
                    _lblKullanici.Text = "Kasiyer: " + firstUser.AdSoyad;
                }
            }

            var ilaclar = _ilaclarService.TumIlaclariGetir();
            _cmbIlac.DataSource = ilaclar.Select(i => new KeyValuePair<int, string>(i.IlacID, string.Format("{0} ({1} TL)", i.IlacAdi, i.BirimFiyat))).ToList();
            _cmbIlac.DisplayMember = "Value";
            _cmbIlac.ValueMember = "Key";
        }

        private void RefreshSalesGrid(string search = null)
        {
            var satislar = _satislarService.GetAllSatislar();
            if (!string.IsNullOrWhiteSpace(search))
            {
                satislar = satislar.Where(x => x.FaturaNo != null && x.FaturaNo.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Tarihe göre sıralama
            var desc = _cmbSatisSirala == null || _cmbSatisSirala.SelectedIndex <= 0; // 0: yeniden eskiye
            satislar = desc ? satislar.OrderByDescending(x => x.Tarih).ToList() : satislar.OrderBy(x => x.Tarih).ToList();

            var receteler = _recetelerService.GetAllReceteler().ToDictionary(x => x.ReceteID, x => x.ReceteKodu);
            var users = _kullanicilarService.GetAllUsers().ToDictionary(x => x.KullaniciID, x => x.AdSoyad);

            _dgwSatislar.DataSource = satislar.Select(s => new
            {
                s.SatisID,
                s.FaturaNo,
                s.Tarih,
                s.SatisTuru,
                s.ReceteID,
                ReceteKodu = receteler.ContainsKey(s.ReceteID ?? 0) ? receteler[s.ReceteID ?? 0] : "-",
                s.IndirimTutari,
                s.ToplamTutar,
                NetTutar = s.ToplamTutar - s.IndirimTutari,
                s.OdemeYontemi,
                s.KullaniciID,
                KullaniciAdi = users.ContainsKey(s.KullaniciID ?? 0) ? users[s.KullaniciID ?? 0] : "-"
            }).ToList();

            HideColumns(_dgwSatislar, "SatisID", "ReceteID", "KullaniciID", "ToplamTutar");
        }

        private void CmbSatisSirala_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSalesGrid(_txtSatisAra?.Text);
        }

        private void RefreshDraftGrid()
        {
            var ilaclar = _ilaclarService.TumIlaclariGetir().ToDictionary(x => x.IlacID, x => x.IlacAdi);
            _dgwKalemler.DataSource = _geciciDetaylar.Select(x => new
            {
                x.SatisDetayID,
                x.IlacID,
                IlacAdi = ilaclar.ContainsKey(x.IlacID ?? 0) ? ilaclar[x.IlacID ?? 0] : "-",
                x.Adet,
                x.SatisBirimFiyati,
                x.AraToplam
            }).ToList();

            HideColumns(_dgwKalemler, "SatisDetayID", "IlacID");
            // Ensure a remove button column exists
            if (!_dgwKalemler.Columns.Contains("Sil"))
            {
                var btnCol = new DataGridViewButtonColumn
                {
                    Name = "Sil",
                    HeaderText = "",
                    Text = "Sil",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Standard
                };
                _dgwKalemler.Columns.Add(btnCol);
            }
        }

        private void RefreshSaleDetailsGrid()
        {
            if (!_selectedSatisId.HasValue)
            {
                _dgwSatisDetay.DataSource = null;
                return;
            }

            var details = _satislarService.GetSatisDetaylari(_selectedSatisId.Value);
            var ilaclar = _ilaclarService.TumIlaclariGetir().ToDictionary(x => x.IlacID, x => x.IlacAdi);
            _dgwSatisDetay.DataSource = details.Select(d => new
            {
                d.SatisDetayID,
                d.SatisID,
                d.IlacID,
                IlacAdi = ilaclar.ContainsKey(d.IlacID ?? 0) ? ilaclar[d.IlacID ?? 0] : "-",
                d.Adet,
                d.SatisBirimFiyati,
                d.AraToplam
            }).ToList();

            HideColumns(_dgwSatisDetay, "SatisDetayID", "SatisID", "IlacID");
        }

        private void BtnSatisAra_Click(object sender, EventArgs e)
        {
            RefreshSalesGrid(_txtSatisAra.Text);
        }

        private void CmbIlac_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ilacId = GetSelectedComboIntValue(_cmbIlac);
            if (!ilacId.HasValue)
            {
                return;
            }

            var ilac = _ilaclarService.TumIlaclariGetir().FirstOrDefault(x => x.IlacID == ilacId.Value);
            if (ilac == null)
            {
                return;
            }

            _txtBirimFiyat.Text = ilac.BirimFiyat.ToString("0.00");
            _txtAraToplam.Text = (ilac.BirimFiyat * _nudAdet.Value).ToString("0.00");
        }

        private void BtnKalemEkle_Click(object sender, EventArgs e)
        {
            var ilacId = GetSelectedComboIntValue(_cmbIlac);
            if (!ilacId.HasValue)
            {
                MessageBox.Show("Lütfen ilaç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ilac = _ilaclarService.TumIlaclariGetir().FirstOrDefault(x => x.IlacID == ilacId.Value);
            if (ilac == null)
            {
                return;
            }

            var adet = (int)_nudAdet.Value;
            var detay = new SatisDetay
            {
                SatisDetayID = _geciciKalemId--,
                IlacID = ilacId,
                Adet = adet,
                SatisBirimFiyati = ilac.BirimFiyat,
                AraToplam = ilac.BirimFiyat * adet
            };

            _geciciDetaylar.Add(detay);
            _selectedKalemId = null;
            RefreshDraftGrid();
            UpdateTotals();
            ClearDetailEntry();
        }

        private void BtnKalemSil_Click(object sender, EventArgs e)
        {
            if (!_selectedKalemId.HasValue)
            {
                MessageBox.Show("Silmek için bir kalem seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var target = _geciciDetaylar.FirstOrDefault(x => x.SatisDetayID == _selectedKalemId.Value);
            if (target == null)
            {
                return;
            }

            _geciciDetaylar.Remove(target);
            _selectedKalemId = null;
            RefreshDraftGrid();
            UpdateTotals();
        }

        private void BtnSatisKaydet_Click(object sender, EventArgs e)
        {
            if (_geciciDetaylar.Count == 0)
            {
                MessageBox.Show("Satış kalemi eklemeden kayıt yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var satis = BuildSaleFromHeader();
            if (satis == null)
            {
                return;
            }

            string err;
            var success = _satislarService.CompleteSale(satis, _geciciDetaylar, out err);
            if (!success)
            {
                MessageBox.Show("Satış kaydedilemedi: " + err, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var created = _satislarService.GetSatisByFaturaNo(satis.FaturaNo);
            if (created != null)
            {
                _selectedSatisId = created.SatisID;
            }

            _geciciDetaylar.Clear();
            _txtFaturaNo.Text = GenerateFaturaNo();
            RefreshSalesGrid();
            RefreshDraftGrid();
            RefreshSaleDetailsGrid();
            UpdateTotals();
            MessageBox.Show("Satış kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnYeni_Click(object sender, EventArgs e)
        {
            _selectedSatisId = null;
            _selectedKalemId = null;
            _geciciDetaylar.Clear();
            _txtFaturaNo.Text = GenerateFaturaNo();
            _rbRecetesiz.Checked = true;
            _cmbOdemeYontemi.SelectedIndex = 0;
            _txtReceteAra.Clear();
            _dtTarih.Value = DateTime.Now;
            _nudIndirim.Value = 0;
            ClearDetailEntry();
            RefreshDraftGrid();
            RefreshSaleDetailsGrid();
            UpdateTotals();
        }

        private void BtnSatisSil_Click(object sender, EventArgs e)
        {
            if (!_selectedSatisId.HasValue)
            {
                MessageBox.Show("Silmek için bir satış seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili satış silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_satislarService.SatisSil(_selectedSatisId.Value))
            {
                MessageBox.Show("Satış silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selectedSatisId = null;
            _selectedKalemId = null;
            RefreshSalesGrid();
            RefreshSaleDetailsGrid();
            _txtFaturaNo.Text = GenerateFaturaNo();
            _geciciDetaylar.Clear();
            RefreshDraftGrid();
            UpdateTotals();
        }

        private void DgwKalemler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _dgwKalemler.Rows[e.RowIndex];
            // If 'Sil' button clicked
            if (e.ColumnIndex >= 0 && _dgwKalemler.Columns[e.ColumnIndex].Name == "Sil")
            {
                var idObj = row.Cells["SatisDetayID"].Value;
                if (idObj != null && int.TryParse(Convert.ToString(idObj), out var id))
                {
                    var target = _geciciDetaylar.FirstOrDefault(x => x.SatisDetayID == id);
                    if (target != null) _geciciDetaylar.Remove(target);
                    RefreshDraftGrid();
                    UpdateTotals();
                }
                return;
            }

            _selectedKalemId = Convert.ToInt32(row.Cells["SatisDetayID"].Value);
            SelectComboValue(_cmbIlac, row.Cells["IlacID"].Value);
            _nudAdet.Value = Convert.ToDecimal(row.Cells["Adet"].Value);
            _txtBirimFiyat.Text = Convert.ToString(row.Cells["SatisBirimFiyati"].Value);
            _txtAraToplam.Text = Convert.ToString(row.Cells["AraToplam"].Value);
        }

        private void DgwSatislar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _dgwSatislar.Rows[e.RowIndex];
            _selectedSatisId = Convert.ToInt32(row.Cells["SatisID"].Value);
            _txtFaturaNo.Text = Convert.ToString(row.Cells["FaturaNo"].Value);
            var satisTuruText = Convert.ToString(row.Cells["SatisTuru"].Value);
            if (string.Equals(satisTuruText, "Reçeteli", StringComparison.OrdinalIgnoreCase))
            {
                _rbReceteli.Checked = true;
            }
            else
            {
                _rbRecetesiz.Checked = true;
            }

            // Recete kodu shown in grid as ReceteKodu
            _txtReceteAra.Text = Convert.ToString(row.Cells["ReceteKodu"].Value);
            _lblReceteHastaName.Text = "-";
            _cmbOdemeYontemi.SelectedItem = Convert.ToString(row.Cells["OdemeYontemi"].Value);
            // Set kasiyer display if available
            _lblKullanici.Text = "Kasiyer: " + Convert.ToString(row.Cells["KullaniciAdi"].Value);
            _dtTarih.Value = Convert.ToDateTime(row.Cells["Tarih"].Value);
            _nudIndirim.Value = Convert.ToDecimal(row.Cells["IndirimTutari"].Value);
            _txtToplam.Text = Convert.ToString(row.Cells["NetTutar"].Value);
            RefreshSaleDetailsGrid();
        }

        private void OnSatisTuruChanged()
        {
            var receteControlsEnabled = _rbReceteli.Checked;
            _txtReceteAra.Enabled = receteControlsEnabled;
            _btnReceteBul.Enabled = receteControlsEnabled;
            if (!receteControlsEnabled)
            {
                _txtReceteAra.Clear();
                _lblReceteHastaName.Text = "-";
            }
        }

        private void BtnReceteBul_Click(object sender, EventArgs e)
        {
            var kode = _txtReceteAra.Text?.Trim();
            if (string.IsNullOrWhiteSpace(kode))
            {
                MessageBox.Show("Lütfen bir reçete no girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var recete = _recetelerService.GetAllReceteler().FirstOrDefault(x => string.Equals(x.ReceteKodu, kode, StringComparison.OrdinalIgnoreCase));
            if (recete == null)
            {
                MessageBox.Show("Reçete bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _lblReceteHastaName.Text = "-";
                return;
            }

            ApplyPrescriptionItemsToDraft(recete.ReceteID);

            if (recete.HastaID.HasValue)
            {
                var hasta = _hastalarService.GetHastaById(recete.HastaID.Value);
                if (hasta != null)
                {
                    _lblReceteHastaName.Text = string.Format("{0} {1}", hasta.Ad, hasta.Soyad).Trim();
                    return;
                }
            }

            _lblReceteHastaName.Text = "-";
        }

        private void ApplyPrescriptionItemsToDraft(int receteId)
        {
            var detaylar = _recetelerService.GetReceteDetaylari(receteId);
            if (detaylar == null || detaylar.Count == 0)
            {
                return;
            }

            var ilacMap = _ilaclarService.TumIlaclariGetir().ToDictionary(x => x.IlacID, x => x);

            _geciciDetaylar.Clear();
            _geciciKalemId = -1;
            _selectedKalemId = null;

            var grouped = detaylar
                .Where(d => d.IlacID.HasValue)
                .GroupBy(d => d.IlacID.Value)
                .Select(g => new { IlacID = g.Key, Adet = g.Sum(x => x.Adet) })
                .Where(x => x.Adet > 0)
                .ToList();

            foreach (var item in grouped)
            {
                if (!ilacMap.TryGetValue(item.IlacID, out var ilac))
                {
                    continue;
                }

                var detay = new SatisDetay
                {
                    SatisDetayID = _geciciKalemId--,
                    IlacID = item.IlacID,
                    Adet = item.Adet,
                    SatisBirimFiyati = ilac.BirimFiyat,
                    AraToplam = ilac.BirimFiyat * item.Adet
                };
                _geciciDetaylar.Add(detay);
            }

            RefreshDraftGrid();
            UpdateTotals();
        }

        private void DgwSatisDetay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = _dgwSatisDetay.Rows[e.RowIndex];
            _selectedSatisId = Convert.ToInt32(row.Cells["SatisID"].Value);
            RefreshSaleDetailsGrid();
        }

        private void UpdateTotals()
        {
            var toplam = _geciciDetaylar.Sum(x => x.AraToplam);
            var net = toplam - _nudIndirim.Value;
            if (net < 0)
            {
                net = 0;
            }

            _txtToplam.Text = net.ToString("0.00");
            _txtAraToplam.Text = _cmbIlac.SelectedValue == null ? string.Empty : _txtAraToplam.Text;
        }

        private void NudIndirim_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void ClearDetailEntry()
        {
            if (_cmbIlac.Items.Count > 0)
            {
                _cmbIlac.SelectedIndex = 0;
            }
            _nudAdet.Value = 1;
            _txtBirimFiyat.Clear();
            _txtAraToplam.Clear();
           
        }

        private Satislar BuildSaleFromHeader()
        {
            if (!_currentKullaniciId.HasValue)
            {
                MessageBox.Show("Kasiyer bilgisi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var satisTuru = _rbReceteli.Checked ? "Reçeteli" : "Reçetesiz";
            int? receteId = null;
            if (_rbReceteli.Checked && !string.IsNullOrWhiteSpace(_txtReceteAra.Text))
            {
                var kode = _txtReceteAra.Text.Trim();
                var recete = _recetelerService.GetAllReceteler().FirstOrDefault(x => string.Equals(x.ReceteKodu, kode, StringComparison.OrdinalIgnoreCase));
                if (recete != null)
                {
                    receteId = recete.ReceteID;
                }
            }

            if (_rbReceteli.Checked && !receteId.HasValue)
            {
                MessageBox.Show("Reçeteli satış için geçerli bir reçete seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Satislar
            {
                FaturaNo = string.IsNullOrWhiteSpace(_txtFaturaNo.Text) ? GenerateFaturaNo() : _txtFaturaNo.Text.Trim(),
                Tarih = _dtTarih.Value,
                SatisTuru = satisTuru,
                ReceteID = receteId,
                ToplamTutar = _geciciDetaylar.Sum(x => x.AraToplam),
                IndirimTutari = _nudIndirim.Value,
                OdemeYontemi = _cmbOdemeYontemi.Text,
                KullaniciID = _currentKullaniciId.Value
            };
        }

        private void HideColumns(DataGridView grid, params string[] columns)
        {
            foreach (var column in columns)
            {
                if (grid.Columns.Contains(column))
                {
                    grid.Columns[column].Visible = false;
                }
            }
        }

        private static string GenerateFaturaNo()
        {
            return "FTR-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void SelectComboValue(ComboBox comboBox, object value)
        {
            if (comboBox == null || value == null || value == DBNull.Value)
            {
                return;
            }

            var target = GetComboDisplayText(value);

            if (comboBox.DataSource != null)
            {
                var intValue = GetComboKeyValue(value);
                if (intValue.HasValue)
                {
                    comboBox.SelectedValue = intValue.Value;
                    return;
                }

                comboBox.SelectedValue = value;
                return;
            }

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (string.Equals(Convert.ToString(comboBox.Items[i]), target, StringComparison.OrdinalIgnoreCase))
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
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
    