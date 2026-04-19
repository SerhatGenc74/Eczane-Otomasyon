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
    public partial class FrmIlacEkle : Form
    {
        public FrmIlacEkle()
        {
            Setup();
            InitializeComponent();
           
        }
        private void Setup()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmIlacEkle_Load(object sender, EventArgs e)
        {

        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {

        }
    }
}
