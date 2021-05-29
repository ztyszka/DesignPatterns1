using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }

        public void Vaccinate(Cat cat)
        {
            Vaccinate(cat, 300, 1);
        }

        public void Vaccinate(Dog dog)
        {
            Vaccinate(dog, 3000, 1);
        }

        public void Vaccinate(Pig pig)
        {
            Vaccinate(pig, 15, 3);
        }

        public string GenerateImmunity(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(this.Immunity[randomElement.Next() % this.Immunity.Length]);
            }
            return sb.ToString();
        }

        public void Vaccinate(ISubject subject, int n, int rate)
        {
            if (randomElement.NextDouble() < this.DeathRate * rate)
                subject.Alive = false;
            else
                subject.Immunity = GenerateImmunity(n);
        }
    }
}
