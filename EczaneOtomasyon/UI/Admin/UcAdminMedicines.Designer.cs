using System;
using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    partial class UcAdminMedicines
    {
        private DataGridView _grid;
        private TextBox _txtFilter;
        private TextBox _txtIlacAdi;
        private ComboBox _cmbKategori;
        private ComboBox _cmbTur;
        private NumericUpDown _nudBirimFiyat;
        private NumericUpDown _nudStok;
        private NumericUpDown _nudKritik;
        private DateTimePicker _dtSkt;
        private TextBox _txtRafNo;

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

            root.Controls.Add(AdminUi.CreatePageTitle("İlaç Yönetimi"), 0, 0);
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
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));

            var leftPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftPanel.ColumnCount = 1;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            _txtFilter = AdminUi.CreateTextBox();
            _txtFilter.TextChanged += TxtFilter_TextChanged;
            leftPanel.Controls.Add(_txtFilter, 0, 0);

            _grid = AdminUi.CreateGrid();
            _grid.SelectionChanged += Grid_SelectionChanged;

            leftPanel.Controls.Add(_grid, 0, 1);

            layout.Controls.Add(leftPanel, 0, 0);
            layout.Controls.Add(BuildForm(), 1, 0);

            return layout;
        }

        private Control BuildForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 11
            };
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            for (int i = 0; i < 8; i++)
            {
                form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            }
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            form.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _txtIlacAdi = AdminUi.CreateTextBox();
            _cmbKategori = AdminUi.CreateComboBox();
            _cmbTur = AdminUi.CreateComboBox();

            _nudBirimFiyat = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                DecimalPlaces = 2,
                Maximum = 999999,
                Font = new Font("Calibri", 10F)
            };

            _nudStok = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Maximum = 999999,
                Font = new Font("Calibri", 10F)
            };

            _nudKritik = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Maximum = 999999,
                Font = new Font("Calibri", 10F)
            };

            _dtSkt = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Short
            };

            _txtRafNo = AdminUi.CreateTextBox();

            form.Controls.Add(AdminUi.CreateSectionTitle("İlaç Bilgisi"), 0, 0);
            form.Controls.Add(BuildFieldRow("İlaç Adı", _txtIlacAdi), 0, 1);
            form.Controls.Add(BuildFieldRow("Kategori", _cmbKategori), 0, 2);
            form.Controls.Add(BuildFieldRow("Tür", _cmbTur), 0, 3);
            form.Controls.Add(BuildFieldRow("Birim Fiyat", _nudBirimFiyat), 0, 4);
            form.Controls.Add(BuildFieldRow("Stok", _nudStok), 0, 5);
            form.Controls.Add(BuildFieldRow("Kritik", _nudKritik), 0, 6);
            form.Controls.Add(BuildFieldRow("SKT", _dtSkt), 0, 7);
            form.Controls.Add(BuildFieldRow("Raf No", _txtRafNo), 0, 8);
            form.Controls.Add(BuildButtons(), 0, 9);

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

            var btnEkle = AdminUi.CreateActionButton("Ekle", Color.FromArgb(34, 197, 94));
            var btnGuncelle = AdminUi.CreateActionButton("Güncelle", Color.FromArgb(59, 130, 246));
            var btnSil = AdminUi.CreateActionButton("Sil", Color.FromArgb(239, 68, 68));
            var btnTemizle = AdminUi.CreateActionButton("Temizle", Color.FromArgb(100, 116, 139));

            btnEkle.Click += BtnEkle_Click;
            btnGuncelle.Click += BtnGuncelle_Click;
            btnSil.Click += BtnSil_Click;
            btnTemizle.Click += (s, e) => ClearForm();

            panel.Controls.Add(btnEkle, 0, 0);
            panel.Controls.Add(btnGuncelle, 1, 0);
            panel.Controls.Add(btnSil, 0, 1);
            panel.Controls.Add(btnTemizle, 1, 1);

            return panel;
        }
    }
}
