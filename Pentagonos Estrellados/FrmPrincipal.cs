using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pentagonos_Estrellados
{
    public partial class FrmPrincipal : Form
    {
        private Pentagono pentagono;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            pentagono = new Pentagono(float.Parse(txtRadio.Text), picCanvas);
            pentagono.calcularPuntos();
            pentagono.dibujarPentagono();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpiar el panel
            picCanvas.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir de la aplicacion
            Application.Exit();
        }
    }
}
