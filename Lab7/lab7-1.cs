using System;

class Animal
{
   public virtual void Speak()
    {
        Console.WriteLine("Sound ... ");
    }
}

class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Meow!");
    }
}

class Wolf : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Auuu");
    }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[]
        {
            new Dog(),
            new Wolf(),
            new Cat(),
            new Animal(),
        };
        foreach (var animal in animals) {
            animal.Speak();
        }
    }
}
