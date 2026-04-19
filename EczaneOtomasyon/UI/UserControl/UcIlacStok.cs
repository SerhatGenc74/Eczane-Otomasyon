using EczaneOtomasyon.Bussines.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI
{
    public partial class UcIlacStok : UserControl
    {
        IIlaclarService _ilaclarService;
        public UcIlacStok(IIlaclarService ilaclarService)
        {
            _ilaclarService = ilaclarService;
            IlacStokListele();
            InitializeComponent();
        }
        public void IlacStokListele()
        {
           var list = _ilaclarService.TumIlaclariGetir();
            dataGridView1.DataSource = list;
        }

        private void btn_ilacekle_Click(object sender, EventArgs e)
        {

        }
    }
}
