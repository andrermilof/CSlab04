using System;
using System.Collections.Generic;

namespace exer2
{
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }
    }

    public enum CarCompareType
    {
        Name,
        Year,
        Speed
    }

    public class CarComparer : IComparer<Car>
    {
        private CarCompareType _compareType;

        public CarComparer(CarCompareType compareType)
        {
            _compareType = compareType;
        }

        public int Compare(Car a, Car b)
        {
            return _compareType switch
            {
                CarCompareType.Name => a.Name.CompareTo(b.Name),
                CarCompareType.Year => a.ProductionYear.CompareTo(b.ProductionYear),
                CarCompareType.Speed => a.MaxSpeed.CompareTo(b.MaxSpeed),
                _ => throw new ArgumentException("unexpected compare type")
            };
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Car[] mass =
            {
                new Car{Name = "qqq", ProductionYear = 1990, MaxSpeed = 100},
                new Car{Name = "qqq", ProductionYear = 1990, MaxSpeed = 100},
                new Car{Name = "qqq", ProductionYear = 1990, MaxSpeed = 100},
                new Car{Name = "qqq", ProductionYear = 1990, MaxSpeed = 100},
                new Car{Name = "qqq", ProductionYear = 1990, MaxSpeed = 100},
                new Car{Name = "qqq", ProductionYear = 1990, MaxSpeed = 100}
            };

            Array.Sort(mass, new CarComparer(CarCompareType.Name));
            Array.Sort(mass, new CarComparer(CarCompareType.Year));
            Array.Sort(mass, new CarComparer(CarCompareType.Speed));
        }
    }
}
