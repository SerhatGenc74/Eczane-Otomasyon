using EczaneOtomasyon.Bussines.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        private readonly IAuthService _authService;
        private readonly IKullanicilarService _kullanicilarService;
        private readonly IKategoriService _kategoriService;
        private readonly IReceteTurService _receteTurService;
        private readonly IHastalarService _hastalarService;
        private readonly IIlaclarService _ilaclarService;

        private readonly Dictionary<AdminPage, Button> _menuButtons = new Dictionary<AdminPage, Button>();

        private UcAdminDashboardHome _home;
        private UcAdminUsers _users;
        private UcAdminCategories _categories;
        private UcAdminPatients _patients;
        private UcAdminStockRules _stockRules;
        private UcAdminMedicines _medicines;

        public FrmAdminDashboard(IAuthService authService,
            IKullanicilarService kullanicilarService,
            IKategoriService kategoriService,
            IReceteTurService receteTurService,
            IHastalarService hastalarService,
            IIlaclarService ilaclarService)
        {
            _authService = authService;
            _kullanicilarService = kullanicilarService;
            _kategoriService = kategoriService;
            _receteTurService = receteTurService;
            _hastalarService = hastalarService;
            _ilaclarService = ilaclarService;

            InitializeComponent();
            InitializeMenu();
            _userLabel.Text = GetUserLabelText();
            Navigate(AdminPage.Home);
        }

        private void InitializeMenu()
        {
            AddMenuButton(_menuPanel, AdminPage.Home, "Ana Sayfa");
            AddMenuButton(_menuPanel, AdminPage.Users, "Kullanıcılar");
            AddMenuButton(_menuPanel, AdminPage.Categories, "Kategoriler");
            AddMenuButton(_menuPanel, AdminPage.Patients, "Hastalar");
            AddMenuButton(_menuPanel, AdminPage.StockRules, "Stok Kontrolü");
            AddMenuButton(_menuPanel, AdminPage.Medicines, "İlaçlar");

            if (_btnLogout != null)
            {
                _btnLogout.Click += BtnLogout_Click;
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            _authService?.SetCurrentUser(null);
            Close();
        }

        private void AddMenuButton(FlowLayoutPanel menu, AdminPage page, string text)
        {
            var button = new Button
            {
                Text = text,
                Width = 190,
                Height = 42,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Calibri", 10F, FontStyle.Bold),
                Padding = new Padding(12, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += (s, e) => Navigate(page);

            _menuButtons[page] = button;
            menu.Controls.Add(button);
        }

        private void Navigate(AdminPage page)
        {
            var view = ResolvePage(page);
            _contentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            _contentPanel.Controls.Add(view);

            SetActiveMenu(page);
        }

        private UserControl ResolvePage(AdminPage page)
        {
            switch (page)
            {
                case AdminPage.Users:
                    return _users ?? (_users = new UcAdminUsers(_kullanicilarService));
                case AdminPage.Categories:
                    return _categories ?? (_categories = new UcAdminCategories(_kategoriService, _receteTurService));
                case AdminPage.Patients:
                    return _patients ?? (_patients = new UcAdminPatients(_hastalarService));
                case AdminPage.StockRules:
                    return _stockRules ?? (_stockRules = new UcAdminStockRules(_ilaclarService));
                case AdminPage.Medicines:
                    return _medicines ?? (_medicines = new UcAdminMedicines(_ilaclarService, _kategoriService, _receteTurService));
                default:
                    if (_home == null)
                    {
                        _home = new UcAdminDashboardHome();
                        _home.CardSelected += Navigate;
                    }
                    return _home;
            }
        }

        private void SetActiveMenu(AdminPage page)
        {
            foreach (var item in _menuButtons)
            {
                item.Value.BackColor = item.Key == page ? Color.FromArgb(59, 130, 246) : Color.FromArgb(30, 41, 59);
            }
        }

        private string GetUserLabelText()
        {
            var user = _authService?.GetCurrentUser();
            return user == null ? "Aktif Kullanıcı: -" : "Aktif Kullanıcı: " + user.AdSoyad;
        }
    }
}
