using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNameSpace;

namespace Traffic
{
    class Program
    {
        static public void AddPassenger(IPassengerCarrier iObject)
        {
            Console.WriteLine(iObject.ToString());
        }
        static void Main(string[] args)
        {
            Vehicles[] aVehicles = new Vehicles[6];
            aVehicles[0] = new Compact();
            aVehicles[1] = new DoubleBogey();
            aVehicles[2] = new FreightTrain();
            aVehicles[3] = new PassengerTrain();
            aVehicles[4] = new PickUp();
            aVehicles[5] = new SUV();
            foreach (Vehicles vehicles in aVehicles)
            {
                try
                {
                    IPassengerCarrier tmp = (IPassengerCarrier) vehicles;
                    AddPassenger(tmp);
                }
                catch (Exception)
                {
                    Console.WriteLine("Объект не наследует интерфейс IPassengerCarrier {0}",vehicles.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
