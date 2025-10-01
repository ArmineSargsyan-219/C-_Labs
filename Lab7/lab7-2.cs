using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract class Shape
{
    public abstract double Area();
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double r) => Radius = r;
    public override double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double width { get; set;}
    public double heght { get; set;}   
    public Rectangle(double width, double heght)
    {
        this.width = width;     
        this.heght = heght;
    }

    public override double Area()=> width * heght;
}

public class Triangle : Shape
{
    public double baseLength { get; set; }
    public double height { get; set; }

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength; 
        this.height = height;        
    }

    public override double Area()
    {
        return (this.baseLength * this.height) / 2;
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>()
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 8),
            new Circle(2.5),
            new Rectangle(2, 3)
        };

        double totalArea = 0;
        int count = 1;

        foreach (var shape in shapes)
        {
            double area = shape.Area();
            Console.WriteLine($"Shape {count}: Area = {area:F2}");
            totalArea += area;
            count++;
        }

        Console.WriteLine($"\nTotal area of all shapes: {totalArea:F2}");
    }
}
