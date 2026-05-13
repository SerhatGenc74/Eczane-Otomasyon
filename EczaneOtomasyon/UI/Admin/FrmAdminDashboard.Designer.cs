using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    partial class FrmAdminDashboard
    {
        private TableLayoutPanel _rootLayout;
        private Panel _sidebarPanel;
        private FlowLayoutPanel _menuPanel;
        private Label _headerLabel;
        private Label _userLabel;
        private Button _btnLogout;
        private Panel _contentPanel;

        private void InitializeComponent()
        {
            _rootLayout = new TableLayoutPanel();
            _sidebarPanel = new Panel();
            _menuPanel = new FlowLayoutPanel();
            _headerLabel = new Label();
            _userLabel = new Label();
            _btnLogout = new Button();
            _contentPanel = new Panel();

            SuspendLayout();

            _rootLayout.ColumnCount = 2;
            _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _rootLayout.Dock = DockStyle.Fill;
            _rootLayout.RowCount = 1;
            _rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _sidebarPanel.BackColor = Color.FromArgb(15, 23, 42);
            _sidebarPanel.Dock = DockStyle.Fill;

            _headerLabel.Text = "Admin Panel";
            _headerLabel.Dock = DockStyle.Top;
            _headerLabel.Height = 54;
            _headerLabel.ForeColor = Color.White;
            _headerLabel.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
            _headerLabel.Padding = new Padding(16, 16, 8, 8);

            _menuPanel.Dock = DockStyle.Fill;
            _menuPanel.FlowDirection = FlowDirection.TopDown;
            _menuPanel.WrapContents = false;
            _menuPanel.AutoScroll = true;
            _menuPanel.Padding = new Padding(8, 4, 8, 4);

            _userLabel.Dock = DockStyle.Bottom;
            _userLabel.Height = 40;
            _userLabel.ForeColor = Color.FromArgb(226, 232, 240);
            _userLabel.Font = new Font("Calibri", 10F);
            _userLabel.Padding = new Padding(16, 8, 8, 8);

            _btnLogout.Text = "Oturumu Kapat";
            _btnLogout.Dock = DockStyle.Bottom;
            _btnLogout.Height = 44;
            _btnLogout.BackColor = Color.FromArgb(30, 41, 59);
            _btnLogout.ForeColor = Color.White;
            _btnLogout.FlatStyle = FlatStyle.Flat;
            _btnLogout.Font = new Font("Calibri", 10F, FontStyle.Bold);
            _btnLogout.Padding = new Padding(12, 0, 0, 0);
            _btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            _btnLogout.Cursor = Cursors.Hand;
            _btnLogout.FlatAppearance.BorderSize = 0;

            _sidebarPanel.Controls.Add(_menuPanel);
            _sidebarPanel.Controls.Add(_btnLogout);
            _sidebarPanel.Controls.Add(_userLabel);
            _sidebarPanel.Controls.Add(_headerLabel);

            _contentPanel.Dock = DockStyle.Fill;
            _contentPanel.BackColor = Color.FromArgb(241, 245, 249);

            _rootLayout.Controls.Add(_sidebarPanel, 0, 0);
            _rootLayout.Controls.Add(_contentPanel, 1, 0);

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1200, 760);
            Controls.Add(_rootLayout);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            WindowState = FormWindowState.Maximized;

            ResumeLayout(false);
        }
    }
}
