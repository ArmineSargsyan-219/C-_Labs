using System;
using System.Collections.Generic;

public interface IMovable
{
    void Move();
}

public class Car : IMovable
{
    public void Move() => Console.WriteLine("The car is moving");
}

public class Human : IMovable
{
    public void Move() => Console.WriteLine(" Human is moving");
}

public class Robot : IMovable
{
    public void Move() => Console.WriteLine("Robot is moving");

   
}

class Program
{
    static void Main()
    {
        List<IMovable> movables = new List<IMovable>()
        {
            new Car(),
            new Human(),
            new Robot()
        };

        Console.WriteLine("Move all objects");

        foreach (var movable in movables)
        {
            movable.Move();
        }
    }
}

