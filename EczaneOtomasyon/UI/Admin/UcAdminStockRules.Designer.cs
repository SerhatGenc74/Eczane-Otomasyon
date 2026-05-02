using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    partial class UcAdminStockRules
    {
        private DataGridView _grid;
        private TextBox _txtAra;
        private TextBox _txtIlacAdi;
        private NumericUpDown _nudStok;
        private NumericUpDown _nudKritik;
        private TextBox _txtRafNo;
        private DateTimePicker _dtSonKullanma;

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

            root.Controls.Add(AdminUi.CreatePageTitle("Stok Kontrolü"), 0, 0);
            root.Controls.Add(BuildContent(), 0, 1);

            Controls.Add(root);

            ResumeLayout(false);
        }

        private Control BuildContent()
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(12)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            var leftPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            leftPanel.Controls.Add(BuildSearchBar(), 0, 0);

            _grid = AdminUi.CreateGrid();
            _grid.SelectionChanged += Grid_SelectionChanged;
            leftPanel.Controls.Add(_grid, 0, 1);

            layout.Controls.Add(leftPanel, 0, 0);
            layout.Controls.Add(BuildForm(), 1, 0);

            return layout;
        }

        private Control BuildSearchBar()
        {
            var bar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5
            };
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));

            _txtAra = AdminUi.CreateTextBox();
            var btnAra = AdminUi.CreateActionButton("Ara", Color.FromArgb(59, 130, 246));
            var btnKritik = AdminUi.CreateActionButton("Kritik", Color.FromArgb(239, 68, 68));
            var btnMiad = AdminUi.CreateActionButton("Miad", Color.FromArgb(249, 115, 22));
            var btnTum = AdminUi.CreateActionButton("Tüm", Color.FromArgb(100, 116, 139));

            btnAra.Click += BtnAra_Click;
            btnKritik.Click += BtnKritik_Click;
            btnMiad.Click += BtnMiad_Click;
            btnTum.Click += BtnTum_Click;

            bar.Controls.Add(_txtAra, 0, 0);
            bar.Controls.Add(btnAra, 1, 0);
            bar.Controls.Add(btnKritik, 2, 0);
            bar.Controls.Add(btnMiad, 3, 0);
            bar.Controls.Add(btnTum, 4, 0);
            return bar;
        }

        private Control BuildForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 8
            };
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            form.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _txtIlacAdi = AdminUi.CreateTextBox();
            _txtIlacAdi.ReadOnly = true;
            _nudStok = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 0, Maximum = 100000, Font = new Font("Calibri", 10F) };
            _nudKritik = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 0, Maximum = 100000, Font = new Font("Calibri", 10F) };
            _txtRafNo = AdminUi.CreateTextBox();
            _dtSonKullanma = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Custom, CustomFormat = "dd.MM.yyyy" };

            form.Controls.Add(AdminUi.CreateSectionTitle("Stok Bilgisi"), 0, 0);
            form.Controls.Add(BuildFieldRow("İlaç", _txtIlacAdi), 0, 1);
            form.Controls.Add(BuildFieldRow("Stok Adedi", _nudStok), 0, 2);
            form.Controls.Add(BuildFieldRow("Kritik Seviye", _nudKritik), 0, 3);
            form.Controls.Add(BuildFieldRow("Raf No", _txtRafNo), 0, 4);
            form.Controls.Add(BuildFieldRow("Son Kullanma", _dtSonKullanma), 0, 5);
            form.Controls.Add(BuildButtons(), 0, 6);

            return form;
        }

        private Control BuildFieldRow(string label, Control input)
        {
            var row = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            row.Controls.Add(AdminUi.CreateFormLabel(label), 0, 0);
            row.Controls.Add(input, 1, 0);
            return row;
        }

        private Control BuildButtons()
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

            var btnGuncelle = AdminUi.CreateActionButton("Güncelle", Color.FromArgb(59, 130, 246));
            var btnTemizle = AdminUi.CreateActionButton("Temizle", Color.FromArgb(100, 116, 139));

            btnGuncelle.Click += BtnGuncelle_Click;
            btnTemizle.Click += (s, e) => ClearForm();

            panel.Controls.Add(btnGuncelle, 0, 0);
            panel.Controls.Add(btnTemizle, 1, 0);
            return panel;
        }
    }
}
