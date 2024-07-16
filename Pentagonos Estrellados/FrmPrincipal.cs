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
        bool rellenar = false;
        bool dibujado = false;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            int radio;

            if (int.TryParse(txtRadio.Text, out radio) && radio > 0)
            {
                picCanvas.Refresh();
                rellenar = true;
                dibujado = true;
                trackBar1.Enabled = true;
                pentagono = new Pentagono(picCanvas);
                pentagono.calcularPuntos(radio);
                pentagono.dibujarPentagono();
            }
            else
            {
                MessageBox.Show("El radio debe ser un número positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpiar el panel
            int radio;
            rellenar = false;
            dibujado = false;
            trackBar1.Enabled = false;
            picCanvas.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir de la aplicacion
            Application.Exit();
        }

        private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            int radio;

            switch (e.KeyCode)
            {
                case Keys.W:
                    if (int.TryParse(txtRadio.Text, out radio) && radio > 0 && dibujado)
                    {
                        picCanvas.Refresh();
                        pentagono.cambiarCentro(0, -10);

                        pentagono.calcularPuntos(radio);
                        pentagono.dibujarPentagono();
                    }
                    else
                    {
                        MessageBox.Show("Grafique la mandala con números positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case Keys.S:
                    if (int.TryParse(txtRadio.Text, out radio) && radio > 0 && dibujado)
                    {
                        picCanvas.Refresh();
                        pentagono.cambiarCentro(0, 10);

                        pentagono.calcularPuntos(radio);
                        pentagono.dibujarPentagono();
                    }
                    else
                    {
                        MessageBox.Show("Grafique la mandala con números positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case Keys.A:
                    if (int.TryParse(txtRadio.Text, out radio) && radio > 0 && dibujado)
                    {
                        picCanvas.Refresh();
                        pentagono.cambiarCentro(-10, 0);

                        pentagono.calcularPuntos(radio);
                        pentagono.dibujarPentagono();
                    }
                    else
                    {
                        MessageBox.Show("Grafique la mandala con números positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case Keys.D:
                    if (int.TryParse(txtRadio.Text, out radio) && radio > 0 && dibujado)
                    {
                        picCanvas.Refresh();
                        pentagono.cambiarCentro(10, 0);

                        pentagono.calcularPuntos(radio);
                        pentagono.dibujarPentagono();
                    }
                    else
                    {
                        MessageBox.Show("Grafique la mandala con números positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            int radio;
            if (int.TryParse(txtRadio.Text, out radio) && radio > 0 && dibujado)
            {

                if (dibujado)
                {

                    picCanvas.Refresh();
                    // Cambiar el tamaño de la mandala
                    pentagono.cambiarEscala(trackBar1.Value);
                    if (dibujado)
                    {
                        pentagono.calcularPuntos(float.Parse(txtRadio.Text));
                        pentagono.dibujarPentagono();
                    }
                }
            }
            else
            {
                MessageBox.Show("Grafique la mandala con números positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRotarL_Click(object sender, EventArgs e)
        {
            int radio;
            if (int.TryParse(txtRadio.Text, out radio) && radio > 0 && dibujado)
            {

                if (dibujado)
                {
                    picCanvas.Refresh();

                    pentagono.cambiarAnguloInicial(5);
                    pentagono.calcularPuntos(radio);
                    pentagono.dibujarPentagono();
                }
            }
            else
            {
                MessageBox.Show("Grafique la mandala con números positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRotarR_Click(object sender, EventArgs e)
        {
            int radio;
            if (int.TryParse(txtRadio.Text, out radio) && radio > 0 && dibujado)
            {

                if (dibujado)
                {
                    picCanvas.Refresh();

                    pentagono.cambiarAnguloInicial(-5);
                    pentagono.calcularPuntos(radio);
                    pentagono.dibujarPentagono();
                }
            }
            else
            {
                MessageBox.Show("Grafique la mandala con números positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
