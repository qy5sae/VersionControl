using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using week6_mikulasgyar.Abstractions;

namespace week6_mikulasgyar.Entities
{
    public class BallFactory: IToyFactory
    {
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
