using System;




namespace _3_Shapes

{

    class Program

    {

        static void Main(string[] args)

        {

            Shape rectangle = new Rectangle(5, 5);

            Console.WriteLine($"Area: {rectangle.CalculateArea()}");

            Console.WriteLine($"Perimeter: {rectangle.CalculatePerimeter()}");

            Console.WriteLine(rectangle.Draw());




            Shape circle = new Circle(3);

            Console.WriteLine($"Area: {circle.CalculateArea()}");

            Console.WriteLine($"Perimeter: {circle.CalculatePerimeter()}");

            Console.WriteLine(circle.Draw());

        }

    }

}