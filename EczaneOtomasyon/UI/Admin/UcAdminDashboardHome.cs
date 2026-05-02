using System;
using System.Windows.Forms;
namespace EczaneOtomasyon.UI.Admin
{
    public partial class UcAdminDashboardHome : UserControl
    {
        public event Action<AdminPage> CardSelected;

        public UcAdminDashboardHome()
        {
            InitializeComponent();
        }

        private void Raise(AdminPage page)
        {
            CardSelected?.Invoke(page);
        }
    }
}
