using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    public partial class UcAdminStockRules : UserControl
    {
        private readonly IIlaclarService _service;
        private List<Ilaclar> _lastList = new List<Ilaclar>();
        private Func<List<Ilaclar>> _currentLoader;
        private Ilaclar _selected;

        public UcAdminStockRules(IIlaclarService service)
        {
            _service = service;
            InitializeComponent();

            _currentLoader = () => _service.TumIlaclariGetir();
            LoadIlaclar(_currentLoader);
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            var text = _txtAra.Text?.Trim();
            _currentLoader = () => string.IsNullOrWhiteSpace(text) ? _service.TumIlaclariGetir() : _service.IlacAra(text);
            LoadIlaclar(_currentLoader);
        }

        private void BtnKritik_Click(object sender, EventArgs e)
        {
            _currentLoader = () => _service.KritikStoktakiIlaclariGetir();
            LoadIlaclar(_currentLoader);
        }

        private void BtnMiad_Click(object sender, EventArgs e)
        {
            _currentLoader = () => _service.MiadiYaklasanIlaclariGetir();
            LoadIlaclar(_currentLoader);
        }

        private void BtnTum_Click(object sender, EventArgs e)
        {
            _txtAra.Clear();
            _currentLoader = () => _service.TumIlaclariGetir();
            LoadIlaclar(_currentLoader);
        }

        private void LoadIlaclar(Func<List<Ilaclar>> loader)
        {
            if (loader == null)
            {
                return;
            }

            _lastList = loader() ?? new List<Ilaclar>();
            _grid.DataSource = _lastList.Select(i => new
            {
                i.IlacID,
                i.IlacAdi,
                i.StokAdedi,
                i.KritikSeviye,
                i.RafNo,
                SonKullanmaTarihi = i.SonKullanmaTarihi
            }).ToList();
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

            var id = Convert.ToInt32(idObj);
            _selected = _lastList.FirstOrDefault(x => x.IlacID == id);
            if (_selected == null)
            {
                return;
            }

            _txtIlacAdi.Text = _selected.IlacAdi;
            _nudStok.Value = Math.Max(0, _selected.StokAdedi);
            _nudKritik.Value = Math.Max(0, _selected.KritikSeviye);
            _txtRafNo.Text = _selected.RafNo;
            _dtSonKullanma.Value = _selected.SonKullanmaTarihi == DateTime.MinValue ? DateTime.Today : _selected.SonKullanmaTarihi;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Güncellemek için ilaç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selected.StokAdedi = (int)_nudStok.Value;
            _selected.KritikSeviye = (int)_nudKritik.Value;
            _selected.RafNo = _txtRafNo.Text?.Trim();
            _selected.SonKullanmaTarihi = _dtSonKullanma.Value.Date;

            if (!_service.IlacGuncelle(_selected))
            {
                MessageBox.Show("Stok güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadIlaclar(_currentLoader ?? (() => _service.TumIlaclariGetir()));
            ClearForm();
        }

        private void ClearForm()
        {
            _selected = null;
            _txtIlacAdi.Clear();
            _nudStok.Value = 0;
            _nudKritik.Value = 0;
            _txtRafNo.Clear();
            _dtSonKullanma.Value = DateTime.Today;
        }
    }
}
