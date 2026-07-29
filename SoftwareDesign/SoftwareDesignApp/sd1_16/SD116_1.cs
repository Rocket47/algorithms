namespace SoftwareDesign.sd1_16;

/// <summary>
/// Компилятор сообщает, что подходящего метода для переопределения в базовом классе нет.
/// </summary>
public class SD116_1
{
    class Animal
    {
        // public virtual void MakeSound()
        // {
        //     Console.WriteLine("Some generic animal sound");
        // }
        
        public virtual void MakeGenericSound()
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
    }

    public class Program
    {
        public static void Run()
        {
            Animal myCat = new Cat();
            myCat.MakeSound(); // Meow
        }
    }
}