using System;
using System.Collections.Generic;
using System.Text;

namespace mikroszimulacio_week9.Entities
{
    public class Person
    {
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }
        public byte NbrOfChildren { get; set; }
        public bool IsAlive { get; set; }

        public Person()
        {
            IsAlive = true;
        }
    }
}
