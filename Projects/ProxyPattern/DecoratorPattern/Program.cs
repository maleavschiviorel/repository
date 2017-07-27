using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Engine
    { }
    public class EnhancedPowerEngine : Engine
    { }
    public class NormalPowerEngine : Engine
    { }
    public class Suspension
    { }
    public abstract class Car : ICar
    {
        private Engine _engine;
        private Suspension _suspension;


        public Car(Engine engine, Suspension suspension)
        {
            _engine = engine;
            _suspension = suspension;
        }

        public abstract string GetDescrition();
        public abstract decimal GetCost();
    }
    public class CountryCar : Car
    {
        public CountryCar(EnhancedPowerEngine engine, Suspension suspension) : base(engine, suspension)
        {
        }

        public override decimal GetCost()
        {
            return 4000;
        }

        public override string GetDescrition()
        {
            return "Country car";
        }
    }
    public class CityCar : Car
    {
        public CityCar(NormalPowerEngine engine, Suspension suspension) : base(engine, suspension)
        {
        }

        public override decimal GetCost()
        {
            return 3000;
        }

        public override string GetDescrition()
        {
            return "City car";
        }
    }
    public class CarWithClimaDecorator : ICar
    {
        private ICar _car;
        public CarWithClimaDecorator(ICar car)
        {
            _car = car;
        }
        public decimal Cost { get; protected set; }

        public decimal GetCost()
        {
            return 100 + _car.GetCost();
        }

        public string GetDescrition()
        {
            return "Car with Clima"; ;
        }
    }
    public class AdditionalPtotectionDecorator : ICar
    {
        private ICar _car;
        public AdditionalPtotectionDecorator(ICar car)
        {
            _car = car;
        }
        public decimal Cost { get; protected set; }

        public decimal GetCost()
        {
            return 50 + _car.GetCost();
        }

        public string GetDescrition()
        {
            return "Car with Additional Ptotection"; ;
        }
    }
    public class Order
    {
        private ICar _car;

        public Order(ICar car)
        {
            _car = car;
        }

        public decimal GetCost()
        {
            return _car.GetCost();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new CountryCar(new EnhancedPowerEngine(), new Suspension());
            car = new CarWithClimaDecorator(car);
            car = new AdditionalPtotectionDecorator(car);

            var order = new Order(car);

            decimal cost = order.GetCost();
        }
    }
}
