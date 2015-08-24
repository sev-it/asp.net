using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class Program
    {
        static void Main(string[] args)
        {
            People peoples = new People();
            peoples.Add(new Person());
            peoples[0].Name = "Tema";
            peoples[0].Age = 15;
            peoples.Add(new Person());
            peoples[1].Name = "Tema";
            peoples[1].Age = 21;
            peoples.Add(new Person());
            peoples[2].Name = "Robert";
            peoples[2].Age = 21;
            Person[] oldest = peoples.GetOldest();
            for (int i=0; i<oldest.Length;i++)
                Console.WriteLine("Name {0}, age {1}",oldest[i].Name,oldest[i].Age);
            Console.ReadKey();
            People tmp = peoples["Tema"];
            if (tmp.Count>1)
                Console.WriteLine("There are {0} oject with name tema.",tmp.Count);
            for (int i=0;i<tmp.Count;i++)
                Console.WriteLine("With name Tema: {0} {1}", tmp[i].Age, tmp[i].Name);
            Console.ReadKey();
            foreach (int age in peoples.Ages)
                Console.Write("{0} ",age);
            Console.ReadKey();
        }
    }
}
