using System;

/// <summary>
/// Программа отработает с ошибкой, потому что нельзя переопределить метод сигнатуры которого нет в базовом классе.
/// </summary>
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Some generic animal sound");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }

    public override void MakeSound(int numberOfSounds)
    {
        for (int i = 0; i < numberOfSounds; i++)
        {
            Console.WriteLine("Meow");
        }
    }
}

public class Program
{
    public static void Run()
    {
        Animal cat = new Cat();

        cat.MakeSound();
        cat.MakeSound(3);
    }
}