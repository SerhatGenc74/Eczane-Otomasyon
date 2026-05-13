using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI
{
    partial class UcHastaRecete
    {
        private TextBox _txtTc;
        private TextBox _txtAd;
        private TextBox _txtSoyad;
        private TextBox _txtTelefon;
        private ComboBox _cmbCinsiyet;
        private ComboBox _cmbKanGrubu;
        private TextBox _txtAlerji;
        private Button _btnHastaKaydet;
        private Button _btnHastaGuncelle;
        // Eczacı panelinde hasta silme kapalı
        private TextBox _txtHastaAra;
        private Button _btnHastaAra;
        private DataGridView _dgwHastalar;

        private TextBox _txtReceteKodu;
        private TextBox _txtReceteHastaTc;
        private Button _btnReceteHastaBul;
        private ComboBox _cmbDoktor;
        private ComboBox _cmbReceteTuru;
        private DateTimePicker _dtTarih;
        private CheckBox _chkDurum;
        private Button _btnReceteKaydet;
        private Button _btnReceteGuncelle;
        private Button _btnReceteSil;
        private DataGridView _dgwReceteler;

        private ComboBox _cmbIlac;
        private NumericUpDown _nudAdet;
        private TextBox _txtKullanimSekli;
        private Button _btnDetayEkle;
        private Button _btnDetaySil;
        private DataGridView _dgwDetaylar;

        private void InitializeComponent()
        {
            SuspendLayout();

            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(241, 245, 249);


            var body = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(12)
            };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));

            body.Controls.Add(BuildHastaPanel(), 0, 0);
            body.Controls.Add(BuildRecetePanel(), 1, 0);

            Controls.Add(body);

            Load += UcHastaRecete_Load;

            ResumeLayout(false);
        }

        private Control BuildHastaPanel()
        {
            var card = CreateCardPanel();
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                Padding = new Padding(10)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 172F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            root.Controls.Add(CreateSectionTitle("Hasta Kayıt"), 0, 0);
            root.Controls.Add(BuildHastaForm(), 0, 1);
            root.Controls.Add(BuildHastaButtons(), 0, 2);
            root.Controls.Add(BuildHastaAramaBar(), 0, 3);
            root.Controls.Add(BuildHastaGrid(), 0, 4);

            card.Controls.Add(root);
            return card;
        }

        private Control BuildRecetePanel()
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
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            root.Controls.Add(CreateSectionTitle("Reçete Oluştur"), 0, 0);
            root.Controls.Add(BuildReceteForm(), 0, 1);
            root.Controls.Add(CreateSectionTitle("Reçete Detay Satırı"), 0, 2);
            root.Controls.Add(BuildDetayForm(), 0, 3);
            root.Controls.Add(CreateSectionTitle("Reçete Detayı / Liste"), 0, 4);
            root.Controls.Add(BuildReceteGrid(), 0, 5);

            card.Controls.Add(root);
            return card;
        }

        private Control BuildHastaForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4
            };

            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            for (int i = 0; i < 4; i++)
            {
                form.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            }

            _txtTc = CreateTextBox();
            _txtAd = CreateTextBox();
            _txtSoyad = CreateTextBox();
            _txtTelefon = CreateTextBox();
            _cmbCinsiyet = CreateComboBox(new[] { "", "Kadın", "Erkek" });
            _cmbKanGrubu = CreateComboBox(new[] { "", "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" });
            _txtAlerji = CreateTextBox();

            form.Controls.Add(CreateLabel("TC No"), 0, 0);
            form.Controls.Add(_txtTc, 1, 0);
            form.Controls.Add(CreateLabel("Ad"), 2, 0);
            form.Controls.Add(_txtAd, 3, 0);

            form.Controls.Add(CreateLabel("Soyad"), 0, 1);
            form.Controls.Add(_txtSoyad, 1, 1);
            form.Controls.Add(CreateLabel("Telefon"), 2, 1);
            form.Controls.Add(_txtTelefon, 3, 1);

            form.Controls.Add(CreateLabel("Cinsiyet"), 0, 2);
            form.Controls.Add(_cmbCinsiyet, 1, 2);
            form.Controls.Add(CreateLabel("Kan Grubu"), 2, 2);
            form.Controls.Add(_cmbKanGrubu, 3, 2);

            form.Controls.Add(CreateLabel("Alerji"), 0, 3);
            form.Controls.Add(_txtAlerji, 1, 3);
            form.SetColumnSpan(_txtAlerji, 3);

            return form;
        }

        private Control BuildHastaButtons()
        {
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            _btnHastaKaydet = CreateActionButton("Kaydet", Color.FromArgb(22, 163, 74));
            _btnHastaKaydet.Click += BtnHastaKaydet_Click;
            _btnHastaGuncelle = CreateActionButton("Güncelle", Color.FromArgb(37, 99, 235));
            _btnHastaGuncelle.Click += BtnHastaGuncelle_Click;

            panel.Controls.Add(_btnHastaKaydet, 0, 0);
            panel.Controls.Add(_btnHastaGuncelle, 1, 0);
            return panel;
        }

        private Control BuildHastaAramaBar()
        {
            var bar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3
            };
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));

            _txtHastaAra = CreateTextBox();
            _btnHastaAra = CreateActionButton("Ara", Color.FromArgb(30, 64, 175));
            _btnHastaAra.Click += BtnHastaAra_Click;

            bar.Controls.Add(CreateLabel("Hasta Ara"), 0, 0);
            bar.Controls.Add(_txtHastaAra, 1, 0);
            bar.Controls.Add(_btnHastaAra, 2, 0);
            return bar;
        }

        private Control BuildHastaGrid()
        {
            _dgwHastalar = CreateGrid();
            _dgwHastalar.CellClick += DgwHastalar_CellClick;
            return _dgwHastalar;
        }

        private Control BuildReceteForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4
            };

            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            for (int i = 0; i < 4; i++)
            {
                form.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            }

            _txtReceteKodu = CreateTextBox();
            _txtReceteHastaTc = CreateTextBox();
            _btnReceteHastaBul = CreateActionButton("Bul", Color.FromArgb(30, 64, 175));
            _btnReceteHastaBul.Click += BtnReceteHastaBul_Click;


            _cmbDoktor = CreateComboBox();
            _cmbDoktor.DropDownStyle = ComboBoxStyle.DropDown;
            _cmbDoktor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _cmbDoktor.AutoCompleteSource = AutoCompleteSource.ListItems;
            _cmbReceteTuru = CreateComboBox();
            _dtTarih = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy HH:mm"
            };
            _chkDurum = new CheckBox
            {
                Text = "Aktif",
                Dock = DockStyle.Left,
                Checked = true,
                AutoSize = true
            };

            form.Controls.Add(CreateLabel("Kod"), 0, 0);
            form.Controls.Add(_txtReceteKodu, 1, 0);
            form.Controls.Add(CreateLabel("Hasta TC"), 2, 0);

            var hastaTcBox = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2
            };
            hastaTcBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            hastaTcBox.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            hastaTcBox.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            hastaTcBox.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            hastaTcBox.Controls.Add(_txtReceteHastaTc, 0, 0);
            hastaTcBox.Controls.Add(_btnReceteHastaBul, 1, 0);

            form.Controls.Add(hastaTcBox, 3, 0);

            form.Controls.Add(CreateLabel("Doktor"), 0, 1);
            form.Controls.Add(_cmbDoktor, 1, 1);
            form.Controls.Add(CreateLabel("Tür"), 2, 1);
            form.Controls.Add(_cmbReceteTuru, 3, 1);

            form.Controls.Add(CreateLabel("Tarih"), 0, 2);
            form.Controls.Add(_dtTarih, 1, 2);
            form.Controls.Add(CreateLabel("Durum"), 2, 2);
            form.Controls.Add(_chkDurum, 3, 2);

            var buttons = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3
            };
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));

            _btnReceteKaydet = CreateActionButton("Kaydet", Color.FromArgb(37, 99, 235));
            _btnReceteKaydet.Click += BtnReceteKaydet_Click;
            _btnReceteGuncelle = CreateActionButton("Güncelle", Color.FromArgb(14, 116, 144));
            _btnReceteGuncelle.Click += BtnReceteGuncelle_Click;
            _btnReceteSil = CreateActionButton("Sil", Color.FromArgb(220, 38, 38));
            _btnReceteSil.Click += BtnReceteSil_Click;

            buttons.Controls.Add(_btnReceteKaydet, 0, 0);
            buttons.Controls.Add(_btnReceteGuncelle, 1, 0);
            buttons.Controls.Add(_btnReceteSil, 2, 0);

            form.Controls.Add(buttons, 3, 3);
            return form;
        }

        private Control BuildDetayForm()
        {
            var form = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 3
            };

            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            _cmbIlac = CreateComboBox();
            _cmbIlac.DropDownStyle = ComboBoxStyle.DropDown;
            _cmbIlac.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _cmbIlac.AutoCompleteSource = AutoCompleteSource.ListItems;
            _nudAdet = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Minimum = 1,
                Maximum = 1000,
                Font = new Font("Segoe UI", 9.5F)
            };
            _txtKullanimSekli = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 9.5F)
            };

            form.Controls.Add(CreateLabel("İlaç"), 0, 0);
            form.Controls.Add(_cmbIlac, 1, 0);
            form.Controls.Add(CreateLabel("Adet"), 2, 0);
            form.Controls.Add(_nudAdet, 3, 0);

            form.Controls.Add(CreateLabel("Kullanım"), 0, 1);
            form.Controls.Add(_txtKullanimSekli, 1, 1);
            form.SetColumnSpan(_txtKullanimSekli, 3);

            var buttons = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            _btnDetayEkle = CreateActionButton("Detay Ekle", Color.FromArgb(14, 116, 144));
            _btnDetayEkle.Click += BtnDetayEkle_Click;
            _btnDetaySil = CreateActionButton("Detay Sil", Color.FromArgb(220, 38, 38));
            _btnDetaySil.Click += BtnDetaySil_Click;

            buttons.Controls.Add(_btnDetayEkle, 0, 0);
            buttons.Controls.Add(_btnDetaySil, 1, 0);
            form.Controls.Add(buttons, 3, 2);

            return form;
        }

        private Control BuildReceteGrid()
        {
            var container = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            container.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            container.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _dgwDetaylar = CreateGrid();
            _dgwDetaylar.CellClick += DgwDetaylar_CellClick;
            _dgwReceteler = CreateGrid();
            _dgwReceteler.CellClick += DgwReceteler_CellClick;

            container.Controls.Add(_dgwDetaylar, 0, 0);
            container.Controls.Add(_dgwReceteler, 0, 1);
            return container;
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
                Cursor = Cursors.Hand
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
