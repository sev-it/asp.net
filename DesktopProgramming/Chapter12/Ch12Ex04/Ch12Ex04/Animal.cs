﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex04
{
    public abstract class Animal
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public abstract void MakeANoise();

        public Animal()
        {
            name = "The animal with no name!";
                    // животное без клички
        }
        public Animal(string newName)
        {
            name = newName;
        }
        public void Feed()
        {
            Console.WriteLine("{0} has been fed.",name);
        }
    }
}
