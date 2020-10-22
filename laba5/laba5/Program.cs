using System;
using System.Collections.Generic;
using System.Text;

public class box
{
    private double length;
    private double width;
    private double height;

    public box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public string Getarea()
    {
        double Area = 2 * length * width + 2 * length * height + 2 * width * height;

        return $"Area - {Area:F2}";
    }

    public string GetLaterArea()
    {
        double laterArea = 2 * length * height + 2 * width * height;

        return $"Surface Area - {laterArea:F2}";
    }

    public string GetVolume()
    {
        double volume = length * width * height;

        return $"Volume - {volume:F2}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        box box = new box(length, width, height);

        Console.WriteLine(box.Getarea());
        Console.WriteLine(box.GetLaterArea());
        Console.WriteLine(box.GetVolume());
    }
}
