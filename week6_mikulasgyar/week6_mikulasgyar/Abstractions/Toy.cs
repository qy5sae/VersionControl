using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

namespace week6_mikulasgyar.Abstractions
{
    public abstract class Toy : Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Toy_Paint;
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected  abstract void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
            //protected: a leszármaztatott osztályok is látják ezt a függvényt
        }

        public void MoveToy()
        {
            Left += 1;
        }
    }
}
