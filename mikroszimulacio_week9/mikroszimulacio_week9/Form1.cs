﻿using System;
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
        Random rng = new Random(1234);
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
            for (int year = 2005; year <= 2024; year++)
            {
                for (int i = 0; i < Population.Count(); i++)
                {

                }
                var NumberOfMales = (from x in Population
                                     where x.Gender == Gender.Male && x.IsAlive
                                     select x).Count();
                var NumberOfFemales = (from x in Population
                                       where x.Gender == Gender.Female && x.IsAlive
                                       select x).Count();

                Console.WriteLine(string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, NumberOfMales, NumberOfFemales));
            }
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

        public List<BirthProbability> GetBirthProbabilities(string csvPath)
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

        public List<DeathProbability> GetDeathProbabilities(string csvPath)
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

        private void SimStep(int year, Person person)
        {
            //Ha halott akkor kihagyjuk, ugrunk a ciklus következő lépésére
            if (!person.IsAlive) return;

            // Letároljuk az életkort, hogy ne kelljen mindenhol újraszámolni
            byte age = (byte)(year - person.BirthYear);

            // Halál kezelése
            // Halálozási valószínűség kikeresése
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.P).FirstOrDefault();
            // Meghal a személy?
            if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;

            //Születés kezelése - csak az élő nők szülnek
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                //Szülési valószínűség kikeresése
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.P).FirstOrDefault();
                //Születik gyermek?
                if (rng.NextDouble() <= pBirth)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NbrOfChildren = 0;
                    újszülött.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(újszülött);
                }
            }
        }

    }
}
