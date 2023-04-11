using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using week6_mikulasgyar.Abstractions;

namespace week6_mikulasgyar.Entities
{
    public class Ball : Toy
    {
        //override-al felül kell írni az abstract függvényt
        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
            //protected: a leszármaztatott osztályok is látják ezt a függvényt
        }
    }
}
