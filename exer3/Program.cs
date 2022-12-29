using System;
using System.Collections.Generic;
using System.Linq;
using exer2;

namespace exer3
{
    public class CarCatalog
    {
        Car[] cars;
        
        public CarCatalog(params Car[] args)
        {
            cars = args;
        }

        public IEnumerator<Car> GetEnumerator()
        {
            for (int i = 0; i < cars.Length; i++)
                yield return cars[i];
        }

        public IEnumerable<Car> Reverse()
        {
            for (int i = cars.Length - 1; i >= 0; i--)
                yield return cars[i];
        }

        public IEnumerable<Car> Year(int year)
        {
            var arr = cars;
  
            for (int i = 0; i  < arr.Length; i++)
                yield return arr[i];
        }

        public IEnumerable<Car> Speed()
        {
            var arr = cars;
            Array.Sort(arr, new CarComparer(CarCompareType.Speed));
            for (int i = 0; i < arr.Length; i++)
                yield return arr[i];
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Car[] mass =
            {
                new Car{Name = "qqq", ProductionYear = 1980, MaxSpeed = 120},
                new Car{Name = "qqq", ProductionYear = 1981, MaxSpeed = 190},
                new Car{Name = "qqq", ProductionYear = 1982, MaxSpeed = 70},
                new Car{Name = "qqq", ProductionYear = 1983, MaxSpeed = 10},
                new Car{Name = "qqq", ProductionYear = 1945, MaxSpeed = 90},
                new Car{Name = "qqq", ProductionYear = 1901, MaxSpeed = 100}
            };

            CarCatalog cc = new CarCatalog(mass);

            Console.WriteLine("Simple");
            foreach(var car in cc)
            {
                Console.WriteLine($"{car.Name}\t{car.ProductionYear}\t{car.MaxSpeed}");
            }

            Console.WriteLine("\nReverse");
            foreach (var car in cc.Reverse())
            {
                Console.WriteLine($"{car.Name}\t{car.ProductionYear}\t{car.MaxSpeed}");
            }

            Console.WriteLine("\nYear");
            foreach (var car in cc.Year())
            {
                Console.WriteLine($"{car.Name}\t{car.ProductionYear}\t{car.MaxSpeed}");
            }

            Console.WriteLine("\nSpeed");
            foreach (var car in cc.Speed())
            {
                Console.WriteLine($"{car.Name}\t{car.ProductionYear}\t{car.MaxSpeed}");
            }
        }
    }
}
