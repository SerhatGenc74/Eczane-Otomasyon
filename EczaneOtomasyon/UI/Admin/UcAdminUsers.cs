using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    public partial class UcAdminUsers : UserControl
    {
        private readonly IKullanicilarService _service;
        private int? _selectedId;
        private List<Kullanicilar> _lastList = new List<Kullanicilar>();

        public UcAdminUsers(IKullanicilarService service)
        {
            _service = service;
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            _lastList = _service.GetAllUsers() ?? new List<Kullanicilar>();
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
                    .Where(u =>
                        ContainsText(u.AdSoyad, text) ||
                        ContainsText(u.KullaniciAdi, text) ||
                        ContainsText(u.Rol, text) ||
                        ContainsText(u.KullaniciID.ToString(), text))
                    .ToList();

            _grid.DataSource = filtered.Select(u => new
            {
                u.KullaniciID,
                u.AdSoyad,
                u.KullaniciAdi,
                u.Rol
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

            var idObj = _grid.CurrentRow.Cells["KullaniciID"].Value;
            if (idObj == null)
            {
                return;
            }

            _selectedId = Convert.ToInt32(idObj);
            _txtAdSoyad.Text = Convert.ToString(_grid.CurrentRow.Cells["AdSoyad"].Value);
            _txtKullaniciAdi.Text = Convert.ToString(_grid.CurrentRow.Cells["KullaniciAdi"].Value);
            _cmbRol.SelectedItem = Convert.ToString(_grid.CurrentRow.Cells["Rol"].Value);
            _txtSifre.Clear();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtAdSoyad.Text) || string.IsNullOrWhiteSpace(_txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(_txtSifre.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new Kullanicilar
            {
                AdSoyad = _txtAdSoyad.Text.Trim(),
                KullaniciAdi = _txtKullaniciAdi.Text.Trim(),
                Sifre = _txtSifre.Text,
                Rol = _cmbRol.Text
            };

            if (!_service.KullaniciEkle(user))
            {
                MessageBox.Show("Kullanıcı eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadUsers();
            ClearForm();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Güncellemek için bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var password = _txtSifre.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                var existing = _service.GetAllUsers().FirstOrDefault(u => u.KullaniciID == _selectedId.Value);
                password = existing?.Sifre;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Şifre alanı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new Kullanicilar
            {
                KullaniciID = _selectedId.Value,
                AdSoyad = _txtAdSoyad.Text.Trim(),
                KullaniciAdi = _txtKullaniciAdi.Text.Trim(),
                Sifre = password,
                Rol = _cmbRol.Text
            };

            if (!_service.KullaniciGuncelle(user))
            {
                MessageBox.Show("Kullanıcı güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadUsers();
            ClearForm();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Silmek için bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili kullanıcı silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!_service.DeleteUser(_selectedId.Value))
            {
                MessageBox.Show("Kullanıcı silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadUsers();
            ClearForm();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedId = null;
            _txtAdSoyad.Clear();
            _txtKullaniciAdi.Clear();
            _txtSifre.Clear();
            if (_cmbRol.Items.Count > 0)
            {
                _cmbRol.SelectedIndex = 0;
            }
        }
    }
}
