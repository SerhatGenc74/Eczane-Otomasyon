using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EczaneOtomasyon.UI
{
    public partial class FrmIlacEkle : Form
    {
        IServiceOfWork _serviceOfWork;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FrmIlacEkle(IServiceOfWork serviceOfWork)
        {
            _serviceOfWork = serviceOfWork;
            Setup();
            InitializeComponent();
           
        }
        private void LoadKategori()
        {
            var kategoriler = _serviceOfWork.KategoriService.GetAllKategori();
            cbox_kategori.DataSource = kategoriler.ToList();
            cbox_kategori.DisplayMember = "Value";
            cbox_kategori.ValueMember = "Key";
        }
        private void LoadReceteTur()
        {
            var receteTurleri = _serviceOfWork.ReceteTurService.GetReceteTurleri();
            cbox_recetetur.DataSource = receteTurleri.ToList();
            cbox_recetetur.DisplayMember = "Value";
            cbox_recetetur.ValueMember = "Key";
        }
        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(txt_ilacad.Text) || string.IsNullOrEmpty(nud_birimfiyat.Text) || cbox_kategori.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return false;
            }
            return true;
        }
        private void Setup()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void pnl_header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmIlacEkle_Load(object sender, EventArgs e)
        {
            LoadKategori();
            LoadReceteTur();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            var ok = CheckFields();
            if (ok)
            {
                Ilaclar ilac = new Ilaclar
                {
                    IlacAdi = txt_ilacad.Text,
                    KategoriID = (int)cbox_kategori.SelectedValue,
                    TurID = (int)cbox_recetetur.SelectedValue,
                    BirimFiyat = nud_birimfiyat.Value,
                    StokAdedi = (int)nud_stokadet.Value,
                    KritikSeviye = (int)nud_kritik.Value,
                    SonKullanmaTarihi = dtp_sktt.Value,
                    RafNo = txt_rafno.Text
                };
                
               bool eklendimi = _serviceOfWork.IlaclarService.IlacEkle(ilac);

                if (eklendimi)
                {
                    MessageBox.Show("İlaç başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("İlaç eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
        }
    }
}
