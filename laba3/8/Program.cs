using System;
using System.Collections.Generic;

namespace _8_Raw_Data
{
    class Prog
    {
        class Car
        {
            public string model { get; set; }
            public Engine engine { get; set; }
            public Go cargo { get; set; }
            public Tires tires { get; set; }

            public Car(string model, Engine engine, Go cargo, Tires tires)
            {
                this.model = model;
                this.engine = engine;
                this.cargo = cargo;
                this.tires = tires;
            }

            public void Show()
            {
                Console.WriteLine($"Model: {model}\nEngine speed: {engine.EngineSpeed}\nEngine power: {engine.EnginePower}" +
                    $"\nCargo wight: {cargo.CargoWeight}\nCargo type: {cargo.CargoType}\nTires: { tires.Tire1Pressure} " +
                    $"{tires.Tire1Age} {tires.Tire2Pressure} {tires.Tire2Age} {tires.Tire3Pressure} {tires.Tire3Age} " +
                    $"{tires.Tire3Pressure} {tires.Tire3Age}");
            }
        }
        class Engine
        {
            public int EngineSpeed { get; set; }
            public int EnginePower { get; set; }

            public Engine(int EngineSpeed, int EnginePower)
            {
                this.EnginePower = EnginePower;
                this.EngineSpeed = EngineSpeed;
            }
        }
        class Go
        {
            public int CargoWeight { get; set; }
            public string CargoType { get; set; }

            public Go(int CargoWeight, string CargoType)
            {
                this.CargoWeight = CargoWeight;
                this.CargoType = CargoType;
            }
        }
        class Tires
        {
            public int Tire1Age { get; set; }
            public double Tire1Pressure { get; set; }
            public int Tire2Age { get; set; }
            public double Tire2Pressure { get; set; }
            public int Tire3Age { get; set; }
            public double Tire3Pressure { get; set; }
            public int Tire4Age { get; set; }
            public double Tire4Pressure { get; set; }

            public Tires(int Tire1Age, double Tire1Pressure, int Tire2Age, double Tire2Pressure, int Tire3Age, double Tire3Pressure, int Tire4Age, double Tire4Pressure)
            {
                this.Tire1Age = Tire1Age;
                this.Tire1Pressure = Tire1Pressure;
                this.Tire2Age = Tire2Age;
                this.Tire2Pressure = Tire2Pressure;
                this.Tire3Age = Tire3Age;
                this.Tire3Pressure = Tire3Pressure;
                this.Tire4Age = Tire4Age;
                this.Tire4Pressure = Tire4Pressure;
            }
        }

        static void PrintFr(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].cargo.CargoType == "fragile" && (cars[i].tires.Tire1Pressure < 1 ||
                    cars[i].tires.Tire2Pressure < 1 || cars[i].tires.Tire3Pressure < 1 || cars[i].tires.Tire4Pressure < 1))
                {
                    Console.WriteLine(cars[i].model);
                }
            }
        }
        static void PrintFl(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].cargo.CargoType == "flamable" && cars[i].engine.EnginePower > 250)
                {
                    Console.WriteLine(cars[i].model);
                }
            }
        }
        static void Main()
        {
            List<Car> cars = new List<Car>();

            Console.Write("Input the kilkist of cars: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                double tirePreasure_1, tirePreasure_2, tirePreasure_3, tirePreasure_4;
                string model, cargoType, allInput;
                int engineSpeed, enginePower, cargoWeight, tireAge_1, tireAge_2, tireAge_3, tireAge_4;
                Console.WriteLine($"Input Car № {i + 1}");
                allInput = Console.ReadLine();
                string[] allValues = allInput.Split(" ");
                model = allValues[0];
                engineSpeed = int.Parse(allValues[1]);
                enginePower = int.Parse(allValues[2]);
                cargoWeight = int.Parse(allValues[3]);
                cargoType = allValues[4];
                tirePreasure_1 = double.Parse(allValues[5]);
                tireAge_1 = int.Parse(allValues[6]);
                tirePreasure_2 = double.Parse(allValues[7]);
                tireAge_2 = int.Parse(allValues[8]);
                tirePreasure_3 = double.Parse(allValues[9]);
                tireAge_3 = int.Parse(allValues[10]);
                tirePreasure_4 = double.Parse(allValues[11]);
                tireAge_4 = int.Parse(allValues[12]);
                Engine engine = new Engine(engineSpeed, enginePower);
                Go cargo = new Go(cargoWeight, cargoType);
                Tires tires = new Tires(tireAge_1, tirePreasure_1, tireAge_2, tirePreasure_2, tireAge_3, tirePreasure_3, tireAge_4, tirePreasure_4);
                Car tempcar = new Car(model, engine, cargo, tires);
                cars.Add(tempcar);
            }

            string cmd = Console.ReadLine();
            if (cmd == "fragile")
            {
                PrintFr(cars);
            }
            else if (cmd == "flamable")
            {
                PrintFl(cars);
            }
        }
    }
}