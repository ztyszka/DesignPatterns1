using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        private Random randomElement = new Random(0);
        private double currentDeathRate = 0;
        public override string ToString()
        {
            return "ReverseVaccine";
        }

        public void Vaccinate(Cat cat)
        {
            cat.Alive = false;
            currentDeathRate += DeathRate;
        }

        public void Vaccinate(Dog dog)
        {
            dog.Immunity = ReverseString(this.Immunity);
            currentDeathRate += DeathRate;
        }

        public void Vaccinate(Pig pig)
        {
            if (randomElement.NextDouble() < currentDeathRate)
                pig.Alive = false;
            else
            {
                StringBuilder sb = new StringBuilder(this.Immunity);
                sb.Append(ReverseString(this.Immunity));
                pig.Immunity = sb.ToString();
                currentDeathRate += DeathRate;
            }
        }

        private string ReverseString(string str)
        {
            char[] c = str.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
    }
}
