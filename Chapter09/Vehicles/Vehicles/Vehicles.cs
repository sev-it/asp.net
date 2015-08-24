using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNameSpace
{
    /// <summary>
    /// Абстрактный класс Транспорт-псевдовершина иерархии
    /// </summary>
    public abstract class Vehicles
    {
    }
    /// <summary>
    /// Дочерние абстрактные классы Поезд и Автомобиль
    /// </summary>
    public abstract class Train : Vehicles
    {
    }

    public abstract class Car : Vehicles
    {
    }

    /// <summary>
    /// Интерфейсы относящиеся либо к пассажирскому транспорту либо к грузовому
    /// </summary>
    public interface IPassengerCarrier
    {
    }

    public interface IHeavyLoadCarrier
    {
    }
    /// <summary>
    /// Классы видов автомобилей
    /// </summary>
    public sealed class Compact : Car, IPassengerCarrier
    {
    }

    public sealed class SUV : Car, IPassengerCarrier
    {
    }

    public sealed class PickUp : Car, IHeavyLoadCarrier
    {
    }

    /// <summary>
    /// Классы видов поездов
    /// </summary>
    public sealed class PassengerTrain : Train, IPassengerCarrier
    {
    }

    public sealed class FreightTrain : Train, IHeavyLoadCarrier
    {
    }

    public sealed class DoubleBogey : Train
    {
    }
}
