using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week6_mikulasgyar.Abstractions;

namespace week6_mikulasgyar
{
   
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        private void createTimer(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            MainPanel.Controls.Add(toy);
        }
        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }
            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                MainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new Entities.BallFactory();
        }

    }
}
