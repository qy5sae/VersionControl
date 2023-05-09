using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mikroszimulacio_week9.Entities;
using System.IO;
namespace mikroszimulacio_week9
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");

        }

        public List<Person> GetPopulation(string csvPath)
        {
            var population = new List<Person>();
            using (var sr = new StreamReader(csvPath, Encoding.Default))
            {
                
                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = byte.Parse(line[2]),
                    }) ;
                }
            }
            return population;
        }

        public List<BirthProbability> Getbirthpopulation(string csvPath)
        {
            var pbirthprobabilities = new List<BirthProbability>();
            using (var sr = new StreamReader(csvPath, Encoding.Default))
            {
                
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    pbirthprobabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = byte.Parse(line[1]),
                        P = double.Parse(line[2])

                    }) ;
                }
            }
            return pbirthprobabilities;
        }

        public List<DeathProbability> GetDeathprobability(string csvPath)
        {
            var deathprobabilities = new List<DeathProbability>();
            using (var sr = new StreamReader(csvPath, Encoding.Default))
            {
                
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathprobabilities.Add(new DeathProbability()
                    {
                        Age = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        P = double.Parse(line[2]),
                    });
                }
            }
            return deathprobabilities;
        }

    }
}
