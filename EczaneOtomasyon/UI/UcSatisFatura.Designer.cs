using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI
{
    partial class UcSatisFatura
    {
        private TextBox _txtFaturaNo;
        private RadioButton _rbReceteli;
        private RadioButton _rbRecetesiz;
        private TextBox _txtReceteAra;
        private Button _btnReceteBul;
        private Label _lblReceteHastaName;
        private ComboBox _cmbOdemeYontemi;
        private Label _lblKullanici;
        private DateTimePicker _dtTarih;
        private NumericUpDown _nudIndirim;
        private TextBox _txtToplam;

        private ComboBox _cmbIlac;
        private NumericUpDown _nudAdet;
        private TextBox _txtBirimFiyat;
        private TextBox _txtAraToplam;
        private Button _btnKalemEkle;
        private Button _btnKalemSil;
        private DataGridView _dgwKalemler;

        private TextBox _txtSatisAra;
        private Button _btnSatisAra;
        private ComboBox _cmbSatisSirala;
        private DataGridView _dgwSatislar;
        private DataGridView _dgwSatisDetay;

        private void InitializeComponent()
        {
            SuspendLayout();

            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(241, 245, 249);


            var body = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(12)
            };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53F));

            body.Controls.Add(BuildSaleEntryPanel(), 0, 0);
            body.Controls.Add(BuildSaleListPanel(), 1, 0);

            Controls.Add(body);

            Load += UcSatisFatura_Load;

            ResumeLayout(false);
        }

        private Control BuildSaleEntryPanel()
        {
            var card = CreateCardPanel();
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 6,
                Padding = new Padding(10)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 168F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));

            root.Controls.Add(CreateSectionTitle("Satış Başlığı"), 0, 0);
            root.Controls.Add(BuildHeaderForm(), 0, 1);
            root.Controls.Add(CreateSectionTitle("Satış Kalemleri"), 0, 2);
            root.Controls.Add(BuildDetailEntryForm(), 0, 3);
            root.Controls.Add(BuildDraftGrid(), 0, 4);
            root.Controls.Add(BuildActionBar(), 0, 5);

            card.Controls.Add(root);
            return card;
        }

        private Control BuildSaleListPanel()
        {
            var card = CreateCardPanel();
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(10)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            root.Controls.Add(CreateSectionTitle("Geçmiş Satışlar"), 0, 0);
            root.Controls.Add(BuildSearchBar(), 0, 1);
            root.Controls.Add(BuildSalesGrid(), 0, 2);
            root.Controls.Add(BuildSalesDetailGrid(), 0, 3);

            card.Controls.Add(root);
            return card;
        }

        private Control BuildHeaderForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4
            };

            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            for (int i = 0; i < 4; i++)
            {
                form.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            }

            _txtFaturaNo = CreateTextBox();
            _txtFaturaNo.ReadOnly = true;
            _txtFaturaNo.BackColor = Color.LightGray;

            _rbReceteli = new RadioButton { Text = "Reçeteli", Dock = DockStyle.Left, AutoSize = true };
            _rbRecetesiz = new RadioButton { Text = "Reçetesiz", Dock = DockStyle.Left, AutoSize = true };
            _rbReceteli.CheckedChanged += (s, e) => OnSatisTuruChanged();
            _rbRecetesiz.CheckedChanged += (s, e) => OnSatisTuruChanged();

            _txtReceteAra = CreateTextBox();
            _btnReceteBul = CreateActionButton("Bul", Color.FromArgb(30, 64, 175));
            _btnReceteBul.Click += BtnReceteBul_Click;
            _lblReceteHastaName = new Label { Dock = DockStyle.Fill, Text = "-", TextAlign = ContentAlignment.MiddleLeft };

            _cmbOdemeYontemi = CreateComboBox(new[] { "Nakit", "Kredi Kartı", "Havale" });
            _lblKullanici = new Label { Dock = DockStyle.Fill, Text = "Kasiyer: -", TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9.5F) };
            _dtTarih = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy HH:mm"
            };
            _dtTarih.Enabled = false;
            _nudIndirim = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                DecimalPlaces = 2,
                Maximum = 999999,
                Font = new Font("Segoe UI", 9.5F)
            };
            _nudIndirim.ValueChanged += NudIndirim_ValueChanged;
            _txtToplam = CreateTextBox();
            _txtToplam.ReadOnly = true;

            form.Controls.Add(CreateLabel("Fatura No"), 0, 0);
            form.Controls.Add(_txtFaturaNo, 1, 0);
            form.Controls.Add(CreateLabel("Satış Türü"), 2, 0);
            var rbPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            rbPanel.Controls.Add(_rbReceteli);
            rbPanel.Controls.Add(_rbRecetesiz);
            form.Controls.Add(rbPanel, 3, 0);

            form.Controls.Add(CreateLabel("Reçete No"), 0, 1);
            var recetePanel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3 };
            recetePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            recetePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            recetePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            recetePanel.Controls.Add(_txtReceteAra, 0, 0);
            recetePanel.Controls.Add(_btnReceteBul, 1, 0);
            recetePanel.Controls.Add(_lblReceteHastaName, 2, 0);
            form.Controls.Add(recetePanel, 1, 1);

            form.Controls.Add(CreateLabel("Ödeme"), 2, 1);
            form.Controls.Add(_cmbOdemeYontemi, 3, 1);

            form.Controls.Add(CreateLabel("Kasiyer"), 0, 2);
            form.Controls.Add(_lblKullanici, 1, 2);
            form.Controls.Add(CreateLabel("Tarih"), 2, 2);
            form.Controls.Add(_dtTarih, 3, 2);

            return form;
        }

        private Control BuildDetailEntryForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4
            };

            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            form.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _cmbIlac = CreateComboBox();
            _cmbIlac.DropDownStyle = ComboBoxStyle.DropDown; // allow typing/search
            _cmbIlac.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _cmbIlac.AutoCompleteSource = AutoCompleteSource.ListItems;
            _cmbIlac.SelectedIndexChanged += CmbIlac_SelectedIndexChanged;
            _nudAdet = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Minimum = 1,
                Maximum = 1000,
                Value = 1,
                Font = new Font("Segoe UI", 9.5F)
            };
            _txtBirimFiyat = CreateTextBox();
            _txtBirimFiyat.ReadOnly = true;
            _txtAraToplam = CreateTextBox();
            _txtAraToplam.ReadOnly = true;
          
            _btnKalemEkle = CreateActionButton("Sepete Ekle", Color.FromArgb(14, 116, 144));
            _btnKalemEkle.Dock = DockStyle.Top;
            _btnKalemEkle.Height = 34;
            _btnKalemEkle.Margin = new Padding(3, 0, 3, 0);
            _btnKalemEkle.Click += BtnKalemEkle_Click;
            _btnKalemSil = CreateActionButton("Kalem Sil", Color.FromArgb(220, 38, 38));
            _btnKalemSil.Dock = DockStyle.Top;
            _btnKalemSil.Height = 34;
            _btnKalemSil.Margin = new Padding(3, 0, 3, 0);
            _btnKalemSil.Click += BtnKalemSil_Click;

            form.Controls.Add(CreateLabel("İlaç"), 0, 0);
            form.Controls.Add(_cmbIlac, 1, 0);
            form.Controls.Add(CreateLabel("Adet"), 2, 0);
            form.Controls.Add(_nudAdet, 3, 0);

            form.Controls.Add(CreateLabel("Birim Fiyat"), 0, 1);
            form.Controls.Add(_txtBirimFiyat, 1, 1);
            form.Controls.Add(CreateLabel("Ara Toplam"), 2, 1);
            form.Controls.Add(_txtAraToplam, 3, 1);

            // Butonları textbox kolonlarıyla aynı hizada yerleştir
            form.Controls.Add(_btnKalemEkle, 1, 2);
            form.Controls.Add(_btnKalemSil, 3, 2);

            return form;
        }

        private Control BuildActionBar()
        {
            var bar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            bar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var actions = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actions.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            var btnKaydet = CreateActionButton("Satışı Tamamla", Color.FromArgb(22, 163, 74));
            btnKaydet.Text = "Satışı Tamamla";
            btnKaydet.Click += BtnSatisKaydet_Click;
            var btnIptal = CreateActionButton("Yeni Satış", Color.FromArgb(220, 38, 38));
            btnIptal.Text = "Yeni Satış";
            btnIptal.Click += BtnYeni_Click;
            actions.Controls.Add(btnKaydet, 0, 1);
            actions.Controls.Add(btnIptal, 1, 1);

            var totalsPanel = new Panel { Dock = DockStyle.Fill };
            var totalsLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            totalsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            totalsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));


            var lblIndirimTitle = new Label { Text = "İndirim Tutarı", Dock = DockStyle.Fill, TextAlign = ContentAlignment.BottomRight };
            _nudIndirim.Dock = DockStyle.Fill;

            var lblNetTitle = new Label { Text = "Ödenecek Tutar", Dock = DockStyle.Fill, TextAlign = ContentAlignment.BottomRight };
            _txtToplam.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            _txtToplam.TextAlign = HorizontalAlignment.Right;
            _txtToplam.ReadOnly = true;

            var row1 = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            row1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            row1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            row1.Controls.Add(lblIndirimTitle, 0, 0);
            row1.Controls.Add(_nudIndirim, 1, 0);

            var row2 = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            row2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            row2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            row2.Controls.Add(lblNetTitle, 0, 0);
            row2.Controls.Add(_txtToplam, 1, 0);

            totalsLayout.Controls.Add(row1, 0, 0);
            totalsLayout.Controls.Add(row2, 0, 1);
            totalsPanel.Controls.Add(totalsLayout);

            bar.Controls.Add(actions, 0, 0);
            bar.Controls.Add(totalsPanel, 1, 0);
            return bar;
        }

        private Control BuildDraftGrid()
        {
            _dgwKalemler = CreateGrid();
            _dgwKalemler.CellClick += DgwKalemler_CellClick;
            return _dgwKalemler;
        }

        private Control BuildSearchBar()
        {
            var bar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5
            };
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));

            _txtSatisAra = CreateTextBox();
            _btnSatisAra = CreateActionButton("Ara", Color.FromArgb(30, 64, 175));
            _btnSatisAra.Click += BtnSatisAra_Click;

            _cmbSatisSirala = CreateComboBox(new[] { "Yeniden Eskiye", "Eskiden Yeniye" });
            _cmbSatisSirala.SelectedIndexChanged += CmbSatisSirala_SelectedIndexChanged;

            bar.Controls.Add(CreateLabel("Satış Ara"), 0, 0);
            bar.Controls.Add(_txtSatisAra, 1, 0);
            bar.Controls.Add(_btnSatisAra, 2, 0);
            bar.Controls.Add(CreateLabel("Sıralama"), 3, 0);
            bar.Controls.Add(_cmbSatisSirala, 4, 0);
            return bar;
        }

        private Control BuildSalesGrid()
        {
            _dgwSatislar = CreateGrid();
            _dgwSatislar.CellClick += DgwSatislar_CellClick;
            return _dgwSatislar;
        }

        private Control BuildSalesDetailGrid()
        {
            _dgwSatisDetay = CreateGrid();
            _dgwSatisDetay.Height = 140;
            _dgwSatisDetay.CellClick += DgwSatisDetay_CellClick;
            return _dgwSatisDetay;
        }

        private static Panel CreateCardPanel()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private static Label CreateSectionTitle(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42)
            };
        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(51, 65, 85)
            };
        }

        private static TextBox CreateTextBox()
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F)
            };
        }

        private static ComboBox CreateComboBox()
        {
            return new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5F)
            };
        }

        private static ComboBox CreateComboBox(IEnumerable<string> items)
        {
            var combo = CreateComboBox();
            combo.Items.AddRange(items.Cast<object>().ToArray());
            combo.SelectedIndex = 0;
            return combo;
        }

        private static Button CreateActionButton(string text, Color backColor)
        {
            var button = new Button
            {
                Text = text,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = backColor,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private static DataGridView CreateGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };
        }
    }
}
