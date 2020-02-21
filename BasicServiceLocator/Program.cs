using System;
using FocusedReptile;

namespace BasicServiceLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Frog frog = new Frog();
            //Cat cat = new Cat();
            Cow cow = new Cow();
            ManagerRegisterCenter.RegistrationTarget(ManagerRegister.IAnimalKey, cow);

            Console.WriteLine("It was another wonderful day, and a man came up to me and told me:");
            Student student = new Student();
            student.Hobby();
            Console.WriteLine("I like it, too...");
            Console.ReadLine();
        }
    }
}