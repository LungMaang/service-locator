using System;
using FocusedReptile;

namespace SeniorServiceLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerRegisterCenter.RegistrationTarget(ManagerRegister.TemporaryPathKey, new TemporaryPath());
            ManagerRegisterCenter.RegistrationTarget(ManagerRegister.IDataPathHelperKey, new DataPathHelper());

            IDataPathHelper dataPathHelper = ManagerRegisterCenter.RecaptionTarget<IDataPathHelper>(ManagerRegister.IDataPathHelperKey);
            string path = IStoragePath.GetTargetPath(dataPathHelper.TemporaryPath);
            Console.WriteLine(path);
            Console.ReadLine();
        }
    }
}