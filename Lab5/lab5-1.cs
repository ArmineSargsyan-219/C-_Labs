using System;

public class Rectangle
{
    private double width;
    private double height;

    public double RecWidth
    {
        get => width;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(RecWidth), "Width can't be negative!");
            }
            width = value;
        }
    }

    public double RecHeight
    {
        get => height;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(RecHeight), "Height can't be negative!");
            }
            height = value;
        }
    }

    public Rectangle(double width, double height)
    {
        RecWidth = width;
        RecHeight = height;
    }

    public double Area => width * height;   
    public double Perimeter() => 2 * (width + height);


    public override string ToString()
    {
        return $"Rectangle {width}x{height} (Area={Area}, Perimeter={Perimeter()})";
    }


}

class Program
{
    static void Main()
    {
        Console.Write("Enter width: ");
        double width_ = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter height: ");
        double height_ = Convert.ToDouble(Console.ReadLine());

        Rectangle r = new Rectangle(width_, height_);

        Console.WriteLine(r);
    }
}
