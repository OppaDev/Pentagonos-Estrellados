using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pentagonos_Estrellados
{
    public class Pentagono
    {
        //atributos 
        private float radio1, radio2, radio3, radio4, radio5;
        //objeto de clase grphics
        private Graphics g;
        //objeto de clase Pen
        private Pen lapiz;
        //pentagonos
        private float[,] pentagono0 = new float[5, 2];
        private float[,] pentagono1 = new float[5, 2];
        private float[,] pentagono2 = new float[5, 2];
        private float[,] pentagono3 = new float[5, 2];
        private float[,] pentagono4 = new float[5, 2];
        private float[,] pentagono5 = new float[5, 2];

        //factor de escalamiento
        private float fS = 10;
        private int rotation = 0;

        private PictureBox picCanvas;

        private float x0, y0;

        //constructor vacio 
        public Pentagono()
        {
        }
        public Pentagono(PictureBox pictureBox)
        {
            this.x0 = pictureBox.Width / 2;
            this.y0 = pictureBox.Height / 2;
            this.picCanvas = pictureBox;
            this.g = picCanvas.CreateGraphics();
        }
        public void cambiarCentro(int aumentoX, int aumentoY)
        {
            x0 += aumentoX;
            y0 += aumentoY;
        }
        public void cambiarEscala(int escala)
        {
            fS = escala;
        }

        public void cambiarAnguloInicial(int value)
        {
            rotation = (rotation + value) % 360;
        }

        //metodos 
        public void calcularPuntos(float radio)
        {
            Array.Clear(pentagono0, 0, pentagono0.Length);
            Array.Clear(pentagono1, 0, pentagono1.Length);
            Array.Clear(pentagono2, 0, pentagono2.Length);
            Array.Clear(pentagono3, 0, pentagono3.Length);
            Array.Clear(pentagono4, 0, pentagono4.Length);
            Array.Clear(pentagono5, 0, pentagono5.Length);

            radio1 = radio * fS;
            radio2 = radio1 * 0.7f;
            radio3 = radio1 * 0.56f;
            radio4 = radio1 * 0.4f;
            radio5 = radio1 * 0.2f;

            int posiciones = 0;
            float anguloPentagono = 72;

            //Pentagono 5
            for (double i = -90 + rotation; i < 270 + rotation; i += anguloPentagono)
            {
                double x = x0 + radio5 * Math.Cos(i * Math.PI / 180);
                double y = y0 + radio5 * Math.Sin(i * Math.PI / 180);
                pentagono5[posiciones, 0] = (float)x;
                pentagono5[posiciones, 1] = (float)y;
                posiciones++;
            }
            //Pentagono 4
            posiciones = 0;
            for (double i = 90 + rotation; i < 450 + rotation; i += anguloPentagono)
            {
                double x = x0 + radio4 * Math.Cos(i * Math.PI / 180);
                double y = y0 + radio4 * Math.Sin(i * Math.PI / 180);
                pentagono4[posiciones, 0] = (float)x;
                pentagono4[posiciones, 1] = (float)y;
                posiciones++;
            }
            //Pentagono 3
            posiciones = 0;
            for (double i = 90 + rotation; i < 450 + rotation; i += anguloPentagono)
            {
                double x = x0 + radio3 * Math.Cos(i * Math.PI / 180);
                double y = y0 + radio3 * Math.Sin(i * Math.PI / 180);
                pentagono3[posiciones, 0] = (float)x;
                pentagono3[posiciones, 1] = (float)y;
                posiciones++;
            }
            //Pentagono 2
            posiciones = 0;
            for (double i = -90 + rotation; i < 270 + rotation; i += anguloPentagono)
            {
                double x = x0 + radio2 * Math.Cos(i * Math.PI / 180);
                double y = y0 + radio2 * Math.Sin(i * Math.PI / 180);
                pentagono2[posiciones, 0] = (float)x;
                pentagono2[posiciones, 1] = (float)y;
                posiciones++;
            }
            //Pentagono 1
            posiciones = 0;
            for (double i = rotation; i < 360 + rotation; i += anguloPentagono)
            {
                double x = x0 + radio1 * Math.Cos(i * Math.PI / 180);
                double y = y0 + radio1 * Math.Sin(i * Math.PI / 180);
                pentagono1[posiciones, 0] = (float)x;
                pentagono1[posiciones, 1] = (float)y;
                posiciones++;
            }
            //Pentagono 0
            posiciones = 0;
            for (double i = -180 + rotation; i < 180 + rotation; i += anguloPentagono)
            {
                double x = x0 + radio1 * Math.Cos(i * Math.PI / 180);
                double y = y0 + radio1 * Math.Sin(i * Math.PI / 180);
                pentagono0[posiciones, 0] = (float)x;
                pentagono0[posiciones, 1] = (float)y;
                posiciones++;
            }
        }


        public void dibujarPentagono()
        {
            //paleta de colores monocromáticos de violeta
            Color[] violetaTonos = {
                Color.FromArgb(255, 48, 25, 52),  // Violeta muy oscuro
                Color.FromArgb(255, 68, 35, 77),  // Violeta oscuro
                Color.FromArgb(255, 88, 46, 101), // Violeta mediano oscuro
                Color.FromArgb(255, 108, 57, 126), // Violeta medio
                Color.FromArgb(255, 128, 68, 150), // Violeta medio claro
                Color.FromArgb(255, 148, 79, 174), // Violeta claro
                Color.FromArgb(255, 168, 90, 199), // Violeta muy claro
                Color.FromArgb(255, 188, 101, 223), // Violeta más claro
                Color.FromArgb(255, 208, 112, 248), // Violeta claro casi rosa
                Color.FromArgb(255, 228, 123, 255) // Violeta muy claro
            };

            //pentagono 5
            lapiz = new Pen(violetaTonos[9], 1);
            g.DrawLine(lapiz, pentagono5[0, 0], pentagono5[0, 1], pentagono5[2, 0], pentagono5[2, 1]);
            g.DrawLine(lapiz, pentagono5[2, 0], pentagono5[2, 1], pentagono5[4, 0], pentagono5[4, 1]);
            g.DrawLine(lapiz, pentagono5[4, 0], pentagono5[4, 1], pentagono5[1, 0], pentagono5[1, 1]);
            g.DrawLine(lapiz, pentagono5[1, 0], pentagono5[1, 1], pentagono5[3, 0], pentagono5[3, 1]);
            g.DrawLine(lapiz, pentagono5[3, 0], pentagono5[3, 1], pentagono5[0, 0], pentagono5[0, 1]);

            //pentagono 4
            lapiz = new Pen(violetaTonos[8], 1);
            g.DrawLine(lapiz, pentagono4[2, 0], pentagono4[2, 1], pentagono5[0, 0], pentagono5[0, 1]);
            g.DrawLine(lapiz, pentagono4[3, 0], pentagono4[3, 1], pentagono5[0, 0], pentagono5[0, 1]);
            g.DrawLine(lapiz, pentagono4[3, 0], pentagono4[3, 1], pentagono5[1, 0], pentagono5[1, 1]);
            g.DrawLine(lapiz, pentagono4[4, 0], pentagono4[4, 1], pentagono5[1, 0], pentagono5[1, 1]);
            g.DrawLine(lapiz, pentagono4[4, 0], pentagono4[4, 1], pentagono5[2, 0], pentagono5[2, 1]);
            g.DrawLine(lapiz, pentagono4[0, 0], pentagono4[0, 1], pentagono5[2, 0], pentagono5[2, 1]);
            g.DrawLine(lapiz, pentagono4[0, 0], pentagono4[0, 1], pentagono5[3, 0], pentagono5[3, 1]);
            g.DrawLine(lapiz, pentagono4[1, 0], pentagono4[1, 1], pentagono5[3, 0], pentagono5[3, 1]);
            g.DrawLine(lapiz, pentagono4[1, 0], pentagono4[1, 1], pentagono5[4, 0], pentagono5[4, 1]);
            g.DrawLine(lapiz, pentagono4[2, 0], pentagono4[2, 1], pentagono5[4, 0], pentagono5[4, 1]);

            //pentagono 3
            lapiz = new Pen(violetaTonos[7], 1);
            g.DrawLine(lapiz, pentagono3[2, 0], pentagono3[2, 1], pentagono5[0, 0], pentagono5[0, 1]);
            g.DrawLine(lapiz, pentagono3[3, 0], pentagono3[3, 1], pentagono5[0, 0], pentagono5[0, 1]);
            g.DrawLine(lapiz, pentagono3[3, 0], pentagono3[3, 1], pentagono5[1, 0], pentagono5[1, 1]);
            g.DrawLine(lapiz, pentagono3[4, 0], pentagono3[4, 1], pentagono5[1, 0], pentagono5[1, 1]);
            g.DrawLine(lapiz, pentagono3[4, 0], pentagono3[4, 1], pentagono5[2, 0], pentagono5[2, 1]);
            g.DrawLine(lapiz, pentagono3[0, 0], pentagono3[0, 1], pentagono5[2, 0], pentagono5[2, 1]);
            g.DrawLine(lapiz, pentagono3[0, 0], pentagono3[0, 1], pentagono5[3, 0], pentagono5[3, 1]);
            g.DrawLine(lapiz, pentagono3[1, 0], pentagono3[1, 1], pentagono5[3, 0], pentagono5[3, 1]);
            g.DrawLine(lapiz, pentagono3[1, 0], pentagono3[1, 1], pentagono5[4, 0], pentagono5[4, 1]);
            g.DrawLine(lapiz, pentagono3[2, 0], pentagono3[2, 1], pentagono5[4, 0], pentagono5[4, 1]);
            //pentagono 2
            lapiz = new Pen(violetaTonos[6], 1);
            g.DrawLine(lapiz, pentagono2[0, 0], pentagono2[0, 1], pentagono2[1, 0], pentagono2[1, 1]);
            g.DrawLine(lapiz, pentagono2[1, 0], pentagono2[1, 1], pentagono2[2, 0], pentagono2[2, 1]);
            g.DrawLine(lapiz, pentagono2[2, 0], pentagono2[2, 1], pentagono2[3, 0], pentagono2[3, 1]);
            g.DrawLine(lapiz, pentagono2[3, 0], pentagono2[3, 1], pentagono2[4, 0], pentagono2[4, 1]);
            g.DrawLine(lapiz, pentagono2[4, 0], pentagono2[4, 1], pentagono2[0, 0], pentagono2[0, 1]);
            //pentagono 1
            lapiz = new Pen(violetaTonos[5], 1);
            g.DrawLine(lapiz, pentagono1[0, 0], pentagono1[0, 1], pentagono1[1, 0], pentagono1[1, 1]);
            g.DrawLine(lapiz, pentagono1[1, 0], pentagono1[1, 1], pentagono1[2, 0], pentagono1[2, 1]);
            g.DrawLine(lapiz, pentagono1[2, 0], pentagono1[2, 1], pentagono1[3, 0], pentagono1[3, 1]);
            g.DrawLine(lapiz, pentagono1[3, 0], pentagono1[3, 1], pentagono1[4, 0], pentagono1[4, 1]);
            g.DrawLine(lapiz, pentagono1[4, 0], pentagono1[4, 1], pentagono1[0, 0], pentagono1[0, 1]);
            //pentagono 0
            lapiz = new Pen(violetaTonos[4], 1);
            g.DrawLine(lapiz, pentagono0[0, 0], pentagono0[0, 1], pentagono0[1, 0], pentagono0[1, 1]);
            g.DrawLine(lapiz, pentagono0[1, 0], pentagono0[1, 1], pentagono0[2, 0], pentagono0[2, 1]);
            g.DrawLine(lapiz, pentagono0[2, 0], pentagono0[2, 1], pentagono0[3, 0], pentagono0[3, 1]);
            g.DrawLine(lapiz, pentagono0[3, 0], pentagono0[3, 1], pentagono0[4, 0], pentagono0[4, 1]);
            g.DrawLine(lapiz, pentagono0[4, 0], pentagono0[4, 1], pentagono0[0, 0], pentagono0[0, 1]);
            //lineas extra
            lapiz = new Pen(violetaTonos[3], 1);
            g.DrawLine(lapiz, pentagono2[0, 0], pentagono2[0, 1], pentagono3[4, 0], pentagono3[4, 1]);
            g.DrawLine(lapiz, pentagono3[4, 0], pentagono3[4, 1], pentagono2[3, 0], pentagono2[3, 1]);
            g.DrawLine(lapiz, pentagono2[3, 0], pentagono2[3, 1], pentagono3[2, 0], pentagono3[2, 1]);
            g.DrawLine(lapiz, pentagono3[2, 0], pentagono3[2, 1], pentagono2[1, 0], pentagono2[1, 1]);
            g.DrawLine(lapiz, pentagono2[1, 0], pentagono2[1, 1], pentagono3[0, 0], pentagono3[0, 1]);
            g.DrawLine(lapiz, pentagono3[0, 0], pentagono3[0, 1], pentagono2[4, 0], pentagono2[4, 1]);
            g.DrawLine(lapiz, pentagono2[4, 0], pentagono2[4, 1], pentagono3[3, 0], pentagono3[3, 1]);
            g.DrawLine(lapiz, pentagono3[3, 0], pentagono3[3, 1], pentagono2[2, 0], pentagono2[2, 1]);
            g.DrawLine(lapiz, pentagono2[2, 0], pentagono2[2, 1], pentagono3[1, 0], pentagono3[1, 1]);
            g.DrawLine(lapiz, pentagono3[1, 0], pentagono3[1, 1], pentagono2[0, 0], pentagono2[0, 1]);

            //lineas extra 2
            lapiz = new Pen(violetaTonos[2], 1);
            g.DrawLine(lapiz, pentagono2[0, 0], pentagono2[0, 1], pentagono1[3, 0], pentagono1[3, 1]);
            g.DrawLine(lapiz, pentagono2[0, 0], pentagono2[0, 1], pentagono0[2, 0], pentagono0[2, 1]);
            g.DrawLine(lapiz, pentagono2[1, 0], pentagono2[1, 1], pentagono1[4, 0], pentagono1[4, 1]);
            g.DrawLine(lapiz, pentagono2[1, 0], pentagono2[1, 1], pentagono0[3, 0], pentagono0[3, 1]);
            g.DrawLine(lapiz, pentagono2[2, 0], pentagono2[2, 1], pentagono1[0, 0], pentagono1[0, 1]);
            g.DrawLine(lapiz, pentagono2[2, 0], pentagono2[2, 1], pentagono0[4, 0], pentagono0[4, 1]);
            g.DrawLine(lapiz, pentagono2[3, 0], pentagono2[3, 1], pentagono1[1, 0], pentagono1[1, 1]);
            g.DrawLine(lapiz, pentagono2[3, 0], pentagono2[3, 1], pentagono0[0, 0], pentagono0[0, 1]);
            g.DrawLine(lapiz, pentagono2[4, 0], pentagono2[4, 1], pentagono1[2, 0], pentagono1[2, 1]);
            g.DrawLine(lapiz, pentagono2[4, 0], pentagono2[4, 1], pentagono0[1, 0], pentagono0[1, 1]);
        }
    }
}
