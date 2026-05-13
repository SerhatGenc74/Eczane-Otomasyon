﻿using EczaneOtomasyon.Bussines.Services.Interfaces;
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
        IIlaclarService _ilaclarService;
        private bool isDarkMode = false;

        public Frmlogin(IKullanicilarService kullanicilarService, IAuthService authService, IIlaclarService ilaclarService)
        {
            this._kullanicilarService = kullanicilarService;
            this._authService = authService;
            this._ilaclarService = ilaclarService;
            InitializeComponent();
        }
        private void GetControl(UserControl control)
        {
            pnl_content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnl_content.Controls.Add(control);
            control.BringToFront();
            if (isDarkMode) ApplyTheme(pnl_content.Controls, true);
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
                        button3.Visible = false;
                        OpenHastaReceteModulu();
                        CheckNotifications();
                        break;
                    default:
                        pnl_login.Hide();
                        pnl_Ilaclar.Show();
                        button3.Visible = false;
                        OpenIlacModulu();
                        CheckNotifications();
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
            var current = _authService?.GetCurrentUser();
            if (current == null || !string.Equals(current.Rol, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bu modüle erişim yetkiniz yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void btn_Theme_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            if (isDarkMode)
            {
                btn_Theme.Text = "☀️ Aydınlık Tema";
                pnl_header.BackColor = Color.FromArgb(30, 41, 59);
                lbl_topbar_title.ForeColor = Color.White;
                pnl_content.BackColor = Color.FromArgb(15, 23, 42);
            }
            else
            {
                btn_Theme.Text = "🌙 Karanlık Tema";
                pnl_header.BackColor = Color.White;
                lbl_topbar_title.ForeColor = Color.FromArgb(51, 65, 85);
                pnl_content.BackColor = Color.WhiteSmoke;
            }
            ApplyTheme(pnl_content.Controls, isDarkMode);
        }

        private void ApplyTheme(Control.ControlCollection controls, bool dark)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Panel || ctrl is UserControl)
                {
                    ctrl.BackColor = dark ? Color.FromArgb(30, 41, 59) : Color.White;
                    ApplyTheme(ctrl.Controls, dark);
                }
                else if (ctrl is Label || ctrl is RadioButton || ctrl is CheckBox)
                {
                    ctrl.ForeColor = dark ? Color.White : Color.FromArgb(51, 65, 85);
                }
                else if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = dark ? Color.FromArgb(15, 23, 42) : Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = dark ? Color.FromArgb(30, 41, 59) : Color.FromArgb(45, 62, 100);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.DefaultCellStyle.BackColor = dark ? Color.FromArgb(30, 41, 59) : Color.White;
                    dgv.DefaultCellStyle.ForeColor = dark ? Color.White : Color.Black;
                }
                else if (ctrl is TableLayoutPanel || ctrl is FlowLayoutPanel)
                {
                    ctrl.BackColor = Color.Transparent;
                    ApplyTheme(ctrl.Controls, dark);
                }
            }
        }

        private void CheckNotifications()
        {
            var kritikList = _ilaclarService.KritikStoktakiIlaclariGetir();
            var miadList = _ilaclarService.MiadiYaklasanIlaclariGetir();
            int totalWarning = (kritikList?.Count ?? 0) + (miadList?.Count ?? 0);

            if (totalWarning > 0)
            {
                ShowToast($"Dikkat: Kritik stok veya SKT'si yaklaşan toplam {totalWarning} ilaç var!");
            }
        }

        private void ShowToast(string message)
        {
            Panel pnlToast = new Panel();
            pnlToast.Size = new Size(400, 70);
            pnlToast.BackColor = Color.FromArgb(220, 53, 69);
            pnlToast.ForeColor = Color.White;
            pnlToast.Location = new Point(pnl_Ilaclar.Width - 420, pnl_Ilaclar.Height - 90);
            pnlToast.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            Label lblMsg = new Label();
            lblMsg.Text = message;
            lblMsg.Dock = DockStyle.Fill;
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            lblMsg.Font = new Font("Segoe UI Semibold", 11);

            pnlToast.Controls.Add(lblMsg);
            pnl_Ilaclar.Controls.Add(pnlToast);
            pnlToast.BringToFront();

            Timer t = new Timer();
            t.Interval = 6000;
            t.Tick += (s, e) => {
                pnl_Ilaclar.Controls.Remove(pnlToast);
                t.Stop();
                t.Dispose();
            };
            t.Start();
        }
    }
}
