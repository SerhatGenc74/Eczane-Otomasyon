using EczaneOtomasyon.Bussines.Services.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI
{
    public class FrmHastaRecete : Form
    {
        public FrmHastaRecete(IHastalarService hastalarService, IRecetelerService recetelerService, IDoktorlarService doktorlarService, IReceteTurService receteTurService, IIlaclarService ilaclarService)
        {
            Text = "Hasta ve Reçete Modülü";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1280, 720);

            Controls.Add(new UcHastaRecete(hastalarService, recetelerService, doktorlarService, receteTurService, ilaclarService));
        }
    }
}