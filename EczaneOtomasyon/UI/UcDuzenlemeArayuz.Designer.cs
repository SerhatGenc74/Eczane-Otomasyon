using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI
{
    partial class UcDuzenlemeArayuz
    {
        private Label _titleLabel;
        private TableLayoutPanel _gridPanel;

        private void InitializeComponent()
        {
            SuspendLayout();

            Dock = DockStyle.Fill;
            BackColor = Color.WhiteSmoke;

            _titleLabel = new Label
            {
                Dock = DockStyle.Top,
                Height = 50,
                Text = "Düzenleme ve Arayüz Modülü",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Padding = new Padding(12, 12, 12, 0)
            };

            _gridPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(12)
            };

            _gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            _gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            _gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));

            _gridPanel.Controls.Add(CreateCard("Kullanıcı Yönetimi", "Kullanıcı ekle, rol güncelle, şifre işlemleri"), 0, 0);
            _gridPanel.Controls.Add(CreateCard("Kategori Yönetimi", "İlaç kategorileri ve reçete türleri"), 1, 0);
            _gridPanel.Controls.Add(CreateCard("Doktor Yönetimi", "Doktor bilgisi ve kurum kayıtları"), 0, 1);
            _gridPanel.Controls.Add(CreateCard("Hasta Düzenleme", "Hasta iletişim, alerji, kan grubu güncelle"), 1, 1);
            _gridPanel.Controls.Add(CreateCard("Stok Kuralları", "Kritik seviye, raf no ve alarm ayarları"), 0, 2);
            _gridPanel.Controls.Add(CreateCard("Arayüz Ayarları", "Tema, başlıklar ve ekran düzeni"), 1, 2);

            Controls.Add(_gridPanel);
            Controls.Add(_titleLabel);

            ResumeLayout(false);
        }

        private Control CreateCard(string baslik, string aciklama)
        {
            var card = new Panel
            {
                Margin = new Padding(6),
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var title = new Label
            {
                Dock = DockStyle.Top,
                Height = 34,
                Text = baslik,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Padding = new Padding(8, 8, 8, 0)
            };

            var desc = new Label
            {
                Dock = DockStyle.Fill,
                Text = aciklama,
                Font = new Font("Segoe UI", 9F),
                Padding = new Padding(8, 0, 8, 8)
            };

            card.Controls.Add(desc);
            card.Controls.Add(title);
            return card;
        }
    }
}
