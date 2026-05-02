using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    partial class UcAdminPatients
    {
        private DataGridView _grid;
        private TextBox _txtTc;
        private TextBox _txtAd;
        private TextBox _txtSoyad;
        private TextBox _txtTelefon;
        private ComboBox _cmbCinsiyet;
        private ComboBox _cmbKanGrubu;
        private TextBox _txtAlerji;

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

            root.Controls.Add(AdminUi.CreatePageTitle("Hasta Düzenleme"), 0, 0);
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

            _grid = AdminUi.CreateGrid();
            _grid.SelectionChanged += Grid_SelectionChanged;

            layout.Controls.Add(_grid, 0, 0);
            layout.Controls.Add(BuildForm(), 1, 0);

            return layout;
        }

        private Control BuildForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 9
            };
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            form.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _txtTc = AdminUi.CreateTextBox();
            _txtAd = AdminUi.CreateTextBox();
            _txtSoyad = AdminUi.CreateTextBox();
            _txtTelefon = AdminUi.CreateTextBox();
            _cmbCinsiyet = AdminUi.CreateComboBox(new[] { "Kadın", "Erkek", "Diğer" });
            _cmbKanGrubu = AdminUi.CreateComboBox(new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" });
            _txtAlerji = AdminUi.CreateTextBox(true);

            form.Controls.Add(AdminUi.CreateSectionTitle("Hasta Bilgisi"), 0, 0);
            form.Controls.Add(BuildFieldRow("T.C. Kimlik", _txtTc), 0, 1);
            form.Controls.Add(BuildFieldRow("Ad", _txtAd), 0, 2);
            form.Controls.Add(BuildFieldRow("Soyad", _txtSoyad), 0, 3);
            form.Controls.Add(BuildFieldRow("Telefon", _txtTelefon), 0, 4);
            form.Controls.Add(BuildFieldRow("Cinsiyet", _cmbCinsiyet), 0, 5);
            form.Controls.Add(BuildFieldRow("Kan Grubu", _cmbKanGrubu), 0, 6);
            form.Controls.Add(BuildFieldRow("Alerji", _txtAlerji), 0, 7);
            form.Controls.Add(BuildButtons(), 0, 8);

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
