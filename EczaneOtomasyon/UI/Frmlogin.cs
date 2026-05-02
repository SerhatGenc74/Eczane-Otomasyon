using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.UI;
using EczaneOtomasyon.UI.Admin;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class Frmlogin : Form
    {
        IKullanicilarService _kullanicilarService;
        IAuthService _authService;
        public Frmlogin(IKullanicilarService _kullanicilarService, IAuthService authService)
        {
            this._kullanicilarService = _kullanicilarService;
            this._authService = authService;
            InitializeComponent();
        }
        private void GetControl(UserControl control)
        {
            pnl_content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnl_content.Controls.Add(control);
            control.BringToFront();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            var username = txt_username.Text;
            var password = txt_password.Text;
            var kullanici = _kullanicilarService.Login(username,password);
            if (kullanici != null)
            {
                _authService.SetCurrentUser(kullanici);
                switch(kullanici.Rol)
                {
                    case "Admin":
                        OpenAdminDashboard();
                        break;
                    case "Personel":
                        pnl_login.Hide();
                        pnl_Ilaclar.Show();
                        OpenHastaReceteModulu();
                        break;
                    default:
                        pnl_login.Hide();
                        pnl_Ilaclar.Show();
                        OpenIlacModulu();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }

        }

        private void pnl_login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Ilaclar_Click(object sender, EventArgs e)
        {
            OpenIlacModulu();
        }

        private void btn_HastaRecete_Click(object sender, EventArgs e)
        {
            OpenHastaReceteModulu();
        }

        private void btn_SatisFatura_Click(object sender, EventArgs e)
        {
            var satisFaturaSayfasi = Program.ServiceProvider.GetRequiredService<UcSatisFatura>();
            GetControl(satisFaturaSayfasi);
        }

        private void btn_DuzenlemeArayuz_Click(object sender, EventArgs e)
        {
            var duzenlemeSayfasi = Program.ServiceProvider.GetRequiredService<UcDuzenlemeArayuz>();
            GetControl(duzenlemeSayfasi);
        }

        private void btn_Cikis_Click(object sender, EventArgs e)
        {
            txt_username.Text = string.Empty;
            txt_password.Text = string.Empty;
            pnl_content.Controls.Clear();
            pnl_Ilaclar.Hide();
            pnl_login.Show();
            txt_username.Focus();
        }

        private void OpenIlacModulu()
        {
            var stokSayfasi = Program.ServiceProvider.GetRequiredService<UcIlacStok>();
            GetControl(stokSayfasi);
        }

        private void OpenAdminDashboard()
        {
            var adminForm = Program.ServiceProvider.GetRequiredService<FrmAdminDashboard>();
            adminForm.FormClosed += (s, e) =>
            {
                pnl_content.Controls.Clear();
                pnl_Ilaclar.Hide();
                pnl_login.Show();
                txt_username.Text = string.Empty;
                txt_password.Text = string.Empty;
                txt_username.Focus();
                Show();
            };

            Hide();
            adminForm.Show();
        }

        private void OpenHastaReceteModulu()
        {
            var hastaReceteSayfasi = Program.ServiceProvider.GetRequiredService<UcHastaRecete>();
            GetControl(hastaReceteSayfasi);
        }
    }
}
