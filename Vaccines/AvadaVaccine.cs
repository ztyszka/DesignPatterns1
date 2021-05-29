using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }

        public void Vaccinate(Cat cat)
        {
            if (randomElement.NextDouble() < DeathRate)
                cat.Alive = false;
            else
                cat.Immunity = this.Immunity[3..];
        }

        public void Vaccinate(Dog dog)
        {
            dog.Immunity = this.Immunity;
        }

        public void Vaccinate(Pig pig)
        {
            pig.Alive = false;
        }
    }
}
