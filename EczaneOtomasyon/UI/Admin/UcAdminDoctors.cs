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
    }
}
