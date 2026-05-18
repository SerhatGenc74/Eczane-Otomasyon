using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    partial class UcAdminCategories
    {
        private DataGridView _gridKategori;
        private DataGridView _gridReceteTur;
        private TextBox _txtKategoriFilter;
        private TextBox _txtReceteTurFilter;
        private TextBox _txtKategoriAdi;
        private TextBox _txtReceteTurAdi;

        private void InitializeComponent()
        {
            SuspendLayout();

            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(241, 245, 249);

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            root.Controls.Add(AdminUi.CreatePageTitle("Kategori Yönetimi"), 0, 0);
            root.Controls.Add(BuildTabs(), 0, 1);

            Controls.Add(root);

            ResumeLayout(false);
        }

        private Control BuildTabs()
        {
            var tabs = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Calibri", 10F)
            };

            tabs.TabPages.Add(BuildKategoriTab());
            tabs.TabPages.Add(BuildReceteTurTab());
            return tabs;
        }

        private TabPage BuildKategoriTab()
        {
            var page = new TabPage("Kategoriler")
            {
                Padding = new Padding(8)
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            var leftPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftPanel.ColumnCount = 1;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            _txtKategoriFilter = AdminUi.CreateTextBox();
            _txtKategoriFilter.TextChanged += TxtKategoriFilter_TextChanged;
            leftPanel.Controls.Add(_txtKategoriFilter, 0, 0);

            _gridKategori = AdminUi.CreateGrid();
            _gridKategori.SelectionChanged += GridKategori_SelectionChanged;

            leftPanel.Controls.Add(_gridKategori, 0, 1);

            layout.Controls.Add(leftPanel, 0, 0);
            layout.Controls.Add(BuildKategoriForm(), 1, 0);

            page.Controls.Add(layout);
            return page;
        }

        private TabPage BuildReceteTurTab()
        {
            var page = new TabPage("Reçete Türleri")
            {
                Padding = new Padding(8)
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            var leftPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftPanel.ColumnCount = 1;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            _txtReceteTurFilter = AdminUi.CreateTextBox();
            _txtReceteTurFilter.TextChanged += TxtReceteTurFilter_TextChanged;
            leftPanel.Controls.Add(_txtReceteTurFilter, 0, 0);

            _gridReceteTur = AdminUi.CreateGrid();
            _gridReceteTur.SelectionChanged += GridReceteTur_SelectionChanged;

            leftPanel.Controls.Add(_gridReceteTur, 0, 1);

            layout.Controls.Add(leftPanel, 0, 0);
            layout.Controls.Add(BuildReceteTurForm(), 1, 0);

            page.Controls.Add(layout);
            return page;
        }

        private Control BuildKategoriForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 4
            };
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            form.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _txtKategoriAdi = AdminUi.CreateTextBox();

            form.Controls.Add(AdminUi.CreateSectionTitle("Kategori Bilgisi"), 0, 0);
            form.Controls.Add(BuildFieldRow("Kategori Adı", _txtKategoriAdi), 0, 1);
            form.Controls.Add(BuildKategoriButtons(), 0, 2);
            return form;
        }

        private Control BuildReceteTurForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 4
            };
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            form.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _txtReceteTurAdi = AdminUi.CreateTextBox();

            form.Controls.Add(AdminUi.CreateSectionTitle("Reçete Türü"), 0, 0);
            form.Controls.Add(BuildFieldRow("Tür Adı", _txtReceteTurAdi), 0, 1);
            form.Controls.Add(BuildReceteTurButtons(), 0, 2);
            return form;
        }

        private Control BuildFieldRow(string label, Control input)
        {
            var row = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            row.Controls.Add(AdminUi.CreateFormLabel(label), 0, 0);
            row.Controls.Add(input, 1, 0);
            return row;
        }

        private Control BuildKategoriButtons()
        {
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                RowCount = 2,
                Height = 90
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            var btnEkle = AdminUi.CreateActionButton("Ekle", Color.FromArgb(34, 197, 94));
            var btnGuncelle = AdminUi.CreateActionButton("Güncelle", Color.FromArgb(59, 130, 246));
            var btnSil = AdminUi.CreateActionButton("Sil", Color.FromArgb(239, 68, 68));
            var btnTemizle = AdminUi.CreateActionButton("Temizle", Color.FromArgb(100, 116, 139));

            btnEkle.Click += BtnKategoriEkle_Click;
            btnGuncelle.Click += BtnKategoriGuncelle_Click;
            btnSil.Click += BtnKategoriSil_Click;
            btnTemizle.Click += (s, e) => ClearKategoriForm();

            panel.Controls.Add(btnEkle, 0, 0);
            panel.Controls.Add(btnGuncelle, 1, 0);
            panel.Controls.Add(btnSil, 0, 1);
            panel.Controls.Add(btnTemizle, 1, 1);

            return panel;
        }

        private Control BuildReceteTurButtons()
        {
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                RowCount = 2,
                Height = 90
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            var btnEkle = AdminUi.CreateActionButton("Ekle", Color.FromArgb(34, 197, 94));
            var btnGuncelle = AdminUi.CreateActionButton("Güncelle", Color.FromArgb(59, 130, 246));
            var btnSil = AdminUi.CreateActionButton("Sil", Color.FromArgb(239, 68, 68));
            var btnTemizle = AdminUi.CreateActionButton("Temizle", Color.FromArgb(100, 116, 139));

            btnEkle.Click += BtnReceteTurEkle_Click;
            btnGuncelle.Click += BtnReceteTurGuncelle_Click;
            btnSil.Click += BtnReceteTurSil_Click;
            btnTemizle.Click += (s, e) => ClearReceteTurForm();

            panel.Controls.Add(btnEkle, 0, 0);
            panel.Controls.Add(btnGuncelle, 1, 0);
            panel.Controls.Add(btnSil, 0, 1);
            panel.Controls.Add(btnTemizle, 1, 1);

            return panel;
        }
    }
}
