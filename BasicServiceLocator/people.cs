using System;
using FocusedReptile;

namespace BasicServiceLocator
{
    public class Student : IPeople
    {
        public void Hobby()
        {
            Console.WriteLine("I am a student, my hobby is to play with my pet, it makes a good sound, let me show you!");
            ManagerRegisterCenter.RecaptionTarget<IAnimal>(ManagerRegister.IAnimalKey).Voice();
        }
    }

    public class Lawyer : IPeople
    {
        public void Hobby()
        {
            Console.WriteLine("I am a lawyer, my hobby is to play with my pet, it makes a good sound, let me show you!");
            ManagerRegisterCenter.RecaptionTarget<IAnimal>(ManagerRegister.IAnimalKey).Voice();
        }
    }

    public class Chef : IPeople
    {
        public void Hobby()
        {
            Console.WriteLine("I am a chef, my hobby is to play with my pet, it makes a good sound, let me show you!");
            ManagerRegisterCenter.RecaptionTarget<IAnimal>(ManagerRegister.IAnimalKey).Voice();
        }
    }
}