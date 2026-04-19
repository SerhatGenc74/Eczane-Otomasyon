using EczaneOtomasyon.Bussines.Services.Interfaces;
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
        public Frmlogin(IKullanicilarService _kullanicilarService)
        {
            this._kullanicilarService = _kullanicilarService;
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var username = txt_username.Text;
            var password = txt_password.Text;
            var kullanici = _kullanicilarService.Login(username,password);
            if (kullanici != null)
            {
                switch(kullanici.Rol)
                {
                    case "Admin":
                        break;
                    case "Personel":
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
    }
}
