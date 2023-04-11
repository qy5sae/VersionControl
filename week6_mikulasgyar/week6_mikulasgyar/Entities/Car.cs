using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using week6_mikulasgyar.Abstractions;

namespace week6_mikulasgyar.Entities
{
    public class Car: Toy
    {
        protected override void DrawImage(Graphics g)
        {
            Image img = Image.FromFile(@"Images\car.png");
            g.DrawImage(img, new Rectangle(0, 0, Width, Height));
        }
    }
}
