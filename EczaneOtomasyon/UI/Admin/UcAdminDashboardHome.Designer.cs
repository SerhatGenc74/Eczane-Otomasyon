using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    partial class UcAdminDashboardHome
    {
        private TableLayoutPanel _rootLayout;

        private void InitializeComponent()
        {
            SuspendLayout();

            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(241, 245, 249);

            _rootLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            _rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _rootLayout.Controls.Add(AdminUi.CreatePageTitle("Ana Sayfa"), 0, 0);
            _rootLayout.Controls.Add(BuildCards(), 0, 1);

            Controls.Add(_rootLayout);

            ResumeLayout(false);
        }

        private Control BuildCards()
        {
            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(12)
            };

            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));

            grid.Controls.Add(AdminUi.CreateCard("Kullanıcı Yönetimi", "Kullanıcı ekle, rol güncelle, şifre işlemleri", Color.FromArgb(34, 197, 94), (s, e) => Raise(AdminPage.Users)), 0, 0);
            grid.Controls.Add(AdminUi.CreateCard("Kategori Yönetimi", "İlaç kategorileri ve reçete türleri", Color.FromArgb(14, 165, 233), (s, e) => Raise(AdminPage.Categories)), 1, 0);
            grid.Controls.Add(AdminUi.CreateCard("Doktor Yönetimi", "Doktor bilgisi ve kurum kayıtları", Color.FromArgb(249, 115, 22), (s, e) => Raise(AdminPage.Doctors)), 0, 1);
            grid.Controls.Add(AdminUi.CreateCard("Hasta Düzenleme", "Hasta iletişim, alerji, kan grubu güncelle", Color.FromArgb(168, 85, 247), (s, e) => Raise(AdminPage.Patients)), 1, 1);
            grid.Controls.Add(AdminUi.CreateCard("Stok Kontrolü", "Kritik seviye, raf no ve alarm ayarları", Color.FromArgb(244, 63, 94), (s, e) => Raise(AdminPage.StockRules)), 0, 2);
            grid.Controls.Add(CreateEmptyCard(), 1, 2);

            return grid;
        }

        private Control CreateEmptyCard()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                BackColor = Color.FromArgb(241, 245, 249)
            };
        }
    }
}
