using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    partial class UcAdminSettings
    {
        private void InitializeComponent()
        {
            SuspendLayout();

            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(241, 245, 249);

            var label = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Yapım Aşamasında",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Trebuchet MS", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105)
            };

            Controls.Add(label);

            ResumeLayout(false);
        }
    }
}
