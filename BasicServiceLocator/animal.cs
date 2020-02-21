using System;

namespace BasicServiceLocator
{
    public class Frog : IAnimal
    {
        public void Voice()
        {
            Console.WriteLine("Croak...Croak...");
        }
    }

    public class Cat : IAnimal
    {
        public void Voice()
        {
            Console.WriteLine("Meow...Meow");
        }
    }

    public class Cow : IAnimal
    {
        public void Voice()
        {
            Console.WriteLine("Moo...Moo...");
        }
    }
}