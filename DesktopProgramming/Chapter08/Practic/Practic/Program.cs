using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    interface ICup
    {
        void Refill();
        void Wash();
        string Color { get; set; }
        int Volume { get; set; }
    }

    abstract class HotDrink
    {
        public bool Milk { get; set; }
        public bool Sugar { get; set; }

        public void Drink()
        {
            Console.WriteLine("You drinkin Hot Drink.");
        }

        public void AddMilk()
        {
            Console.WriteLine("Milk added succesfully!");
        }

        public void AddSugar()
        {
            Console.WriteLine("Sugar added succesfully!");
        }
    }

    class CupOfCoffee : HotDrink, ICup
        {
            public void Refill()
            {
                Console.WriteLine("Cup of cofee refilled succesfully!");
            }

            public void Wash()
            {
                Console.WriteLine("Cup from coffee washed succesfully!");
            }

            public string Color { get; set; }
            public int Volume { get; set; }
            public string BeanType { get; set; }
        }

        class CupOfTea : HotDrink, ICup
        {
            public void Refill()
            {
                Console.WriteLine("Cup of tea refilled succesfully!");
            }

            public void Wash()
            {
                Console.WriteLine("Cup from tea washed succesfully!");
            }

            public CupOfTea(string color, int volume,string leaftype)
            {
                Color = color;
                Volume = volume;
                LeafType = leaftype;
            }
            public string Color { get; set; }
            public int Volume { get; set; }
            public string LeafType { get; set; }
        }

    class Program
    {
        delegate void ProcessDelegate(HotDrink xDrink);
        static void MyCoffe(HotDrink xCoffee)
        {
            CupOfCoffee x = new CupOfCoffee();
            x = (CupOfCoffee) xCoffee;
            x.AddMilk();
            x.Drink();
            x.Wash();
        }

        static void MyTea(HotDrink xTea)
        {
            CupOfTea x = new CupOfTea("",0,"");
            x = (CupOfTea) xTea;
            x.AddMilk();
            x.Drink();
            x.Wash();
            Console.WriteLine("Цвет {0}",x.Color);
            Console.WriteLine("Объем {0}",x.Volume);
            Console.WriteLine("Тип листьев {0}",x.LeafType);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1)New object CupOfCoffe\n2)New object CupOfTea");
            ProcessDelegate process;
            int i;
            do
            {
                i=Convert.ToInt32(Console.ReadLine());
            } while (i<1 || i>2);
            switch (i)
            {
                case 1:
                {
                    CupOfCoffee xCoffee = new CupOfCoffee();
                    process = new ProcessDelegate(MyCoffe);
                    process(xCoffee);
                }
                    break;
                case 2:
                {
                    CupOfTea xTea = new CupOfTea("White",100,"Цейлон");
                    process = new ProcessDelegate(MyTea);
                    process(xTea);
                }
                    break;
            }
            Console.ReadKey();
        }
    }
}
